Imports System.IO

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim extractedPath As String = "C:\" & "\.temp-nfcupdate\extracted"
        Dim appPath As String = Path.GetDirectoryName(Application.ExecutablePath)

        If Directory.Exists(extractedPath) Then
            ProgressBar1.PerformStep()
            Try
                Dim dirInfo As DirectoryInfo = New DirectoryInfo("C:\" & "\.temp-nfcupdate\extracted")
                If (dirInfo.EnumerateFiles().Any()) Then
                    ProgressBar1.PerformStep()

                    Try

                        ProgressBar1.PerformStep()
                        ProgressBar1.PerformStep()
                        ProgressBar1.PerformStep()
                        ProgressBar1.PerformStep()

                        For Each filename As String In IO.Directory.GetFiles(appPath, "Nova Folder Creator GUI*", IO.SearchOption.AllDirectories)
                            File.Delete(filename)
                        Next
                        System.Threading.Thread.Sleep(1000)
                        'File.Delete("C:\Program Files\Aarav Hattangadi\Nova Folder Creator\Nova Folder Creator GUI.exe")
                        Dim di As New DirectoryInfo(extractedPath)
                        Dim fiArr As FileInfo() = di.GetFiles()
                        For Each filename As String In IO.Directory.GetFiles(extractedPath, "*", IO.SearchOption.AllDirectories)
                            Dim extractedFileName As String = IO.Path.GetFileName(filename)
                            File.Move(filename, appPath & "\" & extractedFileName)
                        Next

                        ProgressBar1.PerformStep()
                        ProgressBar1.PerformStep()
                        ProgressBar1.PerformStep()
                        ProgressBar1.PerformStep()
                        Dim result As DialogResult = MessageBox.Show("Nova Folder Creator has successfully updated. Press OK to launch Nova Folder Creator", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        If result = DialogResult.OK Then
                            Directory.Delete("C:\.temp-nfcupdate", True)
                            Process.Start(appPath & "\Nova Folder Creator GUI.exe")
                            Me.Dispose()
                            End
                        End If
                    Catch ex As Exception
                        MessageBox.Show("An error has occured while trying to update Nova Folder Creator. ECB3" & vbCrLf & ex.ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Dispose()
                        End
                    End Try
                Else
                    MessageBox.Show("An error has occured while trying to update Nova Folder Creator. ECB2", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Dispose()
                    End
                End If
            Catch ex As Exception
                MessageBox.Show("An error has occured while trying to update Nova Folder Creator. ECB1" & vbCrLf & ex.ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Dispose()
                End
            End Try
        End If
    End Sub
End Class
