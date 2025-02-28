<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        runatstartup = New DevExpress.XtraEditors.ToggleSwitch()
        LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        checkforupdate = New DevExpress.XtraEditors.ToggleSwitch()
        LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(runatstartup.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(checkforupdate.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(ComboBoxEdit1.Properties, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' runatstartup
        ' 
        runatstartup.Location = New Point(31, 40)
        runatstartup.Name = "runatstartup"
        runatstartup.Properties.AllowFocused = False
        runatstartup.Properties.OffText = "Disabled"
        runatstartup.Properties.OnText = "Enabled"
        runatstartup.Size = New Size(116, 21)
        runatstartup.TabIndex = 0
        ' 
        ' LabelControl1
        ' 
        LabelControl1.Location = New Point(21, 21)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(124, 13)
        LabelControl1.TabIndex = 1
        LabelControl1.Text = "Run at windows startup"
        ' 
        ' LabelControl2
        ' 
        LabelControl2.Location = New Point(21, 83)
        LabelControl2.Name = "LabelControl2"
        LabelControl2.Size = New Size(208, 13)
        LabelControl2.TabIndex = 2
        LabelControl2.Text = "Check for update when application start"
        ' 
        ' checkforupdate
        ' 
        checkforupdate.Location = New Point(31, 102)
        checkforupdate.Name = "checkforupdate"
        checkforupdate.Properties.AllowFocused = False
        checkforupdate.Properties.OffText = "Disabled"
        checkforupdate.Properties.OnText = "Enabled"
        checkforupdate.Size = New Size(116, 21)
        checkforupdate.TabIndex = 3
        ' 
        ' LabelControl3
        ' 
        LabelControl3.Location = New Point(21, 142)
        LabelControl3.Name = "LabelControl3"
        LabelControl3.Size = New Size(76, 13)
        LabelControl3.TabIndex = 4
        LabelControl3.Text = "Change Theme"
        ' 
        ' ComboBoxEdit1
        ' 
        ComboBoxEdit1.Location = New Point(31, 163)
        ComboBoxEdit1.Name = "ComboBoxEdit1"
        ComboBoxEdit1.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True
        ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        ComboBoxEdit1.Properties.Items.AddRange(New Object() {"Heaven", "Hell Fire"})
        ComboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        ComboBoxEdit1.Size = New Size(100, 20)
        ComboBoxEdit1.TabIndex = 5
        ' 
        ' LabelControl4
        ' 
        LabelControl4.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        LabelControl4.Location = New Point(488, 296)
        LabelControl4.Name = "LabelControl4"
        LabelControl4.Size = New Size(69, 13)
        LabelControl4.TabIndex = 6
        LabelControl4.Text = "Version: 0.0.0"
        ' 
        ' LabelControl5
        ' 
        LabelControl5.Location = New Point(21, 203)
        LabelControl5.Name = "LabelControl5"
        LabelControl5.Size = New Size(24, 13)
        LabelControl5.TabIndex = 7
        LabelControl5.Text = "Logs"
        ' 
        ' SimpleButton1
        ' 
        SimpleButton1.Location = New Point(21, 227)
        SimpleButton1.Name = "SimpleButton1"
        SimpleButton1.Size = New Size(75, 23)
        SimpleButton1.TabIndex = 8
        SimpleButton1.Text = "Open Logs"
        ' 
        ' SimpleButton2
        ' 
        SimpleButton2.Location = New Point(102, 227)
        SimpleButton2.Name = "SimpleButton2"
        SimpleButton2.Size = New Size(75, 23)
        SimpleButton2.TabIndex = 9
        SimpleButton2.Text = "Clear"
        ' 
        ' MainForm
        ' 
        Appearance.Options.UseFont = True
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(569, 321)
        Controls.Add(SimpleButton2)
        Controls.Add(SimpleButton1)
        Controls.Add(LabelControl5)
        Controls.Add(LabelControl4)
        Controls.Add(ComboBoxEdit1)
        Controls.Add(LabelControl3)
        Controls.Add(checkforupdate)
        Controls.Add(LabelControl2)
        Controls.Add(LabelControl1)
        Controls.Add(runatstartup)
        FormBorderStyle = FormBorderStyle.FixedSingle
        HtmlText = "Aura File Transfer Manager  -  <b>Control Panel</b>"
        IconOptions.Image = CType(resources.GetObject("MainForm.IconOptions.Image"), Image)
        MaximizeBox = False
        MinimizeBox = False
        Name = "MainForm"
        StartPosition = FormStartPosition.CenterScreen
        CType(runatstartup.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(checkforupdate.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(ComboBoxEdit1.Properties, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents runatstartup As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents checkforupdate As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
