Imports System
Imports System.Data
Imports System.Data.OleDb


Public Class Form1
    Public cnn As OleDbConnection

    Public cmd As OleDbCommand

    Public dtr As OleDbDataReader
    Private Sub BtnValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnValider.Click
        Dim cnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" & Application.StartupPath & "\Fournisseur.mdb")

        Dim cmd As New OleDbCommand("select * from connexion where login ='" & TxtLogin.Text & "' and motpass='" & TxtId.Text & "'", cnn)
        cnn.Open()
        Dim dtr As OleDbDataReader = cmd.ExecuteReader
        If TxtLogin.Text = " " Or TxtId.Text = " " Then
            'vbcritical permet le signe en rouge anec attention comme message
            MsgBox("veuillez remplir le(s) champs", vbCritical, "Attention")
            TxtLogin.Focus()
            Exit Sub

        End If
        If dtr.Read() Then
            MessageBox.Show("login et mot de passe correct")
            Form2.Show()
        Else
            MsgBox("login et mot de passe incorrect")
            TxtLogin.Clear()
            TxtId.Clear()
            TxtLogin.Focus()

        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'FournisseurDataSet1.connexion'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.ConnexionTableAdapter.Fill(Me.FournisseurDataSet1.connexion)
        'TODO: cette ligne de code charge les données dans la table 'FournisseurDataSet1.connexion'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.ConnexionTableAdapter.Fill(Me.FournisseurDataSet1.connexion)
        'une formulaire de connexion permet de securiser c est le cas de ce formulaire 3

    End Sub
End Class
