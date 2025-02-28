Imports System.IO
Imports DevExpress.LookAndFeel

Public Class Transfer
    Private Conf As New AuraConfig()
    Private transferManager As New FileTransferManager()
    Private IsPaused As Boolean = False
    Sub New()
        InitializeComponent()
        If IO.File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aura File Transfer Manager", "Aura Config.json")) Then
            Conf = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AuraConfig)(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aura File Transfer Manager", "Aura Config.json")))
        End If
        If Conf IsNot Nothing Then
            UserLookAndFeel.Default.SetSkinStyle("The Bezier", Conf.Theme)
        End If
    End Sub

    Private Sub Transfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Dim args As String() = Environment.GetCommandLineArgs()
        If args.Length > 1 Then
            StartCopying()
        Else
            Process.GetCurrentProcess().Kill()
        End If
    End Sub

    Private Async Sub StartCopying()
        Try
            Dim clipboardData As IDataObject = Clipboard.GetDataObject()
            If clipboardData IsNot Nothing AndAlso clipboardData.GetDataPresent(DataFormats.FileDrop) Then
                Dim files() As String = CType(clipboardData.GetData(DataFormats.FileDrop), String())

                If files.Length > 0 Then
                    Dim destination As String = Environment.GetCommandLineArgs(1) ' Change as needed
                    Dim progressHandler As New Progress(Of TransferProgress)(Sub(data)
                                                                                 FName.Text = data.Filename
                                                                                 FSize.Text = data.FileSize
                                                                                 LabelControl3.Text = data.TransferSpeed
                                                                                 Me.FoldersNames.Text = $"From <b>{data.DirectoryName}</b> to <b>{Path.GetFileName(Path.GetDirectoryName(Environment.GetCommandLineArgs(1)))}</b>"
                                                                                 LabelControl6.Text = data.ETA
                                                                                 ProgressBarControl1.Position = data.ProgressPercentage
                                                                                 Me.HtmlText = $"{data.ProgressPercentage}%  <b>Transfering File</b>  -  Aura File Transfer Manager"
                                                                             End Sub)

                    ' Hook into transfer completion event
                    AddHandler transferManager.TransferCompleted, New FileTransferManager.TransferCompletedEventHandler(Sub()
                                                                                                                            If Conf.SaveLogs = True Then
                                                                                                                                If Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aura File Transfer Manager", "Logs")) Then
                                                                                                                                    Dim str As New Text.StringBuilder()
                                                                                                                                    str.AppendLine("File Transfer started at: " & DateTime.Now.ToString())
                                                                                                                                    str.AppendLine("File(s) Copied:")
                                                                                                                                    str.AppendLine(String.Join(Environment.NewLine, files))
                                                                                                                                    str.AppendLine($"Into the Directory: " & Environment.GetCommandLineArgs(1))
                                                                                                                                    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aura File Transfer Manager", "Logs", "File Transfer Completed_" & New Random().Next(1111, 9999).ToString() & ".txt"), str.ToString(), System.Text.Encoding.UTF8)
                                                                                                                                End If
                                                                                                                            End If
                                                                                                                        End Sub)

                    ' Start Transfer
                    Await transferManager.StartTransferAsync(files, destination, progressHandler)
                End If
            Else

            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Application.Exit()
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If IsPaused = False Then
            transferManager.Pause()
            IsPaused = True
            SimpleButton1.Text = "Resume"
        ElseIf IsPaused = True Then
            transferManager.ResumeTransfer()
            IsPaused = False
            SimpleButton1.Text = "Pause"
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        transferManager.Cancel()
    End Sub

    Public Shared Function FormatBytes(bytes As Double) As String
        Dim sizes As String() = {"Bytes", "KB", "MB", "GB", "TB"}
        Dim order As Integer = 0

        While bytes >= 1024 AndAlso order < sizes.Length - 1
            order += 1
            bytes /= 1024
        End While

        Return $"{bytes:0.##} {sizes(order)}"
    End Function
End Class