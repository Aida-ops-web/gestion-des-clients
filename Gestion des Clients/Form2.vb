Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AffichageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AffichageToolStripMenuItem.Click
        Form4.Show()

    End Sub

    Private Sub FichierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichierToolStripMenuItem.Click
        Form3.Show()

    End Sub

    Private Sub EditionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditionToolStripMenuItem.Click
        Form5.Show()

    End Sub

    Private Sub ProjetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjetToolStripMenuItem.Click
        Try
            ' Chemin vers le fichier Word situé dans le dossier de l'application
            Dim cheminFichier As String = Application.StartupPath & "\Mode_d_emploi_Gestion_des_Clients.docx"

            ' Vérifier si le fichier existe
            If System.IO.File.Exists(cheminFichier) Then
                ' Ouvrir le document avec l'application par défaut (Word)
                Process.Start(cheminFichier)
            Else
                MessageBox.Show("Le document d'aide est introuvable : " & cheminFichier, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Impossible d'ouvrir le fichier : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class