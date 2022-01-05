Imports System.Net
Imports System.IO
Public Class formUpdating
    Private Sub formUpdating_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = "Nova Folder Creator is updating." & vbCrLf & "Please do not restart or shutdown your system."
    End Sub

    Private Sub formUpdating_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ProgressBar1.MarqueeAnimationSpeed = 60
        ProgressBar1.Refresh()
        createTempDirectoryForUpdation()
        If System.IO.Directory.Exists("C:\" & "\.temp-nfcupdate") Then
            Dim fileReader As New WebClient()
            Label2.Text = "Downloading Update"
            If System.Environment.Is64BitOperatingSystem <> True Then
                fileReader.DownloadFile("http://www.cipher.hattangadi.com/cdn/novafoldercreator/updates/latest-x86.zip", "C:\" & "\.temp-nfcupdate\latest.zip")

            ElseIf System.Environment.Is64BitOperatingSystem = True Then
                fileReader.DownloadFile("http://www.cipher.hattangadi.com/cdn/novafoldercreator/updates/latest-x64.zip", "C:\" & "\.temp-nfcupdate\latest.zip")
            End If

            If System.IO.File.Exists("C:\" & "\.temp-nfcupdate\latest.zip") Then
                    unzipUpdateFiles("C:\" & "\.temp-nfcupdate\latest.zip", "C:\" & "\.temp-nfcupdate\extracted")
                End If
                Dim dirInfo As DirectoryInfo = New DirectoryInfo("C:\" & "\.temp-nfcupdate\extracted")
                If (dirInfo.EnumerateFiles().Any()) Then
                    Dim procStartInfo As New ProcessStartInfo
                    Dim procExecuting As New Process
                    With procStartInfo
                        .UseShellExecute = True
                        .FileName = Path.GetDirectoryName(Application.ExecutablePath) & "\NovaUpdater.exe"
                        .WindowStyle = ProcessWindowStyle.Normal
                        .Verb = "runas"
                    End With
                    procExecuting = Process.Start(procStartInfo)
                    'Process.Start(Path.GetDirectoryName(Application.ExecutablePath) & "\NovaUpdater.exe")
                    Application.Exit()
                    End

                End If
            Else
                MessageBox.Show("An error has occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class