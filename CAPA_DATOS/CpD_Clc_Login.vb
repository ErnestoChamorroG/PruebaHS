Imports System.Data.SqlClient
Public Class CpD_Clc_Login
    Public datLogin As New SqlDataAdapter

    'Iniciar Sesión
    Public Function LOGIN(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Login) As DataSet
        Dim cn As New SqlConnection(cadena)
        Dim dtusuario As New DataSet
        Try
            cn.Open()
            datLogin.SelectCommand = cn.CreateCommand
            datLogin.SelectCommand.CommandText = "SP_LOGIN"
            datLogin.SelectCommand.CommandType = CommandType.StoredProcedure
            datLogin.SelectCommand.Parameters.AddWithValue("@Rut", obj.Rut)
            datLogin.SelectCommand.ExecuteNonQuery()
            datLogin.Fill(dtusuario)
            Return dtusuario
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw New Exception(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Function

    'Consultar existencia de usuario
    Public Sub CONSULTAR_EXISTENCIA_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Login)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datLogin.SelectCommand = cn.CreateCommand
            datLogin.SelectCommand.CommandText = "SP_EXISTENCIA_DE_USUARIO"
            datLogin.SelectCommand.CommandType = CommandType.StoredProcedure
            datLogin.SelectCommand.Parameters.AddWithValue("@Rut", obj.Rut)
            datLogin.SelectCommand.ExecuteNonQuery()
            obj.Rut1 = datLogin.SelectCommand.ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw New Exception(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

End Class
