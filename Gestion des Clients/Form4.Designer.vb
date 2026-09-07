<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.FournisseurDataSet1 = New WindowsApplication1.FournisseurDataSet()
        Me.CboProduit = New System.Windows.Forms.ComboBox()
        Me.LigneCommandeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.BtnRecherche = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BtnValider = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CommandeTableAdapter = New WindowsApplication1.FournisseurDataSetTableAdapters.CommandeTableAdapter()
        Me.BtnNouveau = New System.Windows.Forms.Button()
        Me.BtnAjouter = New System.Windows.Forms.Button()
        Me.BtnSupprimer = New System.Windows.Forms.Button()
        Me.BtnModier = New System.Windows.Forms.Button()
        Me.LigneCommandeTableAdapter = New WindowsApplication1.FournisseurDataSetTableAdapters.LigneCommandeTableAdapter()
        Me.ProduitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProduitTableAdapter = New WindowsApplication1.FournisseurDataSetTableAdapters.ProduitTableAdapter()
        Me.BtnTerminer = New System.Windows.Forms.Button()
        Me.BtnFacture = New System.Windows.Forms.Button()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FournisseurDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LigneCommandeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "idClient"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(162, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "DateCommande"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(162, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NumCommande"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "CommandeRegle", True))
        Me.CheckBox1.Location = New System.Drawing.Point(153, 143)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(103, 17)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "CommandePaye"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "Commande"
        Me.BindingSource1.DataSource = Me.FournisseurDataSet1
        '
        'FournisseurDataSet1
        '
        Me.FournisseurDataSet1.DataSetName = "FournisseurDataSet"
        Me.FournisseurDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CboProduit
        '
        Me.CboProduit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LigneCommandeBindingSource, "CodeProduit", True))
        Me.CboProduit.FormattingEnabled = True
        Me.CboProduit.Location = New System.Drawing.Point(147, 192)
        Me.CboProduit.Name = "CboProduit"
        Me.CboProduit.Size = New System.Drawing.Size(121, 21)
        Me.CboProduit.TabIndex = 4
        '
        'LigneCommandeBindingSource
        '
        Me.LigneCommandeBindingSource.DataMember = "LigneCommande"
        Me.LigneCommandeBindingSource.DataSource = Me.FournisseurDataSet1
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LigneCommandeBindingSource, "Quantite", True))
        Me.TextBox4.Location = New System.Drawing.Point(156, 240)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 5
        '
        'BtnRecherche
        '
        Me.BtnRecherche.Location = New System.Drawing.Point(206, 307)
        Me.BtnRecherche.Name = "BtnRecherche"
        Me.BtnRecherche.Size = New System.Drawing.Size(120, 23)
        Me.BtnRecherche.TabIndex = 6
        Me.BtnRecherche.Text = "RechercheCommande"
        Me.BtnRecherche.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(521, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(457, 150)
        Me.DataGridView1.TabIndex = 7
        '
        'BtnValider
        '
        Me.BtnValider.Location = New System.Drawing.Point(368, 143)
        Me.BtnValider.Name = "BtnValider"
        Me.BtnValider.Size = New System.Drawing.Size(107, 23)
        Me.BtnValider.TabIndex = 8
        Me.BtnValider.Text = "ValiderCommande"
        Me.BtnValider.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "NumCommande", True))
        Me.TextBox1.Location = New System.Drawing.Point(337, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 9
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "IdClient", True))
        Me.TextBox2.Location = New System.Drawing.Point(337, 56)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 10
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "DateCommande", True))
        Me.TextBox3.Location = New System.Drawing.Point(337, 89)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Quantite"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Produit"
        '
        'CommandeTableAdapter
        '
        Me.CommandeTableAdapter.ClearBeforeFill = True
        '
        'BtnNouveau
        '
        Me.BtnNouveau.Location = New System.Drawing.Point(23, 307)
        Me.BtnNouveau.Name = "BtnNouveau"
        Me.BtnNouveau.Size = New System.Drawing.Size(138, 23)
        Me.BtnNouveau.TabIndex = 17
        Me.BtnNouveau.Text = "NouvelleCommande"
        Me.BtnNouveau.UseVisualStyleBackColor = True
        '
        'BtnAjouter
        '
        Me.BtnAjouter.Location = New System.Drawing.Point(346, 307)
        Me.BtnAjouter.Name = "BtnAjouter"
        Me.BtnAjouter.Size = New System.Drawing.Size(107, 23)
        Me.BtnAjouter.TabIndex = 18
        Me.BtnAjouter.Text = "AjouterProduit"
        Me.BtnAjouter.UseVisualStyleBackColor = True
        '
        'BtnSupprimer
        '
        Me.BtnSupprimer.Location = New System.Drawing.Point(509, 307)
        Me.BtnSupprimer.Name = "BtnSupprimer"
        Me.BtnSupprimer.Size = New System.Drawing.Size(107, 23)
        Me.BtnSupprimer.TabIndex = 19
        Me.BtnSupprimer.Text = "Supprimer"
        Me.BtnSupprimer.UseVisualStyleBackColor = True
        '
        'BtnModier
        '
        Me.BtnModier.Location = New System.Drawing.Point(691, 307)
        Me.BtnModier.Name = "BtnModier"
        Me.BtnModier.Size = New System.Drawing.Size(114, 23)
        Me.BtnModier.TabIndex = 20
        Me.BtnModier.Text = "ModifierCommande"
        Me.BtnModier.UseVisualStyleBackColor = True
        '
        'LigneCommandeTableAdapter
        '
        Me.LigneCommandeTableAdapter.ClearBeforeFill = True
        '
        'ProduitBindingSource
        '
        Me.ProduitBindingSource.DataMember = "Produit"
        Me.ProduitBindingSource.DataSource = Me.FournisseurDataSet1
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'BtnTerminer
        '
        Me.BtnTerminer.Location = New System.Drawing.Point(856, 307)
        Me.BtnTerminer.Name = "BtnTerminer"
        Me.BtnTerminer.Size = New System.Drawing.Size(82, 23)
        Me.BtnTerminer.TabIndex = 21
        Me.BtnTerminer.Text = "terminer"
        Me.BtnTerminer.UseVisualStyleBackColor = True
        '
        'BtnFacture
        '
        Me.BtnFacture.Location = New System.Drawing.Point(368, 200)
        Me.BtnFacture.Name = "BtnFacture"
        Me.BtnFacture.Size = New System.Drawing.Size(107, 23)
        Me.BtnFacture.TabIndex = 22
        Me.BtnFacture.Text = "Facture"
        Me.BtnFacture.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 342)
        Me.Controls.Add(Me.BtnFacture)
        Me.Controls.Add(Me.BtnTerminer)
        Me.Controls.Add(Me.BtnModier)
        Me.Controls.Add(Me.BtnSupprimer)
        Me.Controls.Add(Me.BtnAjouter)
        Me.Controls.Add(Me.BtnNouveau)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnValider)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtnRecherche)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.CboProduit)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LigneCommandeBindingSource, "Quantite", True))
        Me.Name = "Form4"
        Me.Text = "COMMANDE"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FournisseurDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LigneCommandeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CboProduit As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents BtnRecherche As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnValider As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents FournisseurDataSet1 As WindowsApplication1.FournisseurDataSet
    Friend WithEvents CommandeTableAdapter As WindowsApplication1.FournisseurDataSetTableAdapters.CommandeTableAdapter
    Friend WithEvents BtnNouveau As System.Windows.Forms.Button
    Friend WithEvents BtnAjouter As System.Windows.Forms.Button
    Friend WithEvents BtnSupprimer As System.Windows.Forms.Button
    Friend WithEvents BtnModier As System.Windows.Forms.Button
    Friend WithEvents LigneCommandeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LigneCommandeTableAdapter As WindowsApplication1.FournisseurDataSetTableAdapters.LigneCommandeTableAdapter
    Friend WithEvents ProduitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As WindowsApplication1.FournisseurDataSetTableAdapters.ProduitTableAdapter
    Friend WithEvents BtnTerminer As System.Windows.Forms.Button
    Friend WithEvents BtnFacture As System.Windows.Forms.Button
End Class
