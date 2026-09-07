
Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class Form3

    'variable de sql de type string strCon permet de changer la connexion
    Private strSQL, strCon As String
    Public cnn As OleDbConnection

    Public cmd As OleDbCommand

    Public dtr As OleDbDataReader
    Public dta As OleDbDataAdapter
    Public dts As DataSet
    Private cmb As OleDbCommandBuilder
   

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' cette ligne de code charge les données dans la table 'FournisseurDataSet1.Client'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.ClientTableAdapter.Fill(Me.FournisseurDataSet1.Client)

    End Sub

    Private Sub BtnPrecedent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrecedent.Click
        BindingSource1.MovePrevious()
    End Sub

    Private Sub BtnSuivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuivant.Click
        BindingSource1.MoveNext()
    End Sub

    Private Sub BtnRecherche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecherche.Click
        'ligne de connexion* a la base
        Dim cnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" & Application.StartupPath & "\Fournisseur.mdb")

        'pour la requete sql choisie idclient car cette table ne se repete pas
        'quand un champs est du texte on met apostrophe si le champ n'est pas en texte on met les guillement simplement
        Dim cmd As New OleDbCommand("select * from Client where idClient='" & TextBox1.Text & "'", cnn)

        'on ouvre la connexion
        cnn.Open()


        Dim dtr As OleDbDataReader = cmd.ExecuteReader
        'condition de lecture
        If dtr.Read() Then
            'messagebox est la nouvelle version de textbox
            MessageBox.Show("il exixte un client sur cet identification")
            'tostring=conversion de tout type de donnee
            'si on trouve on affiche tout les elements consernant cet id
            TextBox1.Text = dtr("idClient").ToString
            TextBox2.Text = dtr("Nom").ToString
            TextBox3.Text = dtr("Prénom").ToString
            TextBox4.Text = dtr("Adresse").ToString
            TextBox5.Text = dtr("Tel").ToString
            TextBox6.Text = dtr("CodePostal").ToString
            TextBox7.Text = dtr("Email").ToString


            'si l element  existe pas
        Else
            MessageBox.Show("element non trouve")
            TextBox1.Clear()
            TextBox1.Focus()

        End If
    End Sub

    Private Sub BtnEffacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEffacer.Click
        'on pouvait utilser textBox1.tex=" " au lieu de reset 
        Me.TextBox1.ResetText()
        Me.TextBox2.ResetText()
        Me.TextBox3.ResetText()
        Me.TextBox4.ResetText()
        Me.TextBox5.ResetText()
        Me.TextBox6.ResetText()
        Me.TextBox7.ResetText()

    End Sub

    Private Sub BtnSupprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSupprimer.Click
        'on change la methode de  connexion
        strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" & Application.StartupPath & "\Fournisseur.mdb"
        cnn = New OleDbConnection()
        cnn.ConnectionString = strCon
        cnn.Open()
        cmd = cnn.CreateCommand
        cmd.CommandType = CommandType.Text

        Dim reponse As String
        strSQL = "delete from Client where idClient='" & TextBox1.Text & "'"
        reponse = MsgBox("Voulez-vous vraiment supprimer ce Client?", vbYesNo, "suppression")
        If reponse = vbYes Then
            MsgBox("suppression effectuee", , "suppression")
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
        Else
            MessageBox.Show("suppression non effectuee")


        End If

        'pour effacer les zones de texte
        Me.TextBox1.ResetText()
        cnn.Close()





    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" & Application.StartupPath & "\Fournisseur.mdb")
        Dim cmd As New OleDbCommand("select * from Client where idClient='" & TextBox1.Text & "'", cnn)

        'on ouvre la connexion
        cnn.Open()
        Dim dtr As OleDbDataReader = cmd.ExecuteReader

        Dim dta As New OleDbDataAdapter(cmd)
        'stockage des donnes en memoire
        Dim dts As New DataSet
        If dtr.Read() Then
            MessageBox.Show("le Client existe déja")
            TextBox1.Clear()
            TextBox1.Focus()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()


        Else
            'read c'est une methode et le text c'est Propriete fill esr aussi une methode
            dtr.Close()
            'fill permet de remplir le dataset ou une table pour ajouter
            dta.Fill(dts, "Client")
            'ajoute une nouvelle ligne dans la table client
            dts.Tables("Client").Rows.Add(New Object() {TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox6.Text, TextBox5.Text, TextBox7.Text})
            'cmb permet de creer une requete sql(insert,update,delete) on na deja la requete en haut donc ca modifie une table de la base de donnees 
            Dim cmb As New OleDbCommandBuilder(dta)
            dta.Update(dts, "Client")
            MessageBox.Show("Client ajouté")
            TextBox1.Clear()
            TextBox1.Focus()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()

            cnn.Close()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" & Application.StartupPath & "\Fournisseur.mdb"
        'exeption =les element qui ne font pas partie du programme et try revele les erreurs
        Try
            Using cnn As New OleDb.OleDbConnection(strCon)
                cnn.Open()
                Dim reponse As MsgBoxResult
                reponse = MsgBox("voulez vous vraiment modifier ce client?", MsgBoxStyle.YesNo, "Modification")
                If reponse = MsgBoxResult.Yes Then
                    Dim strSQL As String
                    strSQL = "update Client set Nom=?, Prénom=?, Adresse=?, Tel=?, CodePostal=?, Email=? where idClient=?"
                    Using cmd As New OleDb.OleDbCommand(strSQL, cnn)
                        cmd.Parameters.AddWithValue("@Nom", TextBox2.Text)
                        cmd.Parameters.AddWithValue("@Prénom", TextBox3.Text)
                        cmd.Parameters.AddWithValue("@Adresse", TextBox4.Text)
                        cmd.Parameters.AddWithValue("@Tel", TextBox5.Text)
                        cmd.Parameters.AddWithValue("@CodePostal", TextBox6.Text)
                        cmd.Parameters.AddWithValue("@Email", TextBox7.Text)
                        cmd.Parameters.AddWithValue("@idClient", TextBox1.Text)

                        If cmd.ExecuteNonQuery > 0 Then
                            MessageBox.Show("Modification effectuée", "Modification")
                        Else
                            MessageBox.Show("Aucun Client trouvé", "Information")
                        End If
                    End Using
                    TextBox1.Clear()
                    TextBox1.Focus()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    TextBox7.Clear()
                Else
                    MessageBox.Show("Modification annulée")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur " & ex.Message)
        End Try
    End Sub

    Private Sub BtnTerminer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTerminer.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class