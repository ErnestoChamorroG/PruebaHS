Public Class PaginaMaestra
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("usuario") = "") Then
            HprLnkRegistrarse.Visible = True
            HprLnkIniciaresion.Visible = True
            BtnSalir.Visible = False
            LblNombre.Visible = False
        Else
            HprLnkRegistrarse.Visible = False
            HprLnkIniciaresion.Visible = False
            HprLnkRecuperarPass.Visible = False
            BtnSalir.Visible = True
            LblNombre.Visible = True
            LblNombre.Text = Session("Usuario")
        End If

        If (Convert.ToInt16(Session("perfil") = 3)) Then
            HypLinkActualizarD.Visible = True
        End If
    End Sub

    Protected Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        If MsgBox("Desea cerrar sesión?", vbYesNo, "Salir") = vbYes Then
            Session.RemoveAll()
            Response.Redirect("/Index.aspx")
        End If
    End Sub
End Class