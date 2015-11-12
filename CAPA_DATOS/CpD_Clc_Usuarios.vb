Imports CAPA_ENTIDAD
Imports System.Data.SqlClient
Imports System.Data

Public Class CpD_Clc_Usuarios
    Public datUsuario As New SqlDataAdapter
    'Insertar USUARIOS
    Public Sub INSERTAR_USUARIOS(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuario.InsertCommand = cn.CreateCommand
            datUsuario.InsertCommand.CommandText = "SP_INSERTAR_USUARIO"
            datUsuario.InsertCommand.CommandType = CommandType.StoredProcedure
            datUsuario.InsertCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.InsertCommand.Parameters.AddWithValue("@RUT1", obj.Rut1)
            datUsuario.InsertCommand.Parameters.AddWithValue("@NOMBRES", obj.Nombres)
            datUsuario.InsertCommand.Parameters.AddWithValue("@APELLIDOS", obj.Apellidos)
            datUsuario.InsertCommand.Parameters.AddWithValue("@SEXO", obj.Sexo)
            datUsuario.InsertCommand.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.Fecha_Nacimiento)
            datUsuario.InsertCommand.Parameters.AddWithValue("@DIRECCION", obj.Direccion)
            datUsuario.InsertCommand.Parameters.AddWithValue("@FONO", obj.Fono)
            datUsuario.InsertCommand.Parameters.AddWithValue("@CONTRASENIA", obj.Contrasenia)
            datUsuario.InsertCommand.Parameters.AddWithValue("@CORREO_ELEC", obj.Correo)
            datUsuario.InsertCommand.Parameters.AddWithValue("@ID_ESPECIALIDAD", obj.Especialidad)
            datUsuario.InsertCommand.Parameters.AddWithValue("@ID_PERFIL", obj.Perfil)
            datUsuario.InsertCommand.Parameters.AddWithValue("@ESTADO", obj.Estado)

            datUsuario.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    'Insertar USUARIOS SIN ESPECIALIDAD
    Public Sub INSERTAR_USUARIOS_SINESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuario.InsertCommand = cn.CreateCommand
            datUsuario.InsertCommand.CommandText = "SP_INSERTAR_USUARIO_SINESPECIALIDAD"
            datUsuario.InsertCommand.CommandType = CommandType.StoredProcedure
            datUsuario.InsertCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.InsertCommand.Parameters.AddWithValue("@RUT1", obj.Rut1)
            datUsuario.InsertCommand.Parameters.AddWithValue("@NOMBRES", obj.Nombres)
            datUsuario.InsertCommand.Parameters.AddWithValue("@APELLIDOS", obj.Apellidos)
            datUsuario.InsertCommand.Parameters.AddWithValue("@SEXO", obj.Sexo)
            datUsuario.InsertCommand.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.Fecha_Nacimiento)
            datUsuario.InsertCommand.Parameters.AddWithValue("@DIRECCION", obj.Direccion)
            datUsuario.InsertCommand.Parameters.AddWithValue("@FONO", obj.Fono)
            datUsuario.InsertCommand.Parameters.AddWithValue("@CONTRASENIA", obj.Contrasenia)
            datUsuario.InsertCommand.Parameters.AddWithValue("@CORREO_ELEC", obj.Correo)
            datUsuario.InsertCommand.Parameters.AddWithValue("@ID_PERFIL", obj.Perfil)
            datUsuario.InsertCommand.Parameters.AddWithValue("@ESTADO", obj.Estado)

            datUsuario.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub
    'VALIDAR EXISTENCIA DE RUT YA INGRESADOS
    Public Sub CONSULTAR_EXISTENCIA_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuario.SelectCommand = cn.CreateCommand
            datUsuario.SelectCommand.CommandText = "SP_EXISTENCIA_USUARIO"
            datUsuario.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuario.SelectCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.SelectCommand.ExecuteNonQuery()
            obj.Rut1 = datUsuario.SelectCommand.ExecuteScalar()

        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    'METODOS PARA CARGAR DROPDOWNLISTS
    Public datPerfil As New SqlDataAdapter
    Public Function LISTAR_PERFILES() As DataSet
        Dim cn As New SqlConnection(cadena)
        Dim dteperfil As New DataSet
        Try
            cn.Open()
            datPerfil.SelectCommand = cn.CreateCommand
            datPerfil.SelectCommand.CommandText = "SP_LISTAR_PERFIL"
            datPerfil.SelectCommand.CommandType = CommandType.StoredProcedure
            datPerfil.SelectCommand.ExecuteNonQuery()
            datPerfil.Fill(dteperfil)
            Return dteperfil
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

    Public datEspecialidad As New SqlDataAdapter
    Public Function LISTAR_ESPECIALIDAD() As DataSet
        Dim cn As New SqlConnection(cadena)
        Dim dteEspecialidad As New DataSet
        Try
            cn.Open()
            datPerfil.SelectCommand = cn.CreateCommand
            datPerfil.SelectCommand.CommandText = "SP_LISTAR_ESPECIALIDAD"
            datPerfil.SelectCommand.CommandType = CommandType.StoredProcedure
            datPerfil.SelectCommand.ExecuteNonQuery()
            datPerfil.Fill(dteEspecialidad)
            Return dteEspecialidad
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
    'CARGAR DATOS USUARIO PARA MODIFICARLOS 

    Public Function CARGAR_DATOS_USUARIOS(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Dim dteperfil As New DataSet
        Try
            cn.Open()
            datUsuario.SelectCommand = cn.CreateCommand
            datUsuario.SelectCommand.CommandText = "SP_BUSCAR_POR_RUTmod"
            datUsuario.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuario.SelectCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.SelectCommand.ExecuteNonQuery()
            obj.Rut1 = datUsuario.SelectCommand.ExecuteScalar()
            datUsuario.Fill(dteperfil)
            Return (dteperfil)
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

    Public Function CARGAR_ESTADO_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Dim dteperfil As New DataSet
        Try
            cn.Open()
            datUsuario.SelectCommand = cn.CreateCommand
            datUsuario.SelectCommand.CommandText = "SP_BUSCAR_POR_RUT_ESTADO"
            datUsuario.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuario.SelectCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.SelectCommand.ExecuteNonQuery()
            obj.Rut1 = datUsuario.SelectCommand.ExecuteScalar()
            datUsuario.Fill(dteperfil)
            Return (dteperfil)
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
    Public Function CARGAR_CONTRASEÑA_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Dim dteperfil As New DataSet
        Try
            cn.Open()
            datUsuario.SelectCommand = cn.CreateCommand
            datUsuario.SelectCommand.CommandText = "SP_BUSCAR_POR_RUT_CONTRASENIA"
            datUsuario.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuario.SelectCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.SelectCommand.ExecuteNonQuery()
            obj.Rut1 = datUsuario.SelectCommand.ExecuteScalar()
            datUsuario.Fill(dteperfil)
            Return (dteperfil)
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
    Public Function CARGAR_DDL_PROFESIONALES(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Dim dteperfil As New DataSet
        Try
            cn.Open()
            datUsuario.SelectCommand = cn.CreateCommand
            datUsuario.SelectCommand.CommandText = "SP_BUSCAR_POR_ESPECIALIDAD"
            datUsuario.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuario.SelectCommand.Parameters.AddWithValue("@ID_ESPECIALIDAD", obj.Especialidad)
            datUsuario.SelectCommand.ExecuteNonQuery()
            obj.Especialidad1 = datUsuario.SelectCommand.ExecuteScalar()
            datUsuario.Fill(dteperfil)
            Return (dteperfil)
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


    'MODIFICAR DATOS DE USUARIOS
    Public Sub MODIFICAR_USUARIOS(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuario.UpdateCommand = cn.CreateCommand
            datUsuario.UpdateCommand.CommandType = CommandType.StoredProcedure
            datUsuario.UpdateCommand.CommandText = "SP_MODIFICARDATOS_USUARIO"
            datUsuario.UpdateCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@RUT1", obj.Rut1)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@NOMBRES", obj.Nombres)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@APELLIDOS", obj.Apellidos)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@SEXO", obj.Sexo)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.Fecha_Nacimiento)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@DIRECCION", obj.Direccion)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@FONO", obj.Fono)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@CORREO_ELEC", obj.Correo)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@ID_ESPECIALIDAD", obj.Especialidad)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@ID_PERFIL", obj.Perfil)
            datUsuario.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub
    Public Sub MODIFICAR_USUARIOS_SINESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuario.UpdateCommand = cn.CreateCommand
            datUsuario.UpdateCommand.CommandType = CommandType.StoredProcedure
            datUsuario.UpdateCommand.CommandText = "SP_MODIFICARDATOS_USUARIO_sinESPECIALIDAD"
            datUsuario.UpdateCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@RUT1", obj.Rut1)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@NOMBRES", obj.Nombres)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@APELLIDOS", obj.Apellidos)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@SEXO", obj.Sexo)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.Fecha_Nacimiento)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@DIRECCION", obj.Direccion)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@FONO", obj.Fono)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@CORREO_ELEC", obj.Correo)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@ID_PERFIL", obj.Perfil)
            datUsuario.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub
    Public Sub MODIFICAR_ESTADO_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuario.UpdateCommand = cn.CreateCommand
            datUsuario.UpdateCommand.CommandType = CommandType.StoredProcedure
            datUsuario.UpdateCommand.CommandText = "SP_MODIFICAR_ESTADO_USUARIO"
            datUsuario.UpdateCommand.Parameters.AddWithValue("@RUT1", obj.Rut1)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@ESTADO", obj.Estado)
            datUsuario.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub
    Public Sub MODIFICAR_CONTRASEÑA(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuario.UpdateCommand = cn.CreateCommand
            datUsuario.UpdateCommand.CommandType = CommandType.StoredProcedure
            datUsuario.UpdateCommand.CommandText = "SP_MODIFICAR_CONTRASEÑA"
            datUsuario.UpdateCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@CONTRASEÑA", obj.Contrasenia)
            datUsuario.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub MODIFICAR_HORARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try
            cn.Open()
            datUsuario.UpdateCommand = cn.CreateCommand
            datUsuario.UpdateCommand.CommandText = "SP_MODIFICAR_HORARIO"
            datUsuario.UpdateCommand.CommandType = CommandType.StoredProcedure
            datUsuario.UpdateCommand.Parameters.AddWithValue("@HORA_INICIO_1", obj.HORA_INICIO_1)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@MINUTO_INICIO_1", obj.MINUTO_INICIO_1)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@HORA_TERMINO_2", obj.HORA_TERMINO_2)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@MINUTO_TERMINO_2", obj.MINUTO_TERMINO_2)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@HORA_INICIO_3", obj.HORA_INICIO_3)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@MINUTO_INICIO_3", obj.MINUTO_INICIO_3)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@HORA_TERMINO_4", obj.HORA_TERMINO_4)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@MINUTO_TERMINO_4", obj.MINUTO_TERMINO_4)
            datUsuario.UpdateCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    'INSERTAR HORARIO
    Public Sub INSERTAR_ASIGNACION_DEHORARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Try

            cn.Open()
            datUsuario.InsertCommand = cn.CreateCommand
            datUsuario.InsertCommand.CommandText = "SP_INSERTAR_HORARIO"
            datUsuario.InsertCommand.CommandType = CommandType.StoredProcedure
            datUsuario.InsertCommand.Parameters.AddWithValue("@HORA_INICIO_1", obj.HORA_INICIO_1)
            datUsuario.InsertCommand.Parameters.AddWithValue("@MINUTO_INICIO_1", obj.MINUTO_INICIO_1)
            datUsuario.InsertCommand.Parameters.AddWithValue("@HORA_TERMINO_2", obj.HORA_TERMINO_2)
            datUsuario.InsertCommand.Parameters.AddWithValue("@MINUTO_TERMINO_2", obj.MINUTO_TERMINO_2)
            datUsuario.InsertCommand.Parameters.AddWithValue("@HORA_INICIO_3", obj.HORA_INICIO_3)
            datUsuario.InsertCommand.Parameters.AddWithValue("@MINUTO_INICIO_3", obj.MINUTO_INICIO_3)
            datUsuario.InsertCommand.Parameters.AddWithValue("@HORA_TERMINO_4", obj.HORA_TERMINO_4)
            datUsuario.InsertCommand.Parameters.AddWithValue("@MINUTO_TERMINO_4", obj.MINUTO_TERMINO_4)
            datUsuario.InsertCommand.Parameters.AddWithValue("@DIA", obj.DIA)
            datUsuario.InsertCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.InsertCommand.ExecuteNonQuery()
        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Dispose()
                cn.Close()
            End If
        End Try
    End Sub

    Public Function CARGAR_HORARIOA_MODIFICAR(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Dim dteperfil As New DataSet
        Try
            cn.Open()
            datUsuario.SelectCommand = cn.CreateCommand
            datUsuario.SelectCommand.CommandText = "SP_CARGAR_HORARIO_aMODIFICAR"
            datUsuario.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuario.SelectCommand.Parameters.AddWithValue("@RUT", obj.Rut)
            datUsuario.SelectCommand.ExecuteNonQuery()
            obj.Rut1 = datUsuario.SelectCommand.ExecuteScalar()
            datUsuario.Fill(dteperfil)
            Return (dteperfil)
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

    Public Function CARGAR_NOMBRE_APELLIDO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim cn As New SqlConnection(cadena)
        Dim dteperfil As New DataSet
        Try
            cn.Open()
            datUsuario.SelectCommand = cn.CreateCommand
            datUsuario.SelectCommand.CommandText = "SP_NOMBRE_APELLIDO"
            datUsuario.SelectCommand.CommandType = CommandType.StoredProcedure
            datUsuario.SelectCommand.Parameters.AddWithValue("@rut", obj.Rut)
            datUsuario.SelectCommand.ExecuteNonQuery()
            datUsuario.Fill(dteperfil)
            Return (dteperfil)
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
