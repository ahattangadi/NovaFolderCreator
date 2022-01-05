Imports System.IO
Public Class Form2
    Public user As String = Environment.UserName
    Public path As String = "C:\Users\" & user & "\Documents\Nova Folder Profiles"
    Public versionPath As String = path & "\Support Files\version.txt"
    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
        If Not Directory.Exists(path & "\Support Files") Then
            Directory.CreateDirectory(path & "\Support Files")
        End If
        If Not System.IO.File.Exists(versionPath) Then
            System.IO.File.Create(versionPath).Close()
        End If



    End Sub
End Class