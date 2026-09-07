<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnRecherche = New System.Windows.Forms.Button()
        Me.BtnAjouter = New System.Windows.Forms.Button()
        Me.BtnModifier = New System.Windows.Forms.Button()
        Me.BtnSupprimer = New System.Windows.Forms.Button()
        Me.BtnNouveau = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FournisseurDataSet = New WindowsApplication1.FournisseurDataSet()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.BtnTerminer = New System.Windows.Forms.Button()
        Me.ProduitTableAdapter = New WindowsApplication1.FournisseurDataSetTableAdapters.ProduitTableAdapter()
        Me.BtnPrécédent = New System.Windows.Forms.Button()
        Me.BtnSuivant = New System.Windows.Forms.Button()
        Me.BtnEffacer = New System.Windows.Forms.Button()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FournisseurDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnRecherche
        '
        Me.BtnRecherche.Location = New System.Drawing.Point(12, 279)
        Me.BtnRecherche.Name = "BtnRecherche"
        Me.BtnRecherche.Size = New System.Drawing.Size(75, 23)
        Me.BtnRecherche.TabIndex = 0
        Me.BtnRecherche.Text = "Recherche"
        Me.BtnRecherche.UseVisualStyleBackColor = True
        '
        'BtnAjouter
        '
        Me.BtnAjouter.Location = New System.Drawing.Point(163, 279)
        Me.BtnAjouter.Name = "BtnAjouter"
        Me.BtnAjouter.Size = New System.Drawing.Size(75, 23)
        Me.BtnAjouter.TabIndex = 1
        Me.BtnAjouter.Text = "Ajouter"
        Me.BtnAjouter.UseVisualStyleBackColor = True
        '
        'BtnModifier
        '
        Me.BtnModifier.Location = New System.Drawing.Point(318, 279)
        Me.BtnModifier.Name = "BtnModifier"
        Me.BtnModifier.Size = New System.Drawing.Size(75, 23)
        Me.BtnModifier.TabIndex = 2
        Me.BtnModifier.Text = "Modifier"
        Me.BtnModifier.UseVisualStyleBackColor = True
        '
        'BtnSupprimer
        '
        Me.BtnSupprimer.Location = New System.Drawing.Point(469, 279)
        Me.BtnSupprimer.Name = "BtnSupprimer"
        Me.BtnSupprimer.Size = New System.Drawing.Size(75, 23)
        Me.BtnSupprimer.TabIndex = 3
        Me.BtnSupprimer.Text = "Spprimer"
        Me.BtnSupprimer.UseVisualStyleBackColor = True
        '
        'BtnNouveau
        '
        Me.BtnNouveau.Location = New System.Drawing.Point(622, 279)
        Me.BtnNouveau.Name = "BtnNouveau"
        Me.BtnNouveau.Size = New System.Drawing.Size(75, 23)
        Me.BtnNouveau.TabIndex = 4
        Me.BtnNouveau.Text = "Nouveau"
        Me.BtnNouveau.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "CodeProduit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Designation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(118, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PrixUnitaire"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(118, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Stock"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "CodeProduit", True))
        Me.TextBox1.Location = New System.Drawing.Point(318, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 9
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.FournisseurDataSet
        '
        'FournisseurDataSet
        '
        Me.FournisseurDataSet.DataSetName = "FournisseurDataSet"
        Me.FournisseurDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "Designation", True))
        Me.TextBox2.Location = New System.Drawing.Point(318, 67)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 10
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "PrixUnitaire", True))
        Me.TextBox3.Location = New System.Drawing.Point(318, 115)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 11
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProduitBindingSource, "Stock", True))
        Me.TextBox4.Location = New System.Drawing.Point(318, 183)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 12
        '
        'BtnTerminer
        '
        Me.BtnTerminer.Location = New System.Drawing.Point(782, 279)
        Me.BtnTerminer.Name = "BtnTerminer"
        Me.BtnTerminer.Size = New System.Drawing.Size(75, 23)
        Me.BtnTerminer.TabIndex = 13
        Me.BtnTerminer.Text = "Terminer"
        Me.BtnTerminer.UseVisualStyleBackColor = True
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'BtnPrécédent
        '
        Me.BtnPrécédent.Location = New System.Drawing.Point(497, 218)
        Me.BtnPrécédent.Name = "BtnPrécédent"
        Me.BtnPrécédent.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrécédent.TabIndex = 14
        Me.BtnPrécédent.Text = "Précédent"
        Me.BtnPrécédent.UseVisualStyleBackColor = True
        '
        'BtnSuivant
        '
        Me.BtnSuivant.Location = New System.Drawing.Point(622, 218)
        Me.BtnSuivant.Name = "BtnSuivant"
        Me.BtnSuivant.Size = New System.Drawing.Size(75, 23)
        Me.BtnSuivant.TabIndex = 15
        Me.BtnSuivant.Text = "Suivant"
        Me.BtnSuivant.UseVisualStyleBackColor = True
        '
        'BtnEffacer
        '
        Me.BtnEffacer.Location = New System.Drawing.Point(773, 218)
        Me.BtnEffacer.Name = "BtnEffacer"
        Me.BtnEffacer.Size = New System.Drawing.Size(75, 23)
        Me.BtnEffacer.TabIndex = 16
        Me.BtnEffacer.Text = "Effacer"
        Me.BtnEffacer.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 314)
        Me.Controls.Add(Me.BtnEffacer)
        Me.Controls.Add(Me.BtnSuivant)
        Me.Controls.Add(Me.BtnPrécédent)
        Me.Controls.Add(Me.BtnTerminer)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnNouveau)
        Me.Controls.Add(Me.BtnSupprimer)
        Me.Controls.Add(Me.BtnModifier)
        Me.Controls.Add(Me.BtnAjouter)
        Me.Controls.Add(Me.BtnRecherche)
        Me.Name = "Form5"
        Me.Text = "Form5"
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FournisseurDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnRecherche As System.Windows.Forms.Button
    Friend WithEvents BtnAjouter As System.Windows.Forms.Button
    Friend WithEvents BtnModifier As System.Windows.Forms.Button
    Friend WithEvents BtnSupprimer As System.Windows.Forms.Button
    Friend WithEvents BtnNouveau As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents BtnTerminer As System.Windows.Forms.Button
    Friend WithEvents FournisseurDataSet As WindowsApplication1.FournisseurDataSet
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As WindowsApplication1.FournisseurDataSetTableAdapters.ProduitTableAdapter
    Friend WithEvents BtnPrécédent As System.Windows.Forms.Button
    Friend WithEvents BtnSuivant As System.Windows.Forms.Button
    Friend WithEvents BtnEffacer As System.Windows.Forms.Button
End Class
