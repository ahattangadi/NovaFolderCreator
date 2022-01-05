Imports System.Net
Imports System.IO
Imports System.IO.Compression

Module modMain
    Public profileName As String
    Public operatingSystem As String = My.Computer.Info.OSFullName
    Public latestVersionFile As String = "http://www.cipher.hattangadi.com/cdn/novafoldercreator/currentversion.txt"
    Public latestVersion As String

    Public Function HaveInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function

    Public Function checkServerVersion() As String
        Try
            Dim request = DirectCast(WebRequest.Create(latestVersionFile), HttpWebRequest)
            Dim response = DirectCast(request.GetResponse(), HttpWebResponse)
            Using sr As New StreamReader(response.GetResponseStream())
                Do While sr.Peek() >= 0
                    latestVersion = sr.ReadLine()
                Loop
            End Using

            Return latestVersion

        Catch
            Return "ERR"

        End Try
    End Function

    Public Function usingLatestVersion()

        If checkServerVersion() <> My.Application.Info.Version.ToString Then
            Return False
        Else
            Return True
        End If


    End Function

    Public Function createTempDirectoryForUpdation()
        Try
            Directory.CreateDirectory("C:\.temp-nfcupdate")
        Catch
            MessageBox.Show("An unhandled error has occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function unzipUpdateFiles(zipPath As String, extractionPath As String)
        Try
            ZipFile.ExtractToDirectory(zipPath, extractionPath)
            Return True

        Catch
            Return False

        End Try

    End Function


End Module
