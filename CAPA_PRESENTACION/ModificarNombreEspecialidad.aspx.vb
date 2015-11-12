Public Class ModificarNombreEspecialidad
    Inherits System.Web.UI.Page
    Public objnegocio As New CAPA_NEGOCIO.CpN_Clc_Especialidad
    Public objentidad As New CAPA_ENTIDAD.CpE_Clc_Especialidad

    Public Sub CARGARNOMBRE()
        Try
            Dim dsCargarEspecialidad As New DataSet
            dsCargarEspecialidad = objnegocio.LISTAR_ESPECIALIDADESACTIVAS
            Me.DropDownNombre.DataSource = dsCargarEspecialidad
            Me.DropDownNombre.DataValueField = "NOMBRE_ESPECIALIDAD"
            Me.DropDownNombre.DataTextField = "NOMBRE_ESPECIALIDAD"
            Me.DropDownNombre.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DropDownNombre_Init(sender As Object, e As EventArgs) Handles DropDownNombre.Init
        CARGARNOMBRE()
    End Sub

    Public Sub MODIFICARNOMBREESP()
        Try
            objentidad.NombreEspCons = TxtNuevoNombre.Text
            objnegocio.NOMBRE_ESPECIALIDAD(objentidad)
            If TxtNuevoNombre.Text = objentidad.NombreEsp Then
                LblError.Visible = True
                LblError.Text = TxtNuevoNombre.Text + " ya es encuentra registrada en el sistema"
            Else
                LblError.Visible = False
                objentidad.NombreEsp = DropDownNombre.SelectedValue
                objentidad.NombreEspCons = TxtNuevoNombre.Text
                objnegocio.MODIFICAR_NOMBRE_ESPECIALIDAD(objentidad)
                MsgBox(DropDownNombre.SelectedValue + " ha sido modificado", MsgBoxStyle.Information, "Modificación")
                DropDownNombre.Items.Clear()
                CARGARNOMBRE()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        MODIFICARNOMBREESP()
    End Sub
End Class