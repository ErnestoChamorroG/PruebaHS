Public Class AgregarEspecialidad1
    Inherits System.Web.UI.Page
    Public objnegocio As New CAPA_NEGOCIO.CpN_Clc_Especialidad
    Public objentidad As New CAPA_ENTIDAD.CpE_Clc_Especialidad
    Protected Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        INSERTAR()
    End Sub

    Public Sub INSERTAR()
        Try
            Dim nombre As String
            objentidad.NombreEspCons = TxtNombre.Text
            objnegocio.NOMBRE_ESPECIALIDAD(objentidad)
            nombre = objentidad.NombreEsp
            If (TxtNombre.Text = "") Then
                LblErrorNombre.Text = ("El campo esta vacio")
                LblErrorNombre.Visible = True
            ElseIf (TxtNombre.Text = nombre) Then
                LblErrorNombre.Text = ("La especialidad ingresada ya se encuentra en el sistema")
                LblErrorNombre.Visible = True
            Else
                objentidad.NombreEsp = TxtNombre.Text
                objentidad.Estado = TxtEstado.Text
                objnegocio.INSERTAR_ESPECIALIDAD(objentidad)
                LblErrorNombre.Visible = False
                MsgBox("Registro exitoso!!", MsgBoxStyle.Information, "REGISTRO")
                TxtNombre.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class