Public Class DeshabilitarEspecialidad
    Inherits System.Web.UI.Page
    Public objnegocio As New CAPA_NEGOCIO.CpN_Clc_Especialidad
    Public objentidad As New CAPA_ENTIDAD.CpE_Clc_Especialidad

    Private Sub DropDownNombre_Init(sender As Object, e As EventArgs) Handles DropDownNombre.Init
        LISTARESPECIALIDAD()
    End Sub
    Public Sub LISTARESPECIALIDAD()
        Try
            Dim dsListarEsp As New DataSet
            dsListarEsp = objnegocio.LISTAR_ESPECIALIDADES
            Me.DropDownNombre.DataSource = dsListarEsp
            Me.DropDownNombre.DataValueField = "NOMBRE_ESPECIALIDAD"
            Me.DropDownNombre.DataTextField = "NOMBRE_ESPECIALIDAD"
            Me.DropDownNombre.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        MODIFICAR_EST_ESP()
    End Sub

    Public Sub CARGARESTADO()
        Try
            objentidad.NombreEspCons = DropDownNombre.SelectedValue
            objnegocio.MOSTRAR_ESTADO_ESPECIALIDAD(objentidad)
            TxtEstadoActual.Text = objentidad.NombreEsp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DropDownNombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownNombre.SelectedIndexChanged
        CARGARESTADO()
    End Sub

    Public Sub MODIFICAR_EST_ESP()
        Try
            objentidad.NombreEsp = DropDownNombre.SelectedValue
            objentidad.Estado = DropDownNuevoEstado.SelectedValue
            objnegocio.MODIFICAR_ESTADO_ESPECIALIDAD(objentidad)
            MsgBox(DropDownNombre.SelectedValue + " ha sido " + DropDownNuevoEstado.SelectedValue, MsgBoxStyle.Information, "Modificación")
            CARGARESTADO()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class