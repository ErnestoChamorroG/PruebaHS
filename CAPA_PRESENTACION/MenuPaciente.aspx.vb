Public Class MenuPaciente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Convert.ToInt16(Session("perfil")) <> 3 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

End Class