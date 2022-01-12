Imports System.IO
Imports System.Text.RegularExpressions

Public Class formStudentsList
    Public StudentsList As String = "null"

    Public Function loadProfile(filePath As String)
        Using reader As StreamReader = New StreamReader(filePath)
            Dim contents As String = reader.ReadToEnd
            Return contents
        End Using
    End Function

    Public Function saveProfile(filePath As String, fileContents As String)
        Dim objWriter As New System.IO.StreamWriter(filePath)
        objWriter.Write(fileContents)
        objWriter.Close()
        If System.IO.File.Exists(filePath) = True Then
            MessageBox.Show("Profile has been created")
            Return True
        Else
            MessageBox.Show("An error has occured")
            Return False
        End If
    End Function

    Public Function formatList(list As String)
        Dim temp As String = list.Replace(" ", "_")
        Dim final As String = temp.Replace(vbCrLf, " ")
        Return final
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.TextBox3.Text = formatList(TextBox1.Text)
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Title = "Select Nova Profile to be loaded"
        OpenFileDialog1.Filter = "Nova Profiles|*.nopr"
        OpenFileDialog1.InitialDirectory = Form2.path
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            'Using reader As StreamReader = New StreamReader(OpenFileDialog1.FileName)
            '    Dim contents As String = reader.ReadToEnd
            '    TextBox1.Text = contents
            'End Using
            TextBox1.Text = loadProfile(OpenFileDialog1.FileName)
            Form1.TextBox3.Text = formatList(TextBox1.Text)
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveFileDialog1.Title = "Save Nova Profile"
        SaveFileDialog1.Filter = "Nova Profiles|*.nopr"
        SaveFileDialog1.InitialDirectory = Form2.path
        If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            If (TextBox1.Text <> "") Then
                'Dim objWriter As New System.IO.StreamWriter(SaveFileDialog1.FileName)
                'objWriter.Write(TextBox1.Text)
                'objWriter.Close()
                'If System.IO.File.Exists(SaveFileDialog1.FileName) = True Then
                '    MessageBox.Show("Profile has been created")
                'Else
                '    MessageBox.Show("An error has occured")
                'End If
                'StudentsList = TextBox1.Text
                'Dim tempString = StudentsList.Replace(" ", "_")
                'Dim FSL As String = tempString.Replace(vbCrLf, " ")
                'MessageBox.Show("Folders being created: " & FSL)
                'Form1.TextBox3.Text = FSL
                saveProfile(SaveFileDialog1.FileName, TextBox1.Text)
                Form1.TextBox3.Text = formatList(TextBox1.Text)
                Me.Close()

            Else
                MessageBox.Show("A blank profile cannot be saved")
            End If
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
            TextBox1.Text = loadProfile(filePath)
            Form1.TextBox3.Text = formatList(TextBox1.Text)
            Me.Close()
        Else
            MessageBox.Show("Only Nova Profiles can be loaded", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox1_textChanged(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        'Dim errorcounter As Short = 0

        'If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
        '    e.Handled = False

        'Else
        '    Interaction.Beep()
        '    errorcounter = errorcounter + 1
        '    If (errorcounter > 3) Then
        '        MessageBox.Show("Special characters are not allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'End If

        'Dim regex As New Regex("[^a-zA-Z0-9\s[\b]]")
        'If (regex.IsMatch(e.KeyChar.ToString())) Then
        '    e.Handled = True
        '    Interaction.Beep()
        'End If

        e.Handled = e.KeyChar <> ChrW(Keys.Back) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar) And Not Char.IsDigit(e.KeyChar)

    End Sub
End Class