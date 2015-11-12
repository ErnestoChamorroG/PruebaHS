Public Class CpN_Clc_Login
    Function LOGIN(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Login)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Login
        Return objdatos.LOGIN(obj)
    End Function

    Public Sub CONSULTAR_EXISTENCIA_USUARIO(ByVal obj As CAPA_ENTIDAD.CpE_Clc_Login)
        Dim objdatos As New CAPA_DATOS.CpD_Clc_Login
        objdatos.CONSULTAR_EXISTENCIA_USUARIO(obj)
    End Sub
End Class
