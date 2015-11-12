Imports System.Data.SqlClient
Public Class CpD_Clc_Especialidad
    Public datEspecialidad As New SqlDataAdapter
    'Insertar Especialida
    Public Sub INSERTAR_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datEspecialidad.InsertCommand = cn.CreateCommand
            datEspecialidad.InsertCommand.CommandText = "SP_INSERTAR_ESPECIALIDAD"
            datEspecialidad.InsertCommand.CommandType = CommandType.StoredProcedure
            datEspecialidad.InsertCommand.Parameters.AddWithValue("@Nombre_Especialidad", obj.NombreEsp)
            datEspecialidad.InsertCommand.Parameters.AddWithValue("@Estado", obj.Estado)
            datEspecialidad.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    'Consultar Nombre Especialidad
    Public Sub CONSULTAR_NOMBRE_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datEspecialidad.SelectCommand = cn.CreateCommand
            datEspecialidad.SelectCommand.CommandText = "SP_NOMBRE_ESPECIALIDAD"
            datEspecialidad.SelectCommand.CommandType = CommandType.StoredProcedure
            datEspecialidad.SelectCommand.Parameters.AddWithValue("@Nombre_Esp", obj.NombreEspCons)
            datEspecialidad.SelectCommand.ExecuteNonQuery()
            obj.NombreEsp = datEspecialidad.SelectCommand.ExecuteScalar()
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

    'Listar Especialidades
    Public Function LISTAR_ESPECIALIDADES() As DataSet
        Dim cn As New SqlConnection(cadena)
        Dim dtespecialidad As New DataSet
        Try
            cn.Open()
            datEspecialidad.SelectCommand = cn.CreateCommand
            datEspecialidad.SelectCommand.CommandText = "SP_LISTAR_ESPECIALIDADES"
            datEspecialidad.SelectCommand.CommandType = CommandType.StoredProcedure
            datEspecialidad.SelectCommand.ExecuteNonQuery()
            datEspecialidad.Fill(dtespecialidad)
            Return dtespecialidad
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

    'Estado Especialidad
    Public Sub MOSTRAR_ESTADO_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datEspecialidad.SelectCommand = cn.CreateCommand
            datEspecialidad.SelectCommand.CommandText = "SP_ESTADO_ESP"
            datEspecialidad.SelectCommand.CommandType = CommandType.StoredProcedure
            datEspecialidad.SelectCommand.Parameters.AddWithValue("@NombreEsp", obj.NombreEspCons)
            datEspecialidad.SelectCommand.ExecuteNonQuery()
            obj.Estado = datEspecialidad.SelectCommand.ExecuteScalar()
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

    'Modificar estado de una especialidad
    Public Sub MODIFICAR_ESTADO_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datEspecialidad.UpdateCommand = cn.CreateCommand
            datEspecialidad.UpdateCommand.CommandType = CommandType.StoredProcedure
            datEspecialidad.UpdateCommand.CommandText = "SP_MODIFICAR_ESTADO_ESP"
            datEspecialidad.UpdateCommand.Parameters.AddWithValue("@Estado", obj.Estado)
            datEspecialidad.UpdateCommand.Parameters.AddWithValue("@Nombre_esp", obj.NombreEsp)
            datEspecialidad.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    'Modificar el nombre de una especialidad
    Public Sub MODIFICAR_NOMBRE_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datEspecialidad.UpdateCommand = cn.CreateCommand
            datEspecialidad.UpdateCommand.CommandType = CommandType.StoredProcedure
            datEspecialidad.UpdateCommand.CommandText = "SP_MODIFICAR_NOMBRE_ESPECIALIDAD"
            datEspecialidad.UpdateCommand.Parameters.AddWithValue("@NombreEspMod", obj.NombreEspCons)
            datEspecialidad.UpdateCommand.Parameters.AddWithValue("@NombreEspAct", obj.NombreEsp)
            datEspecialidad.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    'Listar Especialidades Activas
    Public Function LISTAR_ESPECIALIDADES_ACTIVAS() As DataSet
        Dim cn As New SqlConnection(cadena)
        Dim dtespecialidad As New DataSet
        Try
            cn.Open()
            datEspecialidad.SelectCommand = cn.CreateCommand
            datEspecialidad.SelectCommand.CommandText = "SP_LISTAR_ESPECIALIDADES_ACTIVAS"
            datEspecialidad.SelectCommand.CommandType = CommandType.StoredProcedure
            datEspecialidad.SelectCommand.ExecuteNonQuery()
            datEspecialidad.Fill(dtespecialidad)
            Return dtespecialidad
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
