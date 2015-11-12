Public Class CpN_Clc_Especialidad
    Public Sub INSERTAR_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Especialidad
        objdatos.INSERTAR_ESPECIALIDAD(obj)
    End Sub

    Public Sub NOMBRE_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Especialidad
        objdatos.CONSULTAR_NOMBRE_ESPECIALIDAD(obj)
    End Sub

    Function LISTAR_ESPECIALIDADES()
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Especialidad
        Return objdatos.LISTAR_ESPECIALIDADES
    End Function

    Public Sub MOSTRAR_ESTADO_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Especialidad
        objdatos.MOSTRAR_ESTADO_ESPECIALIDAD(obj)
    End Sub

    Public Sub MODIFICAR_ESTADO_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Especialidad
        objdatos.MODIFICAR_ESTADO_ESPECIALIDAD(obj)
    End Sub

    Public Sub MODIFICAR_NOMBRE_ESPECIALIDAD(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Especialidad)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Especialidad
        objdatos.MODIFICAR_NOMBRE_ESPECIALIDAD(obj)
    End Sub

    Function LISTAR_ESPECIALIDADESACTIVAS()
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Especialidad
        Return objdatos.LISTAR_ESPECIALIDADES_ACTIVAS
    End Function
End Class
