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
Imports System.Data
Imports System.Data.SqlClient

Public Class VentuDrive
    Public DIR_FOTOS As String
    Public DIRE_UNI As String
    Dim begreen As Boolean = True
    Dim sConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BBDD_GOOGLE.mdf;Integrated Security=True"



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim objConn As New SqlConnection(sConnectionString)
        objConn.Open()

        '      Dim sSQL As String = "INSERT INTO TCLIENTE  " & _  "(emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date)" & _
        '"VALUES ('MSD12923F', 'Duncan', 'W', 'Mackenzie', " & _ 
        '         "10, 82,'0877','2001-01-01')"

        Dim sSQL As String = "INSERT INTO TCUENTAS values('DAvid1','1','1','O','N') "
        Dim objCmd As New SqlCommand(sSQL, objConn)

        objCmd.ExecuteNonQuery()
        'tendriamos que hacer un select de la tabla de BBDD y rellenar el treeview

        'lvCuentas.Items.Add("gaerhoth@gmail.com", 0) 'drive
        'lvCuentas.Items.Add("gaerhoth@hotmail.com", 1) ' dropbox 
        'lvCuentas.Items.Add("gaerhoth@hotmail.com", 2) ' ondrive


        'https://console.developers.google.com/projectselector/apis/credentials

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