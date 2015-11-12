Imports System.Data.SqlClient
Public Class CpD_Clc_UsuarioPagWeb
    Dim datUsuPag As New SqlDataAdapter
    'Registro Usuario pág externa
    Public Sub REGISTRARUSUARIOEXTERNO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuPag.InsertCommand = cn.CreateCommand
            datUsuPag.InsertCommand.CommandText = "SP_REGISTRAR_USU_EXT"
            datUsuPag.InsertCommand.CommandType = CommandType.StoredProcedure
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Rut", obj.Rut)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Nombres", obj.Nombres)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Apellidos", obj.Apellidos)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Sexo", obj.Sexo)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@FechaNac", obj.FechaNac)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Direccion", obj.Direccion)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Fono", obj.Fono)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Contrasena", obj.Contrasena)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Email", obj.Email)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Rut1", obj.Rut)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@IdPerfil", obj.IdPerfil)
            datUsuPag.InsertCommand.Parameters.AddWithValue("@Estado", obj.Estado)
            datUsuPag.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    'Consultar existencia de usuario
    Public Sub CONSULTAR_EXISTENCIA_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuPag.SelectCommand = cn.CreateCommand
            datUsuPag.SelectCommand.CommandText = "SP_EXISTENCIA_DE_USUARIO"
            datUsuPag.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuPag.SelectCommand.Parameters.AddWithValue("@Rut", obj.Rut)
            datUsuPag.SelectCommand.ExecuteNonQuery()
            obj.Rut1 = datUsuPag.SelectCommand.ExecuteScalar()
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

    'Listar Datos Usuario Externo
    Public Function LISTAR_DATOS_USU_EXT(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb) As DataSet
        Dim cn As New SqlConnection(cadena)
        Dim dtusuario As New DataSet
        Try
            cn.Open()
            datUsuPag.SelectCommand = cn.CreateCommand
            datUsuPag.SelectCommand.CommandText = "SP_LISTAR_DATOS_USUARIO"
            datUsuPag.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuPag.SelectCommand.Parameters.AddWithValue("@Rut", obj.Rut)
            datUsuPag.SelectCommand.ExecuteNonQuery()
            datUsuPag.Fill(dtusuario)
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

    'Modificar datos usuario externo
    Public Sub ACTUALIZAR_DATOS_USU_ETX(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuPag.UpdateCommand = cn.CreateCommand
            datUsuPag.UpdateCommand.CommandType = CommandType.StoredProcedure
            datUsuPag.UpdateCommand.CommandText = "SP_ACTUALIZAR_DATOS_USU_EXT"
            datUsuPag.UpdateCommand.Parameters.AddWithValue("@Rut", obj.Rut)
            datUsuPag.UpdateCommand.Parameters.AddWithValue("@Direccion", obj.Direccion)
            datUsuPag.UpdateCommand.Parameters.AddWithValue("@Fono", obj.Fono)
            datUsuPag.UpdateCommand.Parameters.AddWithValue("@Pass", obj.Contrasena)
            datUsuPag.UpdateCommand.Parameters.AddWithValue("@Email", obj.Email)
            datUsuPag.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    'Recuperción Pass
    Public Function LISTAR_DATOS_Pass(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb) As DataSet
        Dim cn As New SqlConnection(cadena)
        Dim dtusuario As New DataSet
        Try
            cn.Open()
            datUsuPag.SelectCommand = cn.CreateCommand
            datUsuPag.SelectCommand.CommandText = "SP_RECUPERACION_EMAIL"
            datUsuPag.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuPag.SelectCommand.Parameters.AddWithValue("@Rut", obj.Rut)
            datUsuPag.SelectCommand.ExecuteNonQuery()
            datUsuPag.Fill(dtusuario)
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
End Class
