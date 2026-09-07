Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Access

Public Class Form5

    
    Private strCon As String


    Private Sub Form5_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" & System.Windows.Forms.Application.StartupPath & "\Fournisseur.mdb"
        Me.ProduitTableAdapter.Fill(Me.FournisseurDataSet.Produit)
    End Sub

    ' Recherche : cherche un produit par CodeProduit et affiche ses infos
    Private Sub BtnRecherche_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnRecherche.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez saisir un code produit")
            Return
        End If

        Using cnn As New OleDbConnection(strCon)
            cnn.Open()
            Dim cmd As New OleDbCommand("select * from Produit where CodeProduit=?", cnn)
            cmd.Parameters.AddWithValue("@CodeProduit", TextBox1.Text)

            Using dtr As OleDbDataReader = cmd.ExecuteReader()
                If dtr.Read() Then
                    MessageBox.Show("il existe un produit sur cet identifiant")
                    TextBox2.Text = dtr("Designation").ToString()
                    TextBox3.Text = dtr("PrixUnitaire").ToString()
                    TextBox4.Text = dtr("Stock").ToString()
                Else
                    MessageBox.Show("produit non trouvé")
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                End If
            End Using
        End Using
    End Sub

    ' Ajouter : cree un nouveau produit
    Private Sub BtnAjouter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAjouter.Click
        If TextBox1.Text = "" OrElse TextBox2.Text = "" OrElse TextBox3.Text = "" OrElse TextBox4.Text = "" Then
            MessageBox.Show("Veuillez remplir tous les champs")
            Return
        End If

        Dim prix As Double
        Dim stock As Integer
        If Not Double.TryParse(TextBox3.Text, prix) Then
            MessageBox.Show("Prix invalide")
            Return
        End If
        If Not Integer.TryParse(TextBox4.Text, stock) Then
            MessageBox.Show("Stock invalide")
            Return
        End If

        Using cnn As New OleDbConnection(strCon)
            cnn.Open()

            ' verification que le produit n existe pas deja
            Dim cmdVerif As New OleDbCommand("select * from Produit where CodeProduit=?", cnn)
            cmdVerif.Parameters.AddWithValue("@CodeProduit", TextBox1.Text)
            Using dtrVerif As OleDbDataReader = cmdVerif.ExecuteReader()
                If dtrVerif.Read() Then
                    MessageBox.Show("le produit existe déjà")
                    Return
                End If
            End Using

            Dim reponse As MsgBoxResult = MsgBox("Voulez-vous vraiment ajouter ce produit?", MsgBoxStyle.YesNo, "Ajout")
            If reponse = MsgBoxResult.Yes Then
                Dim cmdInsert As New OleDbCommand("insert into Produit (CodeProduit, Designation, PrixUnitaire, Stock) values (?, ?, ?, ?)", cnn)
                cmdInsert.Parameters.AddWithValue("@CodeProduit", TextBox1.Text)
                cmdInsert.Parameters.AddWithValue("@Designation", TextBox2.Text)
                cmdInsert.Parameters.AddWithValue("@PrixUnitaire", prix)
                cmdInsert.Parameters.AddWithValue("@Stock", stock)
                cmdInsert.ExecuteNonQuery()

                MessageBox.Show("produit ajouté")
            Else
                MessageBox.Show("ajout annulé")
            End If
        End Using
    End Sub

    ' Modifier : met a jour un produit existant
    Private Sub BtnModifier_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnModifier.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez d'abord rechercher un produit")
            Return
        End If

        Dim prix As Double
        Dim stock As Integer
        If Not Double.TryParse(TextBox3.Text, prix) Then
            MessageBox.Show("Prix invalide")
            Return
        End If
        If Not Integer.TryParse(TextBox4.Text, stock) Then
            MessageBox.Show("Stock invalide")
            Return
        End If

        Try
            Using cnn As New OleDbConnection(strCon)
                cnn.Open()
                Dim reponse As MsgBoxResult = MsgBox("Voulez-vous vraiment modifier ce produit?", MsgBoxStyle.YesNo, "Modification")

                If reponse = MsgBoxResult.Yes Then
                    Dim cmdMod As New OleDbCommand("update Produit set Designation=?, PrixUnitaire=?, Stock=? where CodeProduit=?", cnn)
                    cmdMod.Parameters.AddWithValue("@Designation", TextBox2.Text)
                    cmdMod.Parameters.AddWithValue("@PrixUnitaire", prix)
                    cmdMod.Parameters.AddWithValue("@Stock", stock)
                    cmdMod.Parameters.AddWithValue("@CodeProduit", TextBox1.Text)

                    If cmdMod.ExecuteNonQuery() > 0 Then
                        MessageBox.Show("modification effectuée")
                    Else
                        MessageBox.Show("aucun produit trouvé")
                    End If
                Else
                    MessageBox.Show("modification annulée")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur " & ex.Message)
        End Try
    End Sub

    ' Supprimer : supprime un produit
    Private Sub BtnSupprimer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSupprimer.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez saisir un code produit")
            Return
        End If

        Dim reponse As MsgBoxResult = MsgBox("Voulez-vous vraiment supprimer ce produit?", MsgBoxStyle.YesNo, "Suppression")
        If reponse = MsgBoxResult.Yes Then
            Using cnn As New OleDbConnection(strCon)
                cnn.Open()
                Dim cmd As New OleDbCommand("delete from Produit where CodeProduit=?", cnn)
                cmd.Parameters.AddWithValue("@CodeProduit", TextBox1.Text)

                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("suppression effectuée")
                Catch ex As Exception
                    MessageBox.Show("Impossible de supprimer : ce produit est peut-être utilisé dans une commande")
                End Try
            End Using

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
        Else
            MessageBox.Show("suppression non effectuée")
        End If
    End Sub

    ' Nouveau : vide les champs pour une nouvelle saisie
    Private Sub BtnNouveau_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNouveau.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub

    ' Terminer : retour au menu
    Private Sub BtnTerminer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnTerminer.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub BtnPrécédent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrécédent.Click
        ProduitBindingSource.MovePrevious()
    End Sub

    Private Sub BtnSuivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuivant.Click
        ProduitBindingSource.MoveNext()
    End Sub

    Private Sub BtnEffacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEffacer.Click
        'on pouvait utilser textBox1.tex=" " au lieu de reset 
        Me.TextBox1.ResetText()
        Me.TextBox2.ResetText()
        Me.TextBox3.ResetText()
        Me.TextBox4.ResetText()
        

    End Sub
End Class