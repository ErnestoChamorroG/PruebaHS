Imports CAPA_DATOS
Imports CAPA_ENTIDAD

Public Class CpN_Clc_Usuarios

    Public Sub INSERTAR_USUARIOS(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.INSERTAR_USUARIOS(obj)
    End Sub
    Public Sub INSERTAR_USUARIOS_SINESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.INSERTAR_USUARIOS_SINESPECIALIDAD(obj)
    End Sub

    Public Sub COSULTAR_EXISTENCIA_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.CONSULTAR_EXISTENCIA_USUARIO(obj)
    End Sub

    Function LISTAR_PERFILES()
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        Return objdatos.LISTAR_PERFILES
    End Function

    Function LISTAR_ESPECIALIDAD()
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        Return objdatos.LISTAR_ESPECIALIDAD
    End Function
    Public Sub MODIFICAR_USUARIOS(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.MODIFICAR_USUARIOS(obj)
    End Sub
    Public Sub MODIFICAR_USUARIOS_SINESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.MODIFICAR_USUARIOS_SINESPECIALIDAD(obj)
    End Sub
    Public Sub MODIFICAR_ESTADO_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.MODIFICAR_ESTADO_USUARIO(obj)
    End Sub
    Public Sub MODIFICAR_CONTRASEÑA(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.MODIFICAR_CONTRASEÑA(obj)
    End Sub

    Public Function CARGAR_DATOS_USUARIOS(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        Return objdatos.CARGAR_DATOS_USUARIOS(obj)
    End Function
    Public Function CARGAR_ESTADO_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        Return objdatos.CARGAR_ESTADO_USUARIO(obj)
    End Function
    Public Function CARGAR_CONTRASEÑA_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        Return objdatos.CARGAR_CONTRASEÑA_USUARIO(obj)
    End Function

    Public Function CARGAR_DDL_PROFESIONALES(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        Return objdatos.CARGAR_DDL_PROFESIONALES(obj)
    End Function

    Public Sub MODIFICAR_HORARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.MODIFICAR_HORARIO(obj)
    End Sub

    Public Sub INSERTAR_ASIGNACION_DEHORARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        objdatos.INSERTAR_ASIGNACION_DEHORARIO(obj)
    End Sub

    Public Function CARGAR_HORARIOA_MODIFICAR(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        Return objdatos.CARGAR_HORARIOA_MODIFICAR(obj)
    End Function

    Function CARGAR_NOMBRE_APELLIDO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Usuarios)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Usuarios
        Return objdatos.CARGAR_NOMBRE_APELLIDO(obj)
    End Function
End Class
