Public Class CpN_Clc_UsuarioPagWEb
    Public Sub REGISTRAR_USUARIO_EXT(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_UsuarioPagWeb
        objdatos.REGISTRARUSUARIOEXTERNO(obj)
    End Sub

    Public Sub CONSULTAR_EXISTENCIA_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_UsuarioPagWeb
        objdatos.CONSULTAR_EXISTENCIA_USUARIO(obj)
    End Sub

    Function LISTARDATOSUSUEXT(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_UsuarioPagWeb
        Return objdatos.LISTAR_DATOS_USU_EXT(obj)
    End Function

    Public Sub ACTUALIZAR_DATOS_USU_EXT(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_UsuarioPagWeb
        objdatos.ACTUALIZAR_DATOS_USU_ETX(obj)
    End Sub

    Function LISTAR_DATOS_PASS(ByVal obj As CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_UsuarioPagWeb
        Return objdatos.LISTAR_DATOS_Pass(obj)
    End Function
End Class
