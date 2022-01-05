Imports System.IO
Imports System.Collections
Public Class formManageProfiles
    Dim PopupMenu As New ContextMenuStrip()

    Private Sub formEditProfilesvb_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListBox1.Items.AddRange(IO.Directory.GetFiles(Form2.path, "*.nopr*"))

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ContextMenuStrip1.Show(Cursor.Position)



    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        profileName = ListBox1.SelectedItem.ToString()
        If System.IO.File.Exists(profileName) Then
            'Process.Start("notepad.exe", profileName)
            Dim fileContents = formStudentsList.loadProfile(profileName)
            formEditProfile.Show()
            formEditProfile.TextBox1.Text = fileContents

        Else
            MessageBox.Show("The profile selected cannot be accessed. It may have been deleted, moved, or you may not have the necessary permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the profile?", "Delete profile", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            System.IO.File.Delete(ListBox1.SelectedItem.ToString())
            ListBox1.Items.Clear()
            ListBox1.Items.AddRange(IO.Directory.GetFiles(Form2.path, "*.nopr*"))


        Else
            MessageBox.Show("Operation cancelled")
        End If
    End Sub
End Class