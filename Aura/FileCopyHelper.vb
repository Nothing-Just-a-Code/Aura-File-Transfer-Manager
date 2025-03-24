Imports System.IO
Imports System.Diagnostics
Imports System.Threading.Tasks
Imports System.Text.RegularExpressions

Public Class FileTransferManager
    Private fileQueue As New Queue(Of String)()
    Private sourceBasePath As String = ""
    Private destinationPath As String = ""
    Private totalBytes As Long = 0
    Private bytesTransferred As Long = 0
    Private stopwatch As New Stopwatch()
    Private paused As Boolean = False
    Private cancelled As Boolean = False

    ' Event to notify transfer completion
    Public Event TransferCompleted()

    Public Async Function StartTransferAsync(sourceFiles As String(), destination As String, progress As IProgress(Of TransferProgress)) As Task
        destinationPath = destination
        fileQueue.Clear()
        totalBytes = 0
        bytesTransferred = 0
        sourceBasePath = Path.GetDirectoryName(sourceFiles(0))

        ' Enqueue all files/folders and calculate total size
        For Each file In sourceFiles
            EnqueueFiles(file)
        Next

        cancelled = False
        paused = False
        stopwatch.Restart()

        Await ProcessFilesAsync(progress)

        stopwatch.Stop()
        RaiseEvent TransferCompleted()
    End Function

    Private Sub EnqueueFiles(path As String)
        If File.Exists(path) Then
            fileQueue.Enqueue(path)
            totalBytes += New FileInfo(path).Length
        ElseIf Directory.Exists(path) Then
            fileQueue.Enqueue(path)
            For Each file In Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                fileQueue.Enqueue(file)
                totalBytes += New FileInfo(file).Length
            Next
        End If
    End Sub

    Private Async Function ProcessFilesAsync(progress As IProgress(Of TransferProgress)) As Task
        Await Task.Run(Async Function()
                           While fileQueue.Count > 0
                               If cancelled Then Exit While

                               ' Pause handling
                               While paused
                                   If cancelled Then Exit While
                                   Await Task.Delay(100)
                               End While

                               If cancelled Then Exit While

                               Dim currentItem As String = fileQueue.Dequeue()
                               Dim relativePath As String = currentItem.Substring(sourceBasePath.Length).TrimStart(Path.DirectorySeparatorChar)
                               Dim targetPath As String = Path.Combine(destinationPath, relativePath)

                               Try
                                   If Directory.Exists(currentItem) Then
                                       If Not Directory.Exists(targetPath) Then Directory.CreateDirectory(targetPath)
                                   ElseIf File.Exists(currentItem) Then
                                       Dim fileSize As Long = New FileInfo(currentItem).Length
                                       Directory.CreateDirectory(Path.GetDirectoryName(targetPath))
                                       Await CopyFileWithProgressAsync(currentItem, targetPath, fileSize, progress)
                                   End If
                               Catch ex As Exception
                                   Throw New ArgumentException(ex.Message, ex)
                               End Try
                           End While
                       End Function)
    End Function

    Private Async Function CopyFileWithProgressAsync(source As String, destination As String, fileSize As Long, progress As IProgress(Of TransferProgress)) As Task
        Const bufferSize As Integer = 4096
        Dim buffer(bufferSize - 1) As Byte
        destination = GetUniqueFileName(destination)

        Using sourceStream As New FileStream(source, FileMode.Open, FileAccess.Read)
            Using destinationStream As New FileStream(destination, FileMode.Create, FileAccess.Write)
                Dim bytesRead As Integer
                Dim startTime As Long = stopwatch.ElapsedMilliseconds

                Do
                    bytesRead = Await sourceStream.ReadAsync(buffer, 0, buffer.Length)
                    If bytesRead > 0 Then
                        Await destinationStream.WriteAsync(buffer, 0, bytesRead)
                        bytesTransferred += bytesRead
                    End If

                    ' Progress calculations
                    Dim progressPercent As Integer = CInt((bytesTransferred / totalBytes) * 100)
                    Dim elapsedSeconds As Double = stopwatch.Elapsed.TotalSeconds
                    Dim speed As Double = If(elapsedSeconds > 0, bytesTransferred / elapsedSeconds / (1024 * 1024), 0) ' MB/s
                    Dim remainingTime As Double = If(speed > 0, (totalBytes - bytesTransferred) / (speed * 1024 * 1024), 0) ' Seconds

                    ' Update progress UI
                    progress.Report(New TransferProgress() With {
                                    .ETA = TimeSpan.FromSeconds(remainingTime).ToString("hh\:mm\:ss"),
                                    .Filename = Path.GetFileName(source),
                                    .FileSize = ConvertFileSize(New FileInfo(source).Length),
                                    .TransferSpeed = $"{speed:F2} MB/s",
                                    .DirectoryName = Path.GetFileName(Path.GetDirectoryName(source)),
                                    .ProgressPercentage = progressPercent})

                Loop While bytesRead > 0 AndAlso Not cancelled
            End Using
        End Using
    End Function

    ' Controls for Pause and Cancel
    Public Sub Pause()
        paused = True
    End Sub

    Public Sub ResumeTransfer()
        paused = False
    End Sub

    Public Sub Cancel()
        cancelled = True
        fileQueue.Clear()
    End Sub

    Public Shared Function ConvertFileSize(ByVal bytes As Long) As String
        Dim sizes As String() = {"B", "KB", "MB", "GB", "TB"}
        Dim index As Integer = 0
        Dim size As Double = bytes

        While size >= 1024 AndAlso index < sizes.Length - 1
            size /= 1024
            index += 1
        End While

        Return $"{size:0.##} {sizes(index)}"
    End Function

    Private Function GetUniqueFileName(filePath As String) As String
        Dim directory As String = Path.GetDirectoryName(filePath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(filePath)
        Dim extension As String = Path.GetExtension(filePath)

        Dim counter As Integer = 1
        Dim newFilePath As String = Path.Combine(directory, $"{fileName}{extension}")

        ' Check if the file exists, and keep increasing the counter until a unique name is found
        While File.Exists(newFilePath)
            newFilePath = Path.Combine(directory, $"{fileName} ({counter}){extension}")
            counter += 1
        End While

        Return newFilePath
    End Function




End Class

Public Class TransferProgress
    Public Property Filename As String
    Public Property FileSize As String
    Public Property TransferSpeed As String
    Public Property ETA As String
    Public Property DirectoryName As String
    Public Property ProgressPercentage As Integer
End Class
