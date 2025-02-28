Imports System
Imports System.IO
Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.Win32
Module Program
    Private Conf As New AuraConfig()
    Sub Main(args As String())
        Console.Title = "Aura File Transfer Manager Installing"
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("Aura File Transfer Manager")
        StartUp.GetAwaiter().GetResult()
    End Sub

    Private Async Function StartUp() As Task
        Await Task.Run(Sub()
                           Console.ForegroundColor = ConsoleColor.Cyan
                           Console.WriteLine("> Setting up registry to enable context menu for you.")
                           Conf = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AuraConfig)(IO.File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aura File Transfer Manager", "Aura Config.json")))
                           CreateRegistry()
                       End Sub)
    End Function

    Private Sub CreateRegistry()
        Try
            ' Registry paths for Windows 11 Explorer context menu
            Dim shellKey As String = "HKEY_CLASSES_ROOT\Directory\Background\shell\Aura File Transfer Manager"
            Dim commandKey As String = "HKEY_CLASSES_ROOT\Directory\Background\shell\Aura File Transfer Manager\command"

            ' Set menu name (appears in right-click menu)
            Registry.SetValue(shellKey, "", "Transfer with Aura")

            ' Force it to appear in the new Windows 11 context menu
            Registry.SetValue(shellKey, "ExtendedSubCommandsKey", "")

            ' Set icon (optional)
            Registry.SetValue(shellKey, "Icon", IO.Path.Combine(AppContext.BaseDirectory, "Aura.exe"))

            ' Set the command to execute your application with the folder path
            Dim appPath As String = IO.Path.Combine(AppContext.BaseDirectory, "Aura Transfer.exe")
            Registry.SetValue(commandKey, "", """" & appPath & """ ""%V""")
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine($"> Setting registry completed.")
            Conf.IsFirstRun = False
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aura File Transfer Manager", "Aura Config.json"), Newtonsoft.Json.JsonConvert.SerializeObject(Conf, Newtonsoft.Json.Formatting.Indented), System.Text.Encoding.UTF8)
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine($"> {ex.Message}")
        End Try
    End Sub
End Module
