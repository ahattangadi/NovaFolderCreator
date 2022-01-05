Public Class formEditProfile
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        formStudentsList.saveProfile(profileName, TextBox1.Text)
        formManageProfiles.Dispose()
        Me.Dispose()
    End Sub
End Class