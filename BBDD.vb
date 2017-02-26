Imports System.Threading
Imports System.Threading.Tasks
Imports System.Data.SQLite
Imports Google
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v2
Imports Google.Apis.Drive.v2.Data
Imports Google.Apis.Services
Imports System.Configuration
Imports Google.Apis.Auth
Imports Google.Apis.Download
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports VenturoDrive_V2.VAR_GLOBALES



Public Class BBDD
    'Aqui lo que hay que hacer es parametrizar las rutas
    Public Shared Sub CREARBBDD()

        'comprobamos que exite la ruta donde vamos a guardar la bbdd
        If My.Computer.FileSystem.DirectoryExists(ConfigurationManager.AppSettings("RUTA")) = False Then

            'creamos el directorio
            My.Computer.FileSystem.CreateDirectory(ConfigurationManager.AppSettings("RUTA"))

            ''miramos si existe ya la BBDD
            If My.Computer.FileSystem.FileExists(ConfigurationManager.AppSettings("RUTA") & "VentuDrive.db3") = False Then
                'si no existe la creamos
                SQLiteConnection.CreateFile(ConfigurationManager.AppSettings("RUTA") & "VentuDrive.db3")

                'Creamos la tabla
                Dim Query As New SQLiteCommand()
                Query.Connection = conn
                Query.CommandText = "CREATE TABLE TCUENTAS (ID_CUENTA   Integer Not NULL PRIMARY KEY AUTOINCREMENT,	NOM_CUENTA	TEXT Not NULL,	TIP_CUENTA	TEXT Not NULL,CLIENT_ID	TEXT Not NULL,CLIENT_SECRET	TEXT Not NULL,FEC_BAJA	TEXT);"
                Query.ExecuteNonQuery()
                conn.Close()
            End If

        End If

        'Obtenemos la cadena de conexion de la BBDD
        conn = New SQLiteConnection("DataSource=" & ConfigurationManager.AppSettings("RUTA") & "VentuDrive.db3" & "VentuDrive.db3;Version=3;New=False;Compress=True;")
    End Sub




End Class

'campos de la bbdd
'TCUENTAS
'id  1
'nombre_cuenta david@gmail.com  
'tipo_cuenta G
'cliente_secret xxxx
'clientID xxxxx
'fec_baja nulo
'

