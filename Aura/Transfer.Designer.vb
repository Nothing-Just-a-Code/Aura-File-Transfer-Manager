<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transfer
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Transfer))
        LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        FName = New DevExpress.XtraEditors.LabelControl()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        FSize = New DevExpress.XtraEditors.LabelControl()
        FoldersNames = New DevExpress.XtraEditors.LabelControl()
        LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(ProgressBarControl1.Properties, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LabelControl1
        ' 
        LabelControl1.Location = New Point(12, 14)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(49, 13)
        LabelControl1.TabIndex = 0
        LabelControl1.Text = "Filename:"
        ' 
        ' FName
        ' 
        FName.AutoEllipsis = True
        FName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        FName.Location = New Point(73, 14)
        FName.Name = "FName"
        FName.Size = New Size(343, 13)
        FName.TabIndex = 1
        FName.Text = "Filename:"
        ' 
        ' LabelControl2
        ' 
        LabelControl2.Location = New Point(12, 36)
        LabelControl2.Name = "LabelControl2"
        LabelControl2.Size = New Size(23, 13)
        LabelControl2.TabIndex = 2
        LabelControl2.Text = "Size:"
        ' 
        ' FSize
        ' 
        FSize.Location = New Point(73, 36)
        FSize.Name = "FSize"
        FSize.Size = New Size(49, 13)
        FSize.TabIndex = 3
        FSize.Text = "Filename:"
        ' 
        ' FoldersNames
        ' 
        FoldersNames.AllowHtmlString = True
        FoldersNames.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        FoldersNames.Location = New Point(73, 60)
        FoldersNames.Name = "FoldersNames"
        FoldersNames.Size = New Size(343, 13)
        FoldersNames.TabIndex = 5
        FoldersNames.Text = "Filename:"
        ' 
        ' LabelControl4
        ' 
        LabelControl4.Location = New Point(12, 60)
        LabelControl4.Name = "LabelControl4"
        LabelControl4.Size = New Size(41, 13)
        LabelControl4.TabIndex = 4
        LabelControl4.Text = "Folders:"
        ' 
        ' LabelControl3
        ' 
        LabelControl3.Location = New Point(73, 84)
        LabelControl3.Name = "LabelControl3"
        LabelControl3.Size = New Size(49, 13)
        LabelControl3.TabIndex = 7
        LabelControl3.Text = "Filename:"
        ' 
        ' LabelControl5
        ' 
        LabelControl5.Location = New Point(12, 84)
        LabelControl5.Name = "LabelControl5"
        LabelControl5.Size = New Size(35, 13)
        LabelControl5.TabIndex = 6
        LabelControl5.Text = "Speed:"
        ' 
        ' LabelControl6
        ' 
        LabelControl6.Location = New Point(73, 108)
        LabelControl6.Name = "LabelControl6"
        LabelControl6.Size = New Size(49, 13)
        LabelControl6.TabIndex = 9
        LabelControl6.Text = "Filename:"
        ' 
        ' LabelControl7
        ' 
        LabelControl7.Location = New Point(12, 108)
        LabelControl7.Name = "LabelControl7"
        LabelControl7.Size = New Size(48, 13)
        LabelControl7.TabIndex = 8
        LabelControl7.Text = "Time Left:"
        ' 
        ' ProgressBarControl1
        ' 
        ProgressBarControl1.Location = New Point(12, 147)
        ProgressBarControl1.Name = "ProgressBarControl1"
        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.ShowProgressInTaskBar = True
        ProgressBarControl1.Size = New Size(420, 18)
        ProgressBarControl1.TabIndex = 10
        ' 
        ' SimpleButton1
        ' 
        SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), Image)
        SimpleButton1.ImageOptions.SvgImageSize = New Size(16, 16)
        SimpleButton1.Location = New Point(294, 118)
        SimpleButton1.Name = "SimpleButton1"
        SimpleButton1.Size = New Size(66, 23)
        SimpleButton1.TabIndex = 11
        SimpleButton1.Text = "Pause"
        ' 
        ' SimpleButton2
        ' 
        SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), Image)
        SimpleButton2.ImageOptions.SvgImageSize = New Size(16, 16)
        SimpleButton2.Location = New Point(366, 118)
        SimpleButton2.Name = "SimpleButton2"
        SimpleButton2.Size = New Size(66, 23)
        SimpleButton2.TabIndex = 12
        SimpleButton2.Text = "Cancel"
        ' 
        ' Transfer
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(444, 177)
        ControlBox = False
        Controls.Add(SimpleButton2)
        Controls.Add(SimpleButton1)
        Controls.Add(ProgressBarControl1)
        Controls.Add(LabelControl6)
        Controls.Add(LabelControl7)
        Controls.Add(LabelControl3)
        Controls.Add(LabelControl5)
        Controls.Add(FoldersNames)
        Controls.Add(LabelControl4)
        Controls.Add(FSize)
        Controls.Add(LabelControl2)
        Controls.Add(FName)
        Controls.Add(LabelControl1)
        DoubleBuffered = True
        FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow
        FormBorderStyle = FormBorderStyle.FixedSingle
        HtmlText = "<b>Transfering File</b>  -  Aura File Transfer Manager"
        IconOptions.Icon = CType(resources.GetObject("Transfer.IconOptions.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Transfer"
        StartPosition = FormStartPosition.CenterScreen
        CType(ProgressBarControl1.Properties, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FoldersNames As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
