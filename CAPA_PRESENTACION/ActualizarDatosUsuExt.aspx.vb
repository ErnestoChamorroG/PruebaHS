Public Class ActualizarDatosUsuExt
    Inherits System.Web.UI.Page
    Public objnegocio As New CAPA_NEGOCIO.CpN_Clc_UsuarioPagWEb
    Public objentidad As New CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb

    Private Sub ActualizarDatosUsuExt_Init(sender As Object, e As EventArgs) Handles Me.Init
        CARGARDATOS()
    End Sub

    Public Sub CARGARDATOS()
        Try
            objentidad.Rut = Session("rut")
            objnegocio.LISTARDATOSUSUEXT(objentidad)
            Dim dsCargardatos As New DataSet
            dsCargardatos = objnegocio.LISTARDATOSUSUEXT(objentidad)
            TxtRut.Text = dsCargardatos.Tables(0).Rows(0).Item(0).ToString
            TxtNombres.Text = dsCargardatos.Tables(0).Rows(0).Item(1).ToString
            TxtApellidos.Text = dsCargardatos.Tables(0).Rows(0).Item(2).ToString
            TxtFechaNac.Text = CDate(dsCargardatos.Tables(0).Rows(0).Item(3).ToString)
            TxtDireccion.Text = dsCargardatos.Tables(0).Rows(0).Item(4).ToString
            TxtFono.Text = dsCargardatos.Tables(0).Rows(0).Item(5).ToString
            TxtEmail.Text = dsCargardatos.Tables(0).Rows(0).Item(6).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        ACTUALIZAR()
    End Sub

    Public Sub ACTUALIZAR()
        Try
            If (Txtpass.Text <> TxtRepPass.Text) Then
                LblErrorPass.Visible = True
                LblErrorPass.Text = "La contraseñas debe coincidir"
            Else
                objentidad.Rut = TxtRut.Text
                LblErrorPass.Visible = False
                objentidad.Direccion = TxtDireccion.Text
                objentidad.Fono = TxtFono.Text
                objentidad.Email = TxtEmail.Text
                objentidad.Contrasena = TxtRepPass.Text
                objnegocio.ACTUALIZAR_DATOS_USU_EXT(objentidad)
                MsgBox("Datos Actualizados!!", MsgBoxStyle.Information, "Actualización")
                CARGARDATOS()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarDatosUsuExt_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Convert.ToInt16(Session("perfil")) <> 3 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class