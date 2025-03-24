Imports DevExpress.LookAndFeel

Public Class MainForm
    Private Async Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        LabelControl4.Text = $"Version: {Extras.GetAppVersion()}"
        If Extras.Aura.CheckForUpdateAtStartup = True Then
            If Await Extras.IsUpdateAvailable() = True Then
                If MessageBox.Show(caption:="New Update Available", text:="A newer version of this application is available now. Would you like to download it from our Github Release?", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Information) = DialogResult.Yes Then
                    Dim pros As New ProcessStartInfo() With {
                        .FileName = "https://github.com/Nothing-Just-a-Code/Aura-File-Transfer-Manager/releases",
                        .UseShellExecute = True}
                    Process.Start(pros)
                End If
            End If
        End If
    End Sub

    Private Sub SetConfig()
        If Extras.Aura.Theme = "Blue Velvet" Then
            ComboBoxEdit1.SelectedIndex = 0
        ElseIf Extras.Aura.Theme = "Cherry Ink" Then
            ComboBoxEdit1.SelectedIndex = 1
        End If
        runatstartup.IsOn = Extras.Aura.RunAtStartup
        checkforupdate.IsOn = Extras.Aura.CheckForUpdateAtStartup
        If Extras.Aura.IsFirstRun = True Then Process.Start(New ProcessStartInfo() With {.FileName = IO.Path.Combine(Application.StartupPath, "Aura Installer.exe"), .UseShellExecute = True})
        Me.useSK.IsOn = Extras.Aura.UseShortcutKeys
    End Sub
    Sub New()
        InitializeComponent()
        SetConfig()
    End Sub

    Private Async Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit1.SelectedIndexChanged
        If ComboBoxEdit1.SelectedIndex = 0 Then
            Extras.Aura.Theme = "Blue Velvet"
        ElseIf ComboBoxEdit1.SelectedIndex = 1 Then
            Extras.Aura.Theme = "Cherry Ink"
        Else
            Extras.Aura.Theme = "Blue Velvet"
        End If
        UserLookAndFeel.Default.SetSkinStyle("The Bezier", Extras.Aura.Theme)
        Await Extras.SaveOrWriteConfig()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim p As New Process() With {.StartInfo = New ProcessStartInfo("explorer.exe", Extras.LogsDir)}
        p.Start()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        For Each item As String In IO.Directory.GetFiles(Extras.LogsDir)
            IO.File.Delete(item)
        Next
    End Sub

    Private Async Sub ToggleSwitch1_Toggled(sender As Object, e As EventArgs) Handles runatstartup.Toggled
        If runatstartup.IsOn = True Then
            If Not Extras.Aura.RunAtStartup = True Then
                Extras.AddToStartup()
                Extras.Aura.RunAtStartup = True
                Await Extras.SaveOrWriteConfig()
            End If
        Else
            If Not Extras.Aura.RunAtStartup = False Then
                Extras.RemoveFromStartup()
                Extras.Aura.RunAtStartup = False
                Await Extras.SaveOrWriteConfig()
            End If
        End If
    End Sub

    Private Async Sub ToggleSwitch2_Toggled(sender As Object, e As EventArgs) Handles checkforupdate.Toggled
        If checkforupdate.IsOn = True Then
            If Not Extras.Aura.CheckForUpdateAtStartup = True Then
                Extras.Aura.CheckForUpdateAtStartup = True
                Await Extras.SaveOrWriteConfig
            End If
        Else
            If Not Extras.Aura.CheckForUpdateAtStartup = False Then
                Extras.Aura.CheckForUpdateAtStartup = False
                Await Extras.SaveOrWriteConfig
            End If
        End If
    End Sub

    Private Async Sub useSK_Toggled(sender As Object, e As EventArgs) Handles useSK.Toggled
        Dim val As Boolean = useSK.IsOn
        If val = True Then HookKeyboard() Else UnhookKeyboard()
            Extras.Aura.UseShortcutKeys = val
            Await Extras.SaveOrWriteConfig()
    End Sub

    Private Sub HookKeyboard()
        KeyboardHook.HookKeyboard()
        AddHandler KeyboardHook.KeyPressed, AddressOf OnKeyPressed
    End Sub

    Private Sub UnhookKeyboard()
        KeyboardHook.UnhookKeyboard()
        RemoveHandler KeyboardHook.KeyPressed, AddressOf OnKeyPressed
    End Sub

    Private Sub OnKeyPressed(vkCode As Integer)
        ' Check if Ctrl + Shift + V is pressed
        If Control.ModifierKeys = (Keys.Control Or Keys.Shift) AndAlso vkCode = Keys.V Then
            ' Run GetActiveExplorerFolder asynchronously to avoid COM issues
            Me.BeginInvoke(Sub()
                               Dim folderPath As String = FolderPathHelper.GetActiveExplorerFolder()
                               If IO.Directory.Exists(folderPath) Then
                                   Dim p As New ProcessStartInfo() With {
                                   .FileName = IO.Path.Combine(Application.StartupPath, "Aura Transfer.exe"),
                                   .Arguments = folderPath}
                                   Process.Start(p)
                               End If
                           End Sub)
        End If
    End Sub
End Class