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



Public Class BBDD
    'Aqui lo que hay que hacer es parametrizar las rutas
    Public Shared Sub CREARBBDD()


        If My.Computer.FileSystem.FileExists("C:\a\BBDD_VentuDrive.db3") = False Then
            SQLiteConnection.CreateFile("C:\a\BBDD_VentuDrive.db3")
        End If





        If My.Computer.FileSystem.FileExists("C:\a\BBDD_VentuDrive.db3") = False Then
            Dim Query As New SQLiteCommand()
            Query.Connection = conn
            Query.CommandText = "CREATE TABLE TCUENTAS (ID_CUENTA   Integer Not NULL PRIMARY KEY AUTOINCREMENT,	NOM_CUENTA	TEXT Not NULL,	TIP_CUENTA	TEXT Not NULL,CLIENT_ID	TEXT Not NULL,CLIENT_SECRET	TEXT Not NULL,FEC_BAJA	TEXT);"
            Query.ExecuteNonQuery()
            conn.Close()
        End If

        'me da la conexion a BBDD
        conn = New SQLiteConnection("DataSource=c:\a\BBDD_VentuDrive.db3;Version=3;New=False;Compress=True;")
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

