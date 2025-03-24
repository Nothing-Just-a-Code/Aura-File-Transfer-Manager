Imports System.IO
Imports System.Net
Public Class Extras
    Public Shared MainDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aura File Transfer Manager")
    Public Shared LogsDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aura File Transfer Manager", "Logs")
    Public Shared Aura As New AuraConfig()
    Public Shared Async Sub Init()
        If Not Directory.Exists(MainDir) Then Directory.CreateDirectory(MainDir)
        If Not Directory.Exists(LogsDir) Then Directory.CreateDirectory(LogsDir)
        Await ReadConfig()
    End Sub

    Private Shared Async Function ReadConfig() As Task
        Try
            If Not File.Exists(Path.Combine(MainDir, "Aura Config.json")) Then Await SaveOrWriteConfig()
            Dim jsn As String = Await File.ReadAllTextAsync(Path.Combine(MainDir, "Aura Config.json"), System.Text.Encoding.UTF8)
            Aura = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AuraConfig)(jsn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Shared Async Function SaveOrWriteConfig() As Task
        Try
            Await File.WriteAllTextAsync(Path.Combine(MainDir, "Aura Config.json"), Newtonsoft.Json.JsonConvert.SerializeObject(Aura, Newtonsoft.Json.Formatting.Indented), System.Text.Encoding.UTF8)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Shared Function GetAppVersion() As String
        Return $"{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}"
    End Function

    Public Shared Sub AddToStartup()
        Try
            Dim startupPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
            Dim shortcutPath As String = Path.Combine(startupPath, "Aura File Transfer Manager.lnk")
            Dim appPath As String = Application.ExecutablePath

            ' Create shortcut using WScript.Shell
            Dim shell As Object = CreateObject("WScript.Shell")
            Dim shortcut As Object = shell.CreateShortcut(shortcutPath)
            shortcut.TargetPath = appPath
            shortcut.Save()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub RemoveFromStartup()
        Try
            Dim startupPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
            Dim shortcutPath As String = Path.Combine(startupPath, "Aura File Transfer Manager.lnk")

            If File.Exists(shortcutPath) Then
                File.Delete(shortcutPath)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Async Function IsUpdateAvailable() As Task(Of Boolean)
        Using http As New Net.Http.HttpClient()
            Dim resp = Await http.GetAsync("https://raw.githubusercontent.com/Nothing-Just-a-Code/Aura-File-Transfer-Manager/refs/heads/main/update.json")
            If resp.IsSuccessStatusCode Then
                Dim jsn As String = Await resp.Content.ReadAsStringAsync()
                Dim ver As String = Newtonsoft.Json.Linq.JObject.Parse(jsn)("version").ToString()
                If GetAppVersion() = ver Then
                    Return False
                Else
                    Return True
                End If
            Else
                Throw New ArgumentException("Unable to check for update at this moment. Please try again later.")
            End If
        End Using
    End Function

End Class
