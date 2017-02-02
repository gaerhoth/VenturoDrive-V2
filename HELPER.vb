Imports Google.Apis.Drive.v2.Data
Imports System
Imports System.Collections.Generic
Imports Google.Apis.Drive.v2

'Namespace Drive.api
Public Class HELPER

    ''' <summary>
    ''' Download a file
    ''' Documentation: https://developers.google.com/drive/v2/reference/files/get
    ''' </summary>
    ''' <param name="_service">a Valid authenticated DriveService</param>
    ''' <param name="_fileResource">File resource of the file to download</param>
    ''' <param name="_saveTo">location of where to save the file including the file name to save it as.</param>
    ''' <returns></returns>
    Public Shared Function downloadFile(_service As DriveService, _fileResource As File, _saveTo As String) As [Boolean]

            If Not [String].IsNullOrEmpty(_fileResource.DownloadUrl) Then
                Try
                    Dim x = _service.HttpClient.GetByteArrayAsync(_fileResource.DownloadUrl)
                    Dim arrBytes As Byte() = x.Result
                    System.IO.File.WriteAllBytes(_saveTo, arrBytes)
                    Return True
                Catch e As Exception
                    Console.WriteLine("An error occurred: " + e.Message)
                    Return False
                End Try
            Else
                ' The file doesn't have any content stored on Drive.
                Return False
            End If
        End Function


        Private Shared Function GetMimeType(fileName As String) As String
            Dim mimeType As String = "application/unknown"
            Dim ext As String = System.IO.Path.GetExtension(fileName).ToLower()
            Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext)
            If regKey IsNot Nothing AndAlso regKey.GetValue("Content Type") IsNot Nothing Then
                mimeType = regKey.GetValue("Content Type").ToString()
            End If
            Return mimeType
        End Function

        ''' <summary>
        ''' Uploads a file
        ''' Documentation: https://developers.google.com/drive/v2/reference/files/insert
        ''' </summary>
        ''' <param name="_service">a Valid authenticated DriveService</param>
        ''' <param name="_uploadFile">path to the file to upload</param>
        ''' <param name="_parent">Collection of parent folders which contain this file. 
        '''                       Setting this field will put the file in all of the provided folders. root folder.</param>
        ''' <returns>If upload succeeded returns the File resource of the uploaded file 
        '''          If the upload fails returns null</returns>
        Public Shared Function uploadFile(_service As DriveService, _uploadFile As String, _parent As String) As File

            If System.IO.File.Exists(_uploadFile) Then
                Dim body As New File()
                body.Title = System.IO.Path.GetFileName(_uploadFile)
                body.Description = "File uploaded by Diamto Drive Sample"
                body.MimeType = GetMimeType(_uploadFile)
                body.Parents = New List(Of ParentReference)() From {
                    New ParentReference() With {
                        .Id = _parent
                    }
                }

                ' File's content.
                Dim byteArray As Byte() = System.IO.File.ReadAllBytes(_uploadFile)
                Dim stream As New System.IO.MemoryStream(byteArray)
                Try
                    Dim request As FilesResource.InsertMediaUpload = _service.Files.Insert(body, stream, GetMimeType(_uploadFile))
                    'request.Convert = true;   // uncomment this line if you want files to be converted to Drive format
                    request.Upload()
                    Return request.ResponseBody
                Catch e As Exception
                    Console.WriteLine("An error occurred: " + e.Message)
                    Return Nothing
                End Try
            Else
                Console.WriteLine(Convert.ToString("File does not exist: ") & _uploadFile)
                Return Nothing
            End If

        End Function

        ''' <summary>
        ''' Updates a file
        ''' Documentation: https://developers.google.com/drive/v2/reference/files/update
        ''' </summary>
        ''' <param name="_service">a Valid authenticated DriveService</param>
        ''' <param name="_uploadFile">path to the file to upload</param>
        ''' <param name="_parent">Collection of parent folders which contain this file. 
        '''                       Setting this field will put the file in all of the provided folders. root folder.</param>
        ''' <param name="_fileId">the resource id for the file we would like to update</param>                      
        ''' <returns>If upload succeeded returns the File resource of the uploaded file 
        '''          If the upload fails returns null</returns>
        Public Shared Function updateFile(_service As DriveService, _uploadFile As String, _parent As String, _fileId As String) As File

            If System.IO.File.Exists(_uploadFile) Then
                Dim body As New File()
                body.Title = System.IO.Path.GetFileName(_uploadFile)
                body.Description = "File updated by Diamto Drive Sample"
                body.MimeType = GetMimeType(_uploadFile)
                body.Parents = New List(Of ParentReference)() From {
                    New ParentReference() With {
                        .Id = _parent
                    }
                }

                ' File's content.
                Dim byteArray As Byte() = System.IO.File.ReadAllBytes(_uploadFile)
                Dim stream As New System.IO.MemoryStream(byteArray)
                Try
                    Dim request As FilesResource.UpdateMediaUpload = _service.Files.Update(body, _fileId, stream, GetMimeType(_uploadFile))
                    request.Upload()
                    Return request.ResponseBody
                Catch e As Exception
                    Console.WriteLine("An error occurred: " + e.Message)
                    Return Nothing
                End Try
            Else
                Console.WriteLine(Convert.ToString("File does not exist: ") & _uploadFile)
                Return Nothing
            End If

        End Function


        ''' <summary>
        ''' Create a new Directory.
        ''' Documentation: https://developers.google.com/drive/v2/reference/files/insert
        ''' </summary>
        ''' <param name="_service">a Valid authenticated DriveService</param>
        ''' <param name="_title">The title of the file. Used to identify file or folder name.</param>
        ''' <param name="_description">A short description of the file.</param>
        ''' <param name="_parent">Collection of parent folders which contain this file. 
        '''                       Setting this field will put the file in all of the provided folders. root folder.</param>
        ''' <returns></returns>
        Public Shared Function createDirectory(_service As DriveService, _title As String, _description As String, _parent As String) As File

            Dim NewDirectory As File = Nothing

            ' Create metaData for a new Directory
            Dim body As New File()
            body.Title = _title
            body.Description = _description
            body.MimeType = "application/vnd.google-apps.folder"
            body.Parents = New List(Of ParentReference)() From {
                New ParentReference() With {
                    .Id = _parent
                }
            }
            Try
                Dim request As FilesResource.InsertRequest = _service.Files.Insert(body)
                NewDirectory = request.Execute()
            Catch e As Exception
                Console.WriteLine("An error occurred: " + e.Message)
            End Try

            Return NewDirectory
        End Function


        ''' <summary>
        ''' List all of the files and directories for the current user.  
        ''' 
        ''' Documentation: https://developers.google.com/drive/v2/reference/files/list
        ''' Documentation Search: https://developers.google.com/drive/web/search-parameters
        ''' </summary>
        ''' <param name="service">a Valid authenticated DriveService</param>        
        ''' <param name="search">if Search is null will return all files</param>        
        ''' <returns></returns>
        Public Shared Function GetFiles(service As DriveService, search As String) As IList(Of File)

            Dim Files As IList(Of File) = New List(Of File)()

            Try
                'List all of the files and directories for the current user.  
                ' Documentation: https://developers.google.com/drive/v2/reference/files/list
                Dim list As FilesResource.ListRequest = service.Files.List()
                list.MaxResults = 1000
                If search IsNot Nothing Then
                    list.Q = search
                End If
                Dim filesFeed As FileList = list.Execute()


                While filesFeed.Items IsNot Nothing
                    ' Adding each item  to the list.
                    For Each item As File In filesFeed.Items
                        Files.Add(item)
                    Next

                    ' We will know we are on the last page when the next page token is
                    ' null.
                    ' If this is the case, break.
                    If filesFeed.NextPageToken Is Nothing Then
                        Exit While
                    End If

                    ' Prepare the next page of results
                    list.PageToken = filesFeed.NextPageToken

                    ' Execute and process the next page request
                    filesFeed = list.Execute()
                End While
            Catch ex As Exception
                ' In the event there is an error with the request.
                Console.WriteLine(ex.Message)
            End Try
            Return Files
        End Function


    End Class
'End Namespace