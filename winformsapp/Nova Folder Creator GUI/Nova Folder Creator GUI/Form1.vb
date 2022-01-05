Imports System.Threading
Public Class Form1
    Dim CName As String = formClassName.ClassName
    Dim SList As String = formStudentsList.StudentsList



    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSelOptDir.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = folderDlg.SelectedPath
            Dim root As Environment.SpecialFolder = folderDlg.RootFolder
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        formStudentsList.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim optLoc As String = TextBox1.Text
        Dim mfc As String = "null"
        mfc = "/c " & "cd /d " & optLoc & " & md " & TextBox3.Text & " & explorer.exe ."
        'Shell("cmd.exe /c " & mfc)

        If (TextBox1.Text = "") Then
            MessageBox.Show("Output location not selected")

        ElseIf (TextBox3.Text = "") Then
            MessageBox.Show("You have not added the folders you would like to create.")
        Else
            Process.Start("cmd.exe", mfc)

        End If

    End Sub

    Private Sub Button2_DragEnter(sender As Object, e As DragEventArgs) Handles Button2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Button2_DragDrop(sender As Object, e As DragEventArgs) Handles Button2.DragDrop
        Dim filePath As String = e.Data.GetData(DataFormats.FileDrop)(0)
        Dim extension As String = Microsoft.VisualBasic.Right(filePath, 5)
        If (extension = ".nopr") Then
            TextBox3.Text = formStudentsList.formatList(formStudentsList.loadProfile(filePath))
        Else
            MessageBox.Show("Only Nova Profiles can be loaded", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub ManageProfilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageProfilesToolStripMenuItem.Click
        Process.Start("explorer.exe", Form2.path)
    End Sub

    Private Sub EditProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditProfileToolStripMenuItem.Click
        formManageProfiles.Show()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label2.Hide()
        TextBox1.Hide()
        Dim objWriter As New System.IO.StreamWriter(Form2.versionPath)
        objWriter.Write(My.Application.Info.Version.ToString)
        objWriter.Close()
        If Not usingLatestVersion() = True Then
            Dim result As DialogResult = MessageBox.Show("An update is available, would you like to update now", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                formUpdating.Show()
                Me.Dispose()
            End If

        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        frmTreeViewPreview.Show()
    End Sub
End Class
