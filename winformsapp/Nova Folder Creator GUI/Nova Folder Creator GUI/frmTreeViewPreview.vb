Imports System.IO
Public Class frmTreeViewPreview
    Private Sub frmTreeViewPreview_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim directory = New DirectoryInfo(Form1.TextBox1.Text).Name()
        Dim node As String = directory
        Dim childrenTMP As String = Form1.TextBox3.Text
        Dim result() As String
        result = childrenTMP.Split(" ", StringSplitOptions.RemoveEmptyEntries)
        Dim mainFolderNode As TreeNode = TreeView1.Nodes.Add(directory)
        For i = 0 To result.GetUpperBound(0)
            mainFolderNode.Nodes.Add(result(i))
            'MessageBox.Show(childrenTMP, "ERR")
        Next
        TreeView1.ExpandAll()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class