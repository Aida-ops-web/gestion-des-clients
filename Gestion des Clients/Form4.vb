Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Access
Imports Microsoft.Office.Interop

Public Class Form4

    Private strSQL, strCon As String
    Public cnn As OleDbConnection
    Public cmd As OleDbCommand
    Public dtr As OleDbDataReader
    Public dta As OleDbDataAdapter
    Public dts As DataSet

    ' controles attendus :
    ' TextBox1 = numCommande, TextBox2 = idClient, TextBox3 = DateCommande (texte)
    ' CheckBox1 = CommandeRegle, CboProduit = liste deroulante produit, TextBox4 = Quantite
    ' DataGridView1 = affiche les lignes de la commande

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" & System.Windows.Forms.Application.StartupPath & "\Fournisseur.mdb"
        ChargerProduits()
    End Sub

    ' remplit la liste deroulante avec le code produit (valeur) et la designation (affichage)
    'appelle la procedure ChargerProduits
    Private Sub ChargerProduits()
        'ovre la connexion a access er garantie sa fermeture a la fin du bloc using
        Using cnn As New OleDbConnection(strCon)
            cnn.Open()
            Dim cmdProd As New OleDbCommand("select CodeProduit, Designation from Produit", cnn)
            Dim dtaProd As New OleDbDataAdapter(cmdProd)
            'remplit la table virtuelle
            Dim dtProd As New DataTable
            dtaProd.Fill(dtProd)
            'lie la liste deroulante aux donnees de la table
            CboProduit.DataSource = Nothing
            CboProduit.DataSource = dtProd
            'affiche la designation du produit a l utilisateur
            CboProduit.DisplayMember = "Designation"
            'la partie cachee
            CboProduit.ValueMember = "CodeProduit"
            'permet au chechBox d etre vide a l affichage
            CboProduit.SelectedIndex = -1
        End Using
    End Sub

    ' rafraichit le tableau des lignes de la commande affichee (CodeProduit, Designation, Quantite)
    Private Sub AfficherLignesCommande()
        Using cnn As New OleDbConnection(strCon)
            cnn.Open()
            Dim cmdLignes As New OleDbCommand(
                "select LigneCommande.CodeProduit, Produit.Designation, LigneCommande.Quantite " &
                "from LigneCommande inner join Produit on LigneCommande.CodeProduit = Produit.CodeProduit " &
                "where LigneCommande.numCommande = ?", cnn)
            cmdLignes.Parameters.AddWithValue("@numCommande", TextBox1.Text)

            Dim dtaLignes As New OleDbDataAdapter(cmdLignes)
            Dim dtsLignes As New DataSet
            'fill est une methode qui sert a excecuter la requete
            dtaLignes.Fill(dtsLignes, "LignesCommande")

            DataGridView1.DataSource = dtsLignes.Tables("LignesCommande")
        End Using
    End Sub

    ' ValiderCommande : cree l entete de la commande (comme BtnAjouter1 dans Form2)
    Private Sub BtnValiderCommande_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnValider.Click
        If TextBox1.Text = "" OrElse TextBox2.Text = "" OrElse TextBox3.Text = "" Then
            MessageBox.Show("Veuillez remplir numéro de commande, client et date")
            Return
        End If

        If Not IsDate(TextBox3.Text) Then
            MessageBox.Show("Date invalide")
            Return
        End If

        Using cnn As New OleDbConnection(strCon)
            cnn.Open()

            ' verification que la commande n existe pas deja
            Dim cmdVerif As New OleDbCommand("select * from Commande where numCommande=?", cnn)
            cmdVerif.Parameters.AddWithValue("@numCommande", TextBox1.Text)
            Using dtrVerif As OleDbDataReader = cmdVerif.ExecuteReader()
                If dtrVerif.Read() Then
                    MessageBox.Show("cette commande existe déjà")
                    Return
                End If
            End Using

            Dim reponse As MsgBoxResult = MsgBox("Voulez-vous vraiment créer cette commande?", MsgBoxStyle.YesNo, "Validation")
            If reponse = MsgBoxResult.Yes Then
                Dim cmdInsert As New OleDbCommand("insert into Commande (numCommande, idClient, DateCommande, CommandeRegle) values (?, ?, ?, ?)", cnn)
                cmdInsert.Parameters.AddWithValue("@numCommande", TextBox1.Text)
                cmdInsert.Parameters.AddWithValue("@idClient", TextBox2.Text)
                cmdInsert.Parameters.AddWithValue("@DateCommande", CDate(TextBox3.Text))
                cmdInsert.Parameters.AddWithValue("@CommandeRegle", CheckBox1.Checked)
                cmdInsert.ExecuteNonQuery()

                MessageBox.Show("commande créée")
            Else
                MessageBox.Show("création annulée")
            End If
        End Using

    End Sub

    ' RechercheCommande : recherche une commande existante par numCommande et affiche entete + lignes
    Private Sub BtnRechercheCommande_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnRecherche.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez saisir un numéro de commande")
            Return
        End If

        Using cnn As New OleDbConnection(strCon)
            cnn.Open()
            Dim cmdRech As New OleDbCommand("select * from Commande where numCommande=?", cnn)
            cmdRech.Parameters.AddWithValue("@numCommande", TextBox1.Text)

            Using dtrRech As OleDbDataReader = cmdRech.ExecuteReader()
                If dtrRech.Read() Then
                    MessageBox.Show("il existe une commande sur cet identifiant")
                    TextBox2.Text = dtrRech("idClient").ToString()
                    TextBox3.Text = dtrRech("DateCommande").ToString()
                    CheckBox1.Checked = CBool(dtrRech("CommandeRegle"))
                Else
                    MessageBox.Show("commande non trouvée")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    CheckBox1.Checked = False
                    DataGridView1.DataSource = Nothing
                    Return
                End If
            End Using
        End Using

        ' reinitialisation des champs de saisie du produit (pas lies a la commande recherchee)
        CboProduit.SelectedIndex = -1
        TextBox4.Clear()

        AfficherLignesCommande()
    End Sub

    ' ModifierCommande : met a jour idClient, DateCommande, CommandeRegle d une commande existante
    Private Sub BtnModifierCommande_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnModier.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez d'abord rechercher une commande")
            Return
        End If

        Try
            Using cnn As New OleDbConnection(strCon)
                cnn.Open()
                Dim reponse As MsgBoxResult = MsgBox("Voulez-vous vraiment modifier cette commande?", MsgBoxStyle.YesNo, "Modification")

                If reponse = MsgBoxResult.Yes Then
                    Dim strSQLMod As String = "update Commande set idClient=?, DateCommande=?, CommandeRegle=? where numCommande=?"
                    Using cmdMod As New OleDbCommand(strSQLMod, cnn)
                        cmdMod.Parameters.AddWithValue("@idClient", TextBox2.Text)
                        cmdMod.Parameters.AddWithValue("@DateCommande", CDate(TextBox3.Text))
                        cmdMod.Parameters.AddWithValue("@CommandeRegle", CheckBox1.Checked)
                        cmdMod.Parameters.AddWithValue("@numCommande", TextBox1.Text)

                        If cmdMod.ExecuteNonQuery() > 0 Then
                            MessageBox.Show("modification effectuée", "Modification")
                        Else
                            MessageBox.Show("aucune commande trouvée", "Information")
                        End If
                    End Using
                Else
                    MessageBox.Show("modification annulée")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur " & ex.Message)
        End Try
    End Sub

    ' SupprimerCommande : supprime la commande et ses lignes associees
    Private Sub BtnSupprimerCommande_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSupprimer.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez saisir un numéro de commande")
            Return
        End If

        Dim reponse As MsgBoxResult = MsgBox("Voulez-vous vraiment supprimer cette commande?", MsgBoxStyle.YesNo, "Suppression")
        If reponse = MsgBoxResult.Yes Then
            Using cnn As New OleDbConnection(strCon)
                cnn.Open()

                ' on supprime d abord les lignes (contrainte de cle etrangere), puis l entete
                Dim cmdSuppLignes As New OleDbCommand("delete from LigneCommande where numCommande=?", cnn)
                cmdSuppLignes.Parameters.AddWithValue("@numCommande", TextBox1.Text)
                cmdSuppLignes.ExecuteNonQuery()

                Dim cmdSuppCommande As New OleDbCommand("delete from Commande where numCommande=?", cnn)
                cmdSuppCommande.Parameters.AddWithValue("@numCommande", TextBox1.Text)
                cmdSuppCommande.ExecuteNonQuery()

                MessageBox.Show("suppression effectuée")
            End Using

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            CheckBox1.Checked = False
            DataGridView1.DataSource = Nothing
        Else
            MessageBox.Show("suppression non effectuée")
        End If
    End Sub

    ' AjouterProduit : ajoute une ligne de produit a la commande courante et met a jour le stock
    Private Sub BtnAjouterProduit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAjouter.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez d'abord rechercher ou créer une commande")
            Return
        End If

        If CboProduit.SelectedValue Is Nothing Then
            MessageBox.Show("Veuillez choisir un produit")
            Return
        End If

        Dim quantite As Integer
        If Not Integer.TryParse(TextBox4.Text, quantite) OrElse quantite <= 0 Then
            MessageBox.Show("Quantité invalide")
            Return
        End If

        Dim codeProduit As String = CboProduit.SelectedValue.ToString()

        Using cnn As New OleDbConnection(strCon)
            cnn.Open()

            ' verification du stock disponible
            Dim cmdStockCheck As New OleDbCommand("select Stock from Produit where CodeProduit=?", cnn)
            cmdStockCheck.Parameters.AddWithValue("@CodeProduit", codeProduit)
            Dim stockActuel As Integer = CInt(cmdStockCheck.ExecuteScalar())

            If quantite > stockActuel Then
                MessageBox.Show("Stock insuffisant. Disponible : " & stockActuel)
                Return
            End If

            ' insertion de la ligne
            Dim cmdInsertLigne As New OleDbCommand("insert into LigneCommande (numCommande, CodeProduit, Quantite) values (?, ?, ?)", cnn)
            cmdInsertLigne.Parameters.AddWithValue("@numCommande", TextBox1.Text)
            cmdInsertLigne.Parameters.AddWithValue("@CodeProduit", codeProduit)
            cmdInsertLigne.Parameters.AddWithValue("@Quantite", quantite)
            cmdInsertLigne.ExecuteNonQuery()

            ' mise a jour du stock
            Dim cmdMajStock As New OleDbCommand("update Produit set Stock = Stock - ? where CodeProduit = ?", cnn)
            cmdMajStock.Parameters.AddWithValue("@Quantite", quantite)
            cmdMajStock.Parameters.AddWithValue("@CodeProduit", codeProduit)
            cmdMajStock.ExecuteNonQuery()

            MessageBox.Show("produit ajouté à la commande")
        End Using

        CboProduit.SelectedIndex = -1
        TextBox4.Clear()

        AfficherLignesCommande()
    End Sub

    Private Sub BtnNouveau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNouveau.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        CheckBox1.Checked = False
        CboProduit.SelectedIndex = -1
        DataGridView1.DataSource = Nothing

        TextBox1.Focus()
    End Sub

    Private Sub BtnTerminer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTerminer.Click
        Me.Hide()
        Form2.Show()
    End Sub


    Private Sub BtnFacture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFacture.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Veuillez d'abord rechercher une commande")
            Return
        End If

        Try
            Dim accessApp As New Access.Application
            accessApp.OpenCurrentDatabase(System.Windows.Forms.Application.StartupPath & "\Fournisseur.mdb")
            accessApp.Visible = True

            accessApp.DoCmd.OpenReport("Facture de Commande", Access.AcView.acViewPreview, , "NumCommande='" & TextBox1.Text & "'")
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'ouverture de la facture : " & ex.Message)
        End Try
    End Sub
End Class