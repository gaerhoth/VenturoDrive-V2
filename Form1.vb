Imports System.Threading
Imports System.Threading.Tasks

Imports Google
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v2
Imports Google.Apis.Drive.v2.Data
Imports Google.Apis.Services

Imports Google.Apis.Auth
Imports Google.Apis.Download
Imports System.IO

Public Class VentuDrive
    Public DIR_FOTOS As String
    Dim begreen As Boolean = True

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateService()
    End Sub

    Private Service As DriveService = New DriveService

    Private Sub CreateService()

        Dim ClientId = "517228978970-0ohd9912k4v2v5ul6colclscgkfjvmeb.apps.googleusercontent.com"
        Dim ClientSecret = "xw_ZQEWOXZVzR5D-E1kNvi-m"
        Dim MyUserCredential As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With {.ClientId = ClientId, .ClientSecret = ClientSecret}, {DriveService.Scope.Drive}, "user", CancellationToken.None).Result
        Service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = MyUserCredential, .ApplicationName = "Google Drive VB Dot Net"})

    End Sub


    Private Sub CrearDirectorio()

        Dim direct As String
        direct = txtcreardir.Text

        Dim Q As String = "title = '" & direct & "' and mimeType = 'application/vnd.google-apps.folder'"

        Dim _FILES As List(Of Google.Apis.Drive.v2.Data.File)
        'LISTAR
        _FILES = HELPER.GetFiles(Service, Q)

        If (_FILES.Count = 0) Then
            ' Con esto creamos un directorio
            '_FILES.Add(HELPER.createDirectory(Service, "" & direct & "", "" & direct & "", "root/d1"))
            _FILES.Add(HELPER.createDirectory(Service, "" & direct & "", "" & direct & "", "root"))
        End If


    End Sub

    Private Sub UploadFile2(FilePath As String)



        Dim Q As String = "title = 'VENTURO2Sample' and mimeType = 'application/vnd.google-apps.folder'"

        Dim _FILES As List(Of Google.Apis.Drive.v2.Data.File)
        'LISTAR
        _FILES = HELPER.GetFiles(Service, Q)

        If (_FILES.Count = 0) Then
            ' Con esto creamos un directorio
            _FILES.Add(HELPER.createDirectory(Service, "VENTURO2Sample", "VENTURO2Sample", "root"))
        End If

        Dim directoryId As String
        directoryId = _FILES(0).Id

        Dim NEWFILE As Google.Apis.Drive.v2.Data.File
        NEWFILE = HELPER.uploadFile(Service, "c:\a.pdf", directoryId)


        MsgBox("Upload Finished")
    End Sub

    Private Sub DownloadFile(url As String, DownloadDir As String)
        Me.Cursor = Cursors.WaitCursor
        If Service.ApplicationName <> "Google Drive VB Dot Net" Then CreateService()

        Dim Downloader = New MediaDownloader(Service)
        Downloader.ChunkSize = 256 * 1024 '256 KB

        ' figure out the right file type base on UploadFileName extension
        Dim Filename = DownloadDir & "NewDoc.txt"
        Using FileStream = New System.IO.FileStream(Filename, System.IO.FileMode.Create, System.IO.FileAccess.Write)
            Dim Progress = Downloader.DownloadAsync(url, FileStream)
            Threading.Thread.Sleep(1000)
            Do While Progress.Status = TaskStatus.Running
            Loop
            If Progress.Status = TaskStatus.RanToCompletion Then
                MsgBox("Downloaded!")
            Else
                MsgBox("Not Downloaded :(")
            End If
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UploadFile2("C:\a.pdf")




    End Sub


    Public Function UploadFile(item As String) As Boolean
        Try
            Dim filename = System.IO.Path.GetFileName(item)
            Dim body = New Google.Apis.Drive.v2.Data.File() With {
            .Title = filename,
            .Description = filename,
            .MimeType = (System.IO.Path.GetExtension(filename).TrimStart("."c)),
            .Parents = New List(Of ParentReference)() From {
                New ParentReference() With {
                    .Id = item
                }
            }
        }

            Dim stream = New System.IO.MemoryStream(System.IO.File.ReadAllBytes(item))

            Dim request As FilesResource.InsertMediaUpload = Service.Files.Insert(body, stream, body.MimeType)
            request.Upload()
            Dim uploadedfile As Google.Apis.Drive.v2.Data.File = request.ResponseBody

            Dim success = uploadedfile IsNot Nothing AndAlso uploadedfile.Id.Length > 0
            If success Then
                Dim size As Long = 0
                item = If(Long.TryParse(uploadedfile.FileSize, size), size, 0)
            Else

            End If

            Return success
        Catch e As Exception

            Return False
        End Try
    End Function
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub ExistenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExistenteToolStripMenuItem.Click

    End Sub

    Private Sub lvCuentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvCuentas.SelectedIndexChanged

    End Sub

    Private Sub lvCuentas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvCuentas.MouseDoubleClick
        'conectar a la cuenta
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CrearDirectorio()
    End Sub

    Private Sub SelDir_Click(sender As Object, e As EventArgs) Handles SelDir.Click

    End Sub

    Private Sub Btn_organizar_Click(sender As Object, e As EventArgs) Handles Btn_organizar.Click
        If My.Computer.FileSystem.DirectoryExists(DIR_FOTOS + "\Fotos_Organizadas\") = False Then
            My.Computer.FileSystem.CreateDirectory(DIR_FOTOS + "\Fotos_Organizadas\")
        End If


        For Each Archivo As String In My.Computer.FileSystem.GetFiles(DIR_FOTOS, FileIO.SearchOption.SearchAllSubDirectories,
                                "*.*")

            Dim fileCreatedDate As DateTime = System.IO.File.GetLastWriteTime(Archivo)

            Dim Nom_archivo As String
            Dim EXT_archivo As String
            Nom_archivo = Path.GetFileName(Archivo)
            EXT_archivo = Path.GetExtension(Archivo)



            Dim anyo As String
            Dim mes As String
            anyo = fileCreatedDate.Year

            mes = fileCreatedDate.Month
            If mes < 10 Then
                mes = "0" & mes
            End If

            If My.Computer.FileSystem.DirectoryExists(DIR_FOTOS + "\Fotos_Organizadas\" + anyo) = False Then
                My.Computer.FileSystem.CreateDirectory(DIR_FOTOS + "\Fotos_Organizadas\" + anyo)
                If My.Computer.FileSystem.DirectoryExists(DIR_FOTOS + "\Fotos_Organizadas\" + anyo + "\" + mes) = False Then
                    My.Computer.FileSystem.CreateDirectory(DIR_FOTOS + "\Fotos_Organizadas\" + anyo + "\" + mes)
                End If
            Else
                If My.Computer.FileSystem.DirectoryExists(DIR_FOTOS + "\Fotos_Organizadas\" + anyo + "\" + mes) = False Then
                    My.Computer.FileSystem.CreateDirectory(DIR_FOTOS + "\Fotos_Organizadas\" + anyo + "\" + mes)
                End If

            End If

            Dim dir_mover As String = DIR_FOTOS + "\Fotos_Organizadas\" + anyo + "\" + mes


            'Crea la carpeta para ir introducion las fotos que corresponde


            'cuento los arvhivos que hay en la carpeta
            Dim counter = My.Computer.FileSystem.GetFiles(dir_mover)

            Dim NombreFinal = counter.Count + 1
            'Muevo la foto
            My.Computer.FileSystem.MoveFile(Archivo, dir_mover + "\" + Nom_archivo)

            'renombro la foto
            My.Computer.FileSystem.RenameFile(dir_mover + "\" + Nom_archivo, CStr(NombreFinal) + EXT_archivo)

        Next

        MsgBox("Archivos Ordenados")

    End Sub

    Private Sub btndirfotos_Click(sender As Object, e As EventArgs) Handles btndirfotos.Click
        Dim oFD As New FolderBrowserDialog
        oFD.ShowDialog()
        Me.txtdirfotos.Text = oFD.SelectedPath
        DIR_FOTOS = txtdirfotos.Text
    End Sub
End Class
#Region "Comentado"


'Public Class ExploradorCarpetasVB


'    Public Sub cargarSubcarpetas(ByVal rutaRaiz As String,
'              ByVal nodoTree As Windows.Forms.TreeNode)
'        On Error Resume Next
'        Dim carpetaActual As String
'        Dim indice As Integer

'        If nodoTree.Nodes.Count = 0 Then
'            For Each carpetaActual In
'                    My.Computer.FileSystem.GetDirectories(rutaRaiz)
'                indice = carpetaActual.LastIndexOf(System.IO.Path.PathSeparator)
'                nodoTree.Nodes.Add(carpetaActual.Substring(indice + 1,
'                     carpetaActual.Length - indice - 1))
'                nodoTree.LastNode.Tag = carpetaActual
'                nodoTree.LastNode.ImageIndex = 0
'            Next
'        End If
'    End Sub

'    Public Sub cargarCarpetas(ByVal rutaRaiz As String)
'        Dim nodoBase As System.Windows.Forms.TreeNode

'        If IO.Directory.Exists(rutaRaiz) Then
'            If rutaRaiz.Length <= 3 Then
'                nodoBase = TreeView1.Nodes.Add(rutaRaiz)
'            Else
'                nodoBase = TreeView1.Nodes.Add(
'                    My.Computer.FileSystem.GetName(rutaRaiz))
'            End If
'            nodoBase.Tag = rutaRaiz
'            cargarSubcarpetas(rutaRaiz, nodoBase)
'        Else
'            Throw New System.IO.DirectoryNotFoundException()
'        End If
'    End Sub

'    Private Sub Button1_Click(sender As System.Object,
'               e As System.EventArgs) Handles Button1.Click
'        cargarCarpetas(TextBox1.Text)
'    End Sub

'    Private Sub TreeView1_AfterExpand(sender As System.Object,
'               e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand
'        Dim n As System.Windows.Forms.TreeNode
'        For Each n In e.Node.Nodes
'            cargarSubcarpetas(n.Tag, n)
'        Next
'    End Sub
'End Class

#End Region