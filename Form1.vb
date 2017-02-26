Imports System.Threading
Imports System.Threading.Tasks
Imports System.Data.SQLite
Imports Google
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v2
Imports Google.Apis.Drive.v2.Data
Imports Google.Apis.Services
Imports Google.Apis.Auth
Imports Google.Apis.Download
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports VenturoDrive_V2.VAR_GLOBALES
Imports VenturoDrive_V2.BBDD
Imports  System.Configuration


Public Class VentuDrive
    Public DIR_FOTOS As String
    Public DIRE_UNI As String
    Dim begreen As Boolean = True

    Public Function Conexion() As String
        Return Path.Combine("C:\", "VentuDrive.sqlite")
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvCuentas.ContextMenuStrip = CR

        BBDD.CREARBBDD()


        DamecuentasActivas()

        'Lo que tenemos que hacer aqui es seleccionar todas la cuentas que no esten de baja y meterlas en lvcuentas
        'tendriamos que hacer un select de la tabla de BBDD y rellenar el treeview
        'tenemos que mirar si podemos hacer una ruta de internet como si fuera física.

        'Cuando pinchemos en una cuenta conectar
        'Hay que hacer una select para sacar el client secret y el client ID


        'lvCuentas.Items.Add("gaerhoth@gmail.com", 0) 'drive
        'lvCuentas.Items.Add("gaerhoth@hotmail.com", 1) ' dropbox 
        'lvCuentas.Items.Add("gaerhoth@hotmail.com", 2) ' ondrive


        'https://console.developers.google.com/projectselector/apis/credentials


        'Me crea el servicio para conectarme a Google Drive
        'CreateService()
    End Sub

    Private Service As DriveService = New DriveService

    'Private Sub CreateService()    

    '    Dim ClientId = "517228978970-0ohd9912k4v2v5ul6colclscgkfjvmeb.apps.googleusercontent.com"
    '    Dim ClientSecret = "xw_ZQEWOXZVzR5D-E1kNvi-m"
    '    Dim MyUserCredential As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With {.ClientId = ClientId, .ClientSecret = ClientSecret}, {DriveService.Scope.Drive}, "user", CancellationToken.None).Result
    '    Service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = MyUserCredential, .ApplicationName = "Google Drive VB Dot Net"})

    'End Sub

    Private Sub CreateService(ID As String, secret As String)

        Dim ClientId = ID
        Dim ClientSecret = secret
        Dim MyUserCredential As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With {.ClientId = ClientId, .ClientSecret = ClientSecret}, {DriveService.Scope.Drive}, "gaerhoth", CancellationToken.None).Result
        Service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = MyUserCredential, .ApplicationName = "Google Drive VB Dot Net"})




        GetInfo()


        Dim pr As Integer

        pr = (MBUSADOS * 100) / MBTOAL

        PBLIBRE.Value = pr

    End Sub

    Public Function GetInfo() As GDriveAbout
        Return New GDriveAbout(Service.About.[Get]().Execute())
    End Function

    Public Sub DamecuentasActivas()
        ' Using con As New SQLiteConnection(cs)
        conn.Open()

        Using cmd As New SQLiteCommand(conn)
            Dim TTCuenta As Integer

            cmd.CommandText = "SELECT * FROM TCUENTAS WHERE FEC_BAJA=''"

            Dim rdr As SQLiteDataReader = cmd.ExecuteReader()

            Using rdr
                While (rdr.Read())

                    Select Case rdr(2)
                        Case "G"
                            TTCuenta = 0
                        Case "O"
                            TTCuenta = 2
                        Case "D"
                            TTCuenta = 1
                    End Select


                    lvCuentas.Items.Add(rdr(1), TTCuenta)
                End While
            End Using
            '    End Using

            conn.Close()
        End Using
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

        'para sacar el directoryID
        'con esto decimos de que directorio quiero sacar el directory id
        'Dim Q As String = "title = 'VENTURO2Sample' and mimeType = 'application/vnd.google-apps.folder'"
        'Con esto sacamos el DirectoryID
        'Dim _FILES As List(Of Google.Apis.Drive.v2.Data.File)
        '_FILES = HELPER.GetFiles(Service, Q)
        ' Dim directoryId As String
        ' directoryId = _FILES(0).Id



        Dim Q As String = "title = 'DDos' and mimeType = 'application/vnd.google-apps.folder'"

        Dim _FILES As List(Of Google.Apis.Drive.v2.Data.File)
        'LISTAR
        _FILES = HELPER.GetFiles(Service, Q)



        '_FILES(0).

        If (_FILES.Count = 0) Then
            ' Con esto creamos un directorio
            _FILES.Add(HELPER.createDirectory(Service, "VENTURO2Sample", "VENTURO2Sample", "root"))
        End If

        Dim directoryId As String
        directoryId = _FILES(0).Id


        'con esta creamos una carpeta dentro de otra
        HELPER.createDirectory(Service, "VENTURO2Sample2", "VENTURO2Sample2", directoryId)

        'subimos un archivo al directoryID
        Dim NEWFILE As Google.Apis.Drive.v2.Data.File
        NEWFILE = HELPER.uploadFile(Service, "c:\a.pdf", directoryId)


        MsgBox("Upload Finished")
    End Sub

    Private Sub DownloadFile(url As String, DownloadDir As String)
        Me.Cursor = Cursors.WaitCursor
        If Service.ApplicationName <> "Google Drive VB Dot Net" Then CreateService(CID, CSC)

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
        Dim frm As New CG()
        frm.Show()
    End Sub

    Public Sub DameDatosCuenta(posicion As Integer)

        conn.Open()

        Using cmd As New SQLiteCommand(conn)
            Dim TTCuenta As Integer

            cmd.CommandText = "SELECT * FROM TCUENTAS WHERE ID_CUENTA = " & posicion & ""

            Dim rdr As SQLiteDataReader = cmd.ExecuteReader()

            Using rdr
                While (rdr.Read())

                    ' lvCuentas.Items.Add(rdr(1), TTCuenta)
                    CID = rdr(3)
                    CSC = rdr(4)

                End While
            End Using
            '    End Using

            conn.Close()
        End Using

    End Sub

    Private Sub lvCuentas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvCuentas.MouseDoubleClick
        'conectar a la cuenta

        CID = ""
        CSC = ""
        Dim p = lvCuentas.FocusedItem.Index
        DameDatosCuenta(p + 1)

        CreateService(CID, CSC)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CrearDirectorio()
    End Sub

    Private Sub SelDir_Click(sender As Object, e As EventArgs) Handles SelDir.Click

    End Sub

    Private Sub Btn_organizar_Click(sender As Object, e As EventArgs) Handles Btn_organizar.Click

        If (DIR_FOTOS <> "" And DIRE_UNI <> "") Then



            If My.Computer.FileSystem.DirectoryExists(DIRE_UNI + "\Fotos_Organizadas\") = False Then
                My.Computer.FileSystem.CreateDirectory(DIRE_UNI + "\Fotos_Organizadas\")
            End If
            If My.Computer.FileSystem.DirectoryExists(DIRE_UNI + "\TMP\") = False Then
                My.Computer.FileSystem.CreateDirectory(DIRE_UNI + "\TMP\")
            End If

            Dim i As Integer
            Dim Contador = My.Computer.FileSystem.GetFiles(DIR_FOTOS, FileIO.SearchOption.SearchAllSubDirectories)


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

                If (EXT_archivo <> ".avi" And EXT_archivo <> ".mp4") Then


                    If My.Computer.FileSystem.DirectoryExists(DIRE_UNI + "\Fotos_Organizadas\" + anyo) = False Then
                        My.Computer.FileSystem.CreateDirectory(DIRE_UNI + "\Fotos_Organizadas\" + anyo)
                        If My.Computer.FileSystem.DirectoryExists(DIRE_UNI + "\Fotos_Organizadas\" + anyo + "\" + mes) = False Then
                            My.Computer.FileSystem.CreateDirectory(DIRE_UNI + "\Fotos_Organizadas\" + anyo + "\" + mes)
                        End If
                    Else
                        If My.Computer.FileSystem.DirectoryExists(DIRE_UNI + "\Fotos_Organizadas\" + anyo + "\" + mes) = False Then
                            My.Computer.FileSystem.CreateDirectory(DIRE_UNI + "\Fotos_Organizadas\" + anyo + "\" + mes)
                        End If

                    End If

                    Dim dir_mover As String = DIRE_UNI + "\Fotos_Organizadas\" + anyo + "\" + mes
                    Dim dir_temporal As String = DIRE_UNI + "\TMP"

                    'Crea la carpeta para ir introducion las fotos que corresponde


                    'cuento los arvhivos que hay en la carpeta
                    Dim counter = My.Computer.FileSystem.GetFiles(dir_mover)

                    Dim NombreFinal = counter.Count + 1
                    'Muevo la foto al temporal
                    My.Computer.FileSystem.MoveFile(Archivo, dir_temporal + "\" + Nom_archivo)

                    'renombro la foto
                    My.Computer.FileSystem.RenameFile(dir_temporal + "\" + Nom_archivo, CStr(NombreFinal) + EXT_archivo)

                    'Muevo la foto al directorio final
                    My.Computer.FileSystem.MoveFile(dir_temporal & "\" & CStr(NombreFinal) + EXT_archivo, dir_mover + "\" + CStr(NombreFinal) + EXT_archivo)

                Else

                    If My.Computer.FileSystem.DirectoryExists(DIRE_UNI + "\Fotos_Organizadas\Videos\" + anyo) = False Then
                        My.Computer.FileSystem.CreateDirectory(DIRE_UNI + "\Fotos_Organizadas\Videos\" + anyo)
                        If My.Computer.FileSystem.DirectoryExists(DIRE_UNI + "\Fotos_Organizadas\Videos\" + anyo + "\" + mes) = False Then
                            My.Computer.FileSystem.CreateDirectory(DIRE_UNI + "\Fotos_Organizadas\Videos\" + anyo + "\" + mes)
                        End If
                    Else
                        If My.Computer.FileSystem.DirectoryExists(DIRE_UNI + "\Fotos_Organizadas\Videos\" + anyo + "\" + mes) = False Then
                            My.Computer.FileSystem.CreateDirectory(DIRE_UNI + "\Fotos_Organizadas\Videos\" + anyo + "\" + mes)
                        End If

                    End If

                    Dim dir_mover As String = DIRE_UNI + "\Fotos_Organizadas\Videos\" + anyo + "\" + mes
                    Dim dir_temporal As String = DIRE_UNI + "\TMP"

                    'Crea la carpeta para ir introducion las fotos que corresponde


                    'cuento los arvhivos que hay en la carpeta
                    Dim counter = My.Computer.FileSystem.GetFiles(dir_mover)

                    Dim NombreFinal = counter.Count + 1
                    'Muevo la foto al temporal
                    My.Computer.FileSystem.MoveFile(Archivo, dir_temporal + "\" + Nom_archivo)

                    'renombro la foto
                    My.Computer.FileSystem.RenameFile(dir_temporal + "\" + Nom_archivo, CStr(NombreFinal) + EXT_archivo)

                    'Muevo la foto al directorio final
                    My.Computer.FileSystem.MoveFile(dir_temporal & "\" & CStr(NombreFinal) + EXT_archivo, dir_mover + "\" + CStr(NombreFinal) + EXT_archivo)


                End If
                i = i + 1
                PB.Increment(1)
                PB.Value = CInt((i * 100) / Contador.Count)
                Me.lbl_PB.Text = PB.Value
            Next


            My.Computer.FileSystem.DeleteDirectory(DIR_FOTOS, FileIO.DeleteDirectoryOption.DeleteAllContents)


            Dim carpeta As New DirectoryInfo(DIR_FOTOS)
            For Each D As DirectoryInfo In carpeta.GetDirectories
                If D.Name <> "TMP" Then
                    D.Delete(True)
                End If
            Next

            MsgBox("Archivos Ordenados")

        Else

            MsgBox("Seleccione una carpeta para ordenar.")

        End If

    End Sub

    Private Sub btndirfotos_Click(sender As Object, e As EventArgs) Handles btndirfotos.Click
        Dim oFD As New FolderBrowserDialog
        oFD.ShowDialog()
        Me.txtdirfotos.Text = oFD.SelectedPath
        DIR_FOTOS = txtdirfotos.Text
    End Sub

    Private Sub btn_uni_Click(sender As Object, e As EventArgs) Handles btn_uni.Click
        Dim oFD As New FolderBrowserDialog
        oFD.ShowDialog()
        Me.dir_uni.Text = oFD.SelectedPath
        DIRE_UNI = dir_uni.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        UploadFile2("")

        'listar
        HELPER.GetFiles(Service, Nothing)

    End Sub

    Private Sub ObtenerCredencialesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObtenerCredencialesToolStripMenuItem.Click
        Process.Start("https://console.developers.google.com/projectselector/apis/credentials")
    End Sub

    Private Sub NuevaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaToolStripMenuItem.Click
        Process.Start("https://accounts.google.com/SignUp?service=mail&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ltmpl=default")
    End Sub

    Private Sub lvCuentas_MouseDown(sender As Object, e As MouseEventArgs) Handles lvCuentas.MouseDown

    End Sub

    Private Sub btnrefres_Click(sender As Object, e As EventArgs) Handles btnrefres.Click
        DamecuentasActivas()
    End Sub

    Private Sub GoogleDriveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GoogleDriveToolStripMenuItem1.Click
        Dim frm As New CG()
        frm.Show()
    End Sub

    Private Sub EliminarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem1.Click
        Try
            conn.Open()

            Dim Query As New SQLiteCommand()
            Query.Connection = conn

            Dim F As String
            F = Now.Date.ToString

            Query.CommandText = "UPDATE TCUENTAS SET FEC_BAJA = '" & F & "' WHERE ID_CUENTA = " & lvCuentas.FocusedItem.Index + 1

            Query.ExecuteNonQuery()
            conn.Close()

            MsgBox("Se han guardado los datos correctamente")

            Me.Close()

        Catch ex As Exception

            MsgBox("Problemas al guardar tus datos")
        End Try
    End Sub

    Private Sub CopiaBBDDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiaBBDDToolStripMenuItem.Click
        Dim RT As String
        Dim oFD As New FolderBrowserDialog
        oFD.ShowDialog()
        RT = oFD.SelectedPath


        My.Computer.FileSystem.CopyFile(ConfigurationManager.AppSettings("RUTA") & "VentuDrive.db3", RT)
    End Sub

    Private Sub RestaurarBBDDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaurarBBDDToolStripMenuItem.Click

        Dim RT As String
        Dim oFD As New FolderBrowserDialog
        oFD.ShowDialog()
        RT = oFD.SelectedPath

        My.Computer.FileSystem.CopyFile(RT, ConfigurationManager.AppSettings("RUTA"), True)
    End Sub



    'desde aqui son pruebas


    'listar ROOT
    'Public Function GetFiles(Optional parentId As String = "root", Optional search As String = Nothing, Optional pageToken As String = Nothing, Optional perpage As System.Nullable(Of Integer) = Nothing, Optional order As SortOrder = SortOrder.LastModifiedDesc) As GDriveFilesResponse
    '    Dim gfiles = New List(Of GDriveFile)()
    '    Dim request = Service.Files.List()

    '    'request.Q = "mimeType='text/plain'";
    '    request.Q = "trashed=false"
    '    ' undeleted items
    '    request.Q += String.Format(" and '{0}' in parents", parentId)
    '    ' https://developers.google.com/drive/search-parameters
    '    request.Q += If(Not String.IsNullOrEmpty(search), String.Format(" and title contains '{0}'", search), String.Empty)
    '    'request.Q = "mimeType='application/vnd.google-apps.folder' and trashed=false";
    '    request.PageToken = pageToken
    '    request.MaxResults = perpage

    '    'request.RequestParameters.Add("orderBy", new Parameter() { }); // TODO: for sorting

    '    Dim files = request.Execute()

    '    For Each file As var In files.Items
    '        gfiles.Add(New GDriveFile(file))
    '    Next

    '    Return New GDriveFilesResponse(gfiles, files.NextPageToken)
    'End Function




    'Public Sub GDriveFile(file As Google.Apis.Drive.v2.Data.File, Optional isTrash As Boolean = False)
    '    Id = file.Id
    '    FileName = file.OriginalFilename
    '    Dim size__1 As Long = -1
    '    Size = If(file.FileSize IsNot Nothing AndAlso Long.TryParse(file.FileSize, size__1), size__1, -1)
    '    Title = file.Title
    '    Description = file.Description
    '    CreatedDate = file.CreatedDate
    '    ModifiedDate = If(file.ModifiedDate, file.CreatedDate)
    '    DownloadUrl = file.DownloadUrl
    '    ThumbnailUrl = file.ThumbnailLink

    '    FileType = If(file.MimeType.Equals(FileMimeTypes.FolderMimeType), "folder", If(file.FileExtension, file.MimeType))
    '    IsTrashed = isTrash
    'End Sub


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




'Private Sub ListView1_MouseDown(Button As Integer,
'                                Shift As Integer,
'                                x As Single, y As Single)

'    'variable para el item seleccionado
'    Dim Item As ListItem

'    ' verifica que se presionó el botón derecho
'    If Button = vbRightButton Then

'        ' HitTest devuelve la ferencia al item, a partir _
'        de las coordenadas del mouse
'        Set Item = ListView1.HitTest(x, y)

'        ' chequea que haya un item seleccionado
'        If Not Item Is Nothing Then

'            ' Selecciona el elemento
'            Set ListView1.SelectedItem = Item

'            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'            ' Acá colocar el código para desplegar el menú popup.
'            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'            ' texto del elemento seleccionado
'            Me.Caption = Item.Text
'            ' despliega el menú
'            PopupMenu MiMenuPopUp

'        End If


'    End If

'End Sub


'Private Sub Form_Load()
'    Dim i As Integer
'    Dim Item As ListItem
'    ' agrega un encabezado de columna
'    ListView1.ColumnHeaders.Add , , "Columna 1"

'    ' vista de reporte
'    ListView1.View = lvwReport

'    ' Agrega algunos elementos
'    For i = 0 To 100
'        ListView1.ListItems.Add , , "Elemento: " & i
'    Next

'End Sub

Public Class GDriveAbout
    Public username As String
    Public BytesTotal As Long
    Public BytesUsed As Long
    Public RootFolderId As String
    Public IsAuthenticated As Boolean
    Public UserDisplayName As String
    Public PictureUrl As String

    Friend Sub New(about As About)
        username = about.Name
        BytesTotal = If(about.QuotaBytesTotal IsNot Nothing, Long.Parse(about.QuotaBytesTotal), -1)
        BytesUsed = If(about.QuotaBytesUsed IsNot Nothing, Long.Parse(about.QuotaBytesUsed), -1)
        RootFolderId = about.RootFolderId

        If about.User IsNot Nothing Then
            IsAuthenticated = about.User.IsAuthenticatedUser.HasValue AndAlso about.User.IsAuthenticatedUser.Value
            UserDisplayName = about.User.DisplayName
            PictureUrl = about.User.Picture.Url
        End If

        MBUSADOS = BytesUsed / 1048576
        MBTOAL = BytesTotal / 1048576

    End Sub
End Class