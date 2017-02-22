Imports System.Data.SQLite
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
Imports VenturoDrive_V2.VAR_GLOBALES

Public Class CG
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btngrabar.Click
        Try
            conn.Open()

            Dim Query As New SQLiteCommand()
            Query.Connection = conn


            Query.CommandText = "INSERT INTO TCUENTAS (NOM_CUENTA, TIP_CUENTA, CLIENT_ID, CLIENT_SECRET, FEC_BAJA)
                            values('" & Trim(NombreC.Text) & "','G','" & Trim(ClientID.Text) & "','" & Trim(ClientSecret.Text) & "','')"
            Query.ExecuteNonQuery()
            conn.Close()

            MsgBox("Se han guardado los datos correctamente")

            Me.Close()

        Catch ex As Exception

            MsgBox("Problemas al guardar tus datos")
        End Try

    End Sub


End Class