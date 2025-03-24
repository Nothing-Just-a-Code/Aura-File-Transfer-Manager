Imports System.Runtime.InteropServices
Imports SHDocVw ' Requires "Microsoft Internet Controls"
Imports Shell32 ' Requires "Microsoft Shell Controls and Automation"

Public Class FolderPathHelper
    <DllImport("user32.dll")>
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowThreadProcessId(hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    End Function

    ' Function to check if the foreground window is the Desktop
    Private Shared Function IsDesktopWindow(hwnd As IntPtr) As Boolean
        Dim shellWindows As New SHDocVw.ShellWindows()
        For Each window As SHDocVw.InternetExplorer In shellWindows
            If window.HWND = hwnd.ToInt32() Then
                ' If it matches an Explorer window, it's not the desktop
                Return False
            End If
        Next
        ' If no Explorer window matches, assume it's the Desktop
        Return True
    End Function

    Public Shared Function GetActiveExplorerFolder() As String
        Try
            Dim foregroundHwnd As IntPtr = GetForegroundWindow()
            Dim processId As Integer
            GetWindowThreadProcessId(foregroundHwnd, processId)

            ' Check if the foreground window is the Desktop
            If IsDesktopWindow(foregroundHwnd) Then
                Return Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            End If

            ' Otherwise, check for active File Explorer folders
            Dim shellWindows As New SHDocVw.ShellWindows()
            For Each window As SHDocVw.InternetExplorer In shellWindows
                If window.HWND = foregroundHwnd.ToInt32() Then
                    Dim document As Object = window.Document
                    If TypeOf document Is Shell32.IShellFolderViewDual Then
                        Dim folder As Shell32.IShellFolderViewDual = CType(document, Shell32.IShellFolderViewDual)
                        Return folder.Folder.Self.Path
                    End If
                End If
            Next
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try

        Return "Unknown Folder"
    End Function
End Class
