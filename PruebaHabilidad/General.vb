Imports System.Data.Common
Imports System.Data.SqlClient

Public Class General


    Public cnn As SqlConnection = New SqlConnection(My.Settings.ConnectionString)



    Public Function VerificaConexion(Conexion As String)
        Try
            Dim SQLCon As New SqlConnection(Conexion)

            SQLCon.Open()
            SQLCon.Close()

            Return "Ok."
        Catch ex As Exception
            Return ex.ToString
        End Try


    End Function
    Public Function SQLTable(sSQL As String)


        Dim strSql As String = sSQL
        Dim dtb As New DataTable

        cnn.Open()
            Using dad As New SqlDataAdapter(strSql, cnn)
                dad.Fill(dtb)
            End Using
        cnn.Close()

        Return dtb

    End Function

    Public Function GuardaInformacion(Clave As String, ApellidoP As String, ApellidoM As String, Nombre As String, FechaNac As String, Tipo As String)

        Try
            Dim Codigo As Integer

            cnn.Open()
            Dim cmd = New SqlCommand("sp_acciones_Persona", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@sp_id", Clave)
            cmd.Parameters.AddWithValue("@sp_ApellidoPaterno", ApellidoP)
            cmd.Parameters.AddWithValue("@sp_ApellidoMaterno", ApellidoM)
            cmd.Parameters.AddWithValue("@sp_nombre", Nombre)
            cmd.Parameters.AddWithValue("@sp_fechaNacimiento", FechaNac)
            cmd.Parameters.AddWithValue("@sp_type ", Tipo)

            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cnn.Close()
            cmd.Dispose()

            Return "OK."

        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function

End Class
