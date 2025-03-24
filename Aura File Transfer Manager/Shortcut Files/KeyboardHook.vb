Imports System.Runtime.InteropServices
Imports System.Diagnostics

Public Class KeyboardHook
    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_SYSKEYDOWN As Integer = &H104

    Private Shared hookID As IntPtr = IntPtr.Zero
    Private Shared hookCallback As LowLevelKeyboardProc = AddressOf HookFunc

    Public Delegate Function LowLevelKeyboardProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(idHook As Integer, lpfn As LowLevelKeyboardProc, hMod As IntPtr, dwThreadId As UInteger) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function UnhookWindowsHookEx(hhk As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function CallNextHookEx(hhk As IntPtr, nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function GetModuleHandle(lpModuleName As String) As IntPtr
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Private Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Public Shared Event KeyPressed(vkCode As Integer)

    Public Shared Sub HookKeyboard()
        hookID = SetWindowsHookEx(WH_KEYBOARD_LL, hookCallback, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0)
    End Sub

    Public Shared Sub UnhookKeyboard()
        If hookID <> IntPtr.Zero Then
            UnhookWindowsHookEx(hookID)
        End If
    End Sub

    Private Shared Function HookFunc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
        If nCode >= 0 AndAlso (wParam = CType(WM_KEYDOWN, IntPtr) OrElse wParam = CType(WM_SYSKEYDOWN, IntPtr)) Then
            Dim kbStruct As KBDLLHOOKSTRUCT = Marshal.PtrToStructure(Of KBDLLHOOKSTRUCT)(lParam)
            RaiseEvent KeyPressed(kbStruct.vkCode)
        End If
        Return CallNextHookEx(hookID, nCode, wParam, lParam)
    End Function
End Class
