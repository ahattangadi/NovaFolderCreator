Public Class formClassName
    Public ClassName As String = "Default CLass Name"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ClassName = TextBox1.Text
        'Form1.TextBox2.Text = ClassName
        Me.Close()
    End Sub



End Class