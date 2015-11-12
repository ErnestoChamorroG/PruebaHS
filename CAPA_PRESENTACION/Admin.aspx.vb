Public Class Admin
    Inherits System.Web.UI.Page
    Public objnegocio As New CAPA_NEGOCIO.CpN_Clc_Usuarios
    Public objentidad As New CAPA_ENTIDAD.CpE_Clc_Usuarios
    Public objnegocioE As New CAPA_NEGOCIO.CpN_Clc_Especialidad
    Public objentidadE As New CAPA_ENTIDAD.CpE_Clc_Especialidad

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Convert.ToInt16(Session("perfil")) <> 0 Or Session("perfil").ToString = "") Then
            Response.Redirect("~/Index.aspx")
        End If
        If Not IsPostBack Then
            Try
                Dim dsListarEsp As New DataSet
                dsListarEsp = objnegocio.LISTAR_ESPECIALIDAD
                Me.ddlAsignarEspecialidadAH.DataSource = dsListarEsp
                Me.ddlAsignarEspecialidadAH.DataValueField = "ID_ESPECIALIDAD"
                Me.ddlAsignarEspecialidadAH.DataTextField = "NOMBRE_ESPECIALIDAD"
                Me.ddlAsignarEspecialidadAH.DataBind()

                'Dim dsListarEsp2 As New DataSet
                'dsListarEsp = objnegocio.LISTAR_ESPECIALIDAD
                Me.ddlAsignarEspecialidad_MH.DataSource = dsListarEsp
                Me.ddlAsignarEspecialidad_MH.DataValueField = "ID_ESPECIALIDAD"
                Me.ddlAsignarEspecialidad_MH.DataTextField = "NOMBRE_ESPECIALIDAD"
                Me.ddlAsignarEspecialidad_MH.DataBind()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End If
    End Sub

    'EVENTOS PARA CARGAR DROPDOWNLIST
    Private Sub ddlPerfilesNC_Init(sender As Object, e As EventArgs) Handles ddlPerfilesNC.Init


        Dim dsListarPer As New DataSet
        dsListarPer = objnegocio.LISTAR_PERFILES
        Me.ddlPerfilesNC.DataSource = dsListarPer
        Me.ddlPerfilesNC.DataValueField = "NOMBRE_PERFIL"
        Me.ddlPerfilesNC.DataTextField = "NOMBRE_PERFIL"
        Me.ddlPerfilesNC.DataBind()
    End Sub

    Private Sub ddlAsignarEspecialidadNC_Init(sender As Object, e As EventArgs) Handles ddlAsignarEspecialidadNC.Init
        Dim dsListarEsp As New DataSet
        dsListarEsp = objnegocio.LISTAR_ESPECIALIDAD
        Me.ddlAsignarEspecialidadNC.DataSource = dsListarEsp
        Me.ddlAsignarEspecialidadNC.DataValueField = "NOMBRE_ESPECIALIDAD"
        Me.ddlAsignarEspecialidadNC.DataTextField = "NOMBRE_ESPECIALIDAD"
        Me.ddlAsignarEspecialidadNC.DataBind()
    End Sub
    Private Sub ddlPerfilesMOD_Init(sender As Object, e As EventArgs) Handles ddlPerfilesMOD.Init
        Dim dsListarPer As New DataSet
        dsListarPer = objnegocio.LISTAR_PERFILES
        Me.ddlPerfilesMOD.DataSource = dsListarPer
        Me.ddlPerfilesMOD.DataValueField = "NOMBRE_PERFIL"
        Me.ddlPerfilesMOD.DataTextField = "NOMBRE_PERFIL"
        Me.ddlPerfilesMOD.DataBind()
    End Sub

    Private Sub ddlAsignarEspecialidadMOD_Init(sender As Object, e As EventArgs) Handles ddlAsignarEspecialidadMOD.Init
        Dim dsListarEsp As New DataSet
        dsListarEsp = objnegocio.LISTAR_ESPECIALIDAD
        Me.ddlAsignarEspecialidadMOD.DataSource = dsListarEsp
        Me.ddlAsignarEspecialidadMOD.DataValueField = "NOMBRE_ESPECIALIDAD"
        Me.ddlAsignarEspecialidadMOD.DataTextField = "NOMBRE_ESPECIALIDAD"
        Me.ddlAsignarEspecialidadMOD.DataBind()
    End Sub

    Protected Sub ddlPerfilesNC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPerfilesNC.SelectedIndexChanged

        If ddlPerfilesNC.SelectedItem.Text = "Profesional de la salud" Then

            lblAsignarEspecialidadNC.Visible = True
            ddlAsignarEspecialidadNC.Visible = True
        Else

            lblAsignarEspecialidadNC.Visible = False
            ddlAsignarEspecialidadNC.Visible = False

        End If
    End Sub

    'CASE PARA CAMBIAR MULTIVIEWS EN LA PAGINA

    Private Sub LinkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkbtnCrearCuenta.Click,
        LinkBtnModificardatos.Click, LinkBtnModificarEstado.Click, LinkBtnReestrablecerContra.Click, LinkbtnRegistrarHorario.Click, LinkBtnRegistrarEspecialidad.Click,
        LinkBtnModificarNombreEspecialidad.Click, linkBtnDeshabilitarEspecialidad.Click, LinkbtnRegistrarHorario.Click, LinkbtnModificarHorario.Click


        Select Case DirectCast(sender, LinkButton).CommandName

            Case "Crear Cuenta"
                MW_CuentasUsuarios.ActiveViewIndex = 1
                CleanControls(Me.Controls)
                lblMensajeRegistroExitosoNC.Text = ""
            Case "Modificar Datos"
                MW_CuentasUsuarios.ActiveViewIndex = 2
                CleanControls(Me.Controls)
                lblmensaje1MOD.Text = ""

            Case "ModificarEstado"
                MW_CuentasUsuarios.ActiveViewIndex = 3
                CleanControls(Me.Controls)
                lblregistroexitosoMOES.Text = ""
            Case "ReestablecerContra"
                MW_CuentasUsuarios.ActiveViewIndex = 4
                CleanControls(Me.Controls)
                lblregistroexitosoReescontra.Text = ""
            Case "RegistrarHorario"
                MW_CuentasUsuarios.ActiveViewIndex = 5
            Case "ModificarHorario"
                MW_CuentasUsuarios.ActiveViewIndex = 6
            Case "RegistrarEspecialidad"
                MW_CuentasUsuarios.ActiveViewIndex = 7
                CleanControls(Me.Controls)
            Case "ModificarNombreEspecilidad"
                MW_CuentasUsuarios.ActiveViewIndex = 8
                CleanControls(Me.Controls)
            Case "DeshabilitarEspecialidad"
                MW_CuentasUsuarios.ActiveViewIndex = 9
                CleanControls(Me.Controls)
        End Select
    End Sub


    Protected Sub btnAceptarNuevaCuenta_Click(sender As Object, e As EventArgs) Handles btnAceptarNuevaCuenta.Click

        Try
            Dim rutLimpio As String
            Dim digitoVerificador As String
            Dim suma As Integer
            Dim contador As Integer = 2


            rutLimpio = Me.txtRutNC.Text
            rutLimpio = rutLimpio.Replace("-", "")
            rutLimpio = rutLimpio.Replace(" ", "")
            rutLimpio = rutLimpio.Substring(0, rutLimpio.Length - 1)
            digitoVerificador = Me.txtRutNC.Text.Substring(txtRutNC.Text.Length - 1, 1)

            Dim i As Integer

            For i = rutLimpio.Length - 1 To 0 Step -1

                If contador > 7 Then
                    contador = 2
                End If

                suma += Integer.Parse(rutLimpio(i).ToString()) * contador
                contador += 1
            Next

            Dim dv As Integer = 11 - (suma Mod 11)
            Dim DigVer As String = dv.ToString()

            If DigVer = "10" Then
                DigVer = "K"
            End If

            If DigVer = "11" Then
                DigVer = "0"
            End If

            If DigVer = digitoVerificador.ToUpper Then
                lblMensajeErrorRUTNC.ForeColor = Drawing.Color.Blue
                lblMensajeErrorRUTNC.Text = ("*Rut valido*")
                lblMensajeErrorRUTNC.Visible = True
                INSERTAR_USUARIO()
                CleanControls(Me.Controls)
            Else
                lblMensajeErrorRUTNC.BackColor = Drawing.Color.Red
                lblMensajeErrorRUTNC.Text = ("*Rut invalido, ingrese una valido*")
                lblMensajeErrorRUTNC.Visible = True

            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Protected Sub btnModificarCuentaMOD_Click(sender As Object, e As EventArgs) Handles btnModificarCuentaMOD.Click
        MODIFICAR_USUARIO()
        CleanControls(Me.Controls)
    End Sub
    Protected Sub ddlPerfilesMOD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPerfilesMOD.SelectedIndexChanged
        If ddlPerfilesMOD.SelectedIndex = 2 Then

            lblAsignarEspecialidadMOD.Visible = True
            ddlAsignarEspecialidadMOD.Visible = True
        Else

            lblAsignarEspecialidadMOD.Visible = False
            ddlAsignarEspecialidadMOD.Visible = False

        End If
    End Sub

    Protected Sub btnLimpiarNuevaCuenta_Click(sender As Object, e As EventArgs) Handles btnLimpiarNuevaCuenta.Click
        CleanControls(Me.Controls)
        'lblMesajeErrorMC.Text = ""
        'lblmensajeError2NC.Text = ""
        'lblMensajeRegistroExitosoNC.Text = ""
        'lblMensajeErrorRUTNC.Text = ""
    End Sub



    Protected Sub BtnBuscarPorRutMOD_Click(sender As Object, e As EventArgs) Handles BtnBuscarPorRutMOD.Click

        Try
            Dim dsListarPer As New DataSet
            objentidad.Rut = txtBuscarporRUTMOD.Text
            dsListarPer = objnegocio.CARGAR_DATOS_USUARIOS(objentidad)

            ''objentidad.Rut = txtBuscarporRUTMOD.Text
            If txtBuscarporRUTMOD.Text = objentidad.Rut1 Then
                lblmensaje1MOD.Text = ""
                lblmensaje2MOD.Text = ""
                LblVistaRUTMOD.ForeColor = Drawing.Color.Black
                LblVistaRUTMOD.Text = ("El Rut asociado es : ") + dsListarPer.Tables(0).Rows(0).Item(0).ToString
                LblVistaRUTMOD.Visible = True
                txtNombresMOD.Text = dsListarPer.Tables(0).Rows(0).Item(1).ToString
                txtApellidosMOD.Text = dsListarPer.Tables(0).Rows(0).Item(2).ToString
                ddlSexoMOD.SelectedValue = dsListarPer.Tables(0).Rows(0).Item(3).ToString
                txtFechaNacimientoMOD.Text = CDate(dsListarPer.Tables(0).Rows(0).Item(4))
                txtDireccionMOD.Text = dsListarPer.Tables(0).Rows(0).Item(5).ToString
                txtFonoMOD.Text = dsListarPer.Tables(0).Rows(0).Item(6).ToString
                txtCorreoMOD.Text = dsListarPer.Tables(0).Rows(0).Item(7).ToString
                ddlPerfilesMOD.SelectedIndex = dsListarPer.Tables(0).Rows(0).Item(9).ToString

            Else
                lblmensaje1MOD.Text = ""
                LblVistaRUTMOD.ForeColor = Drawing.Color.Red
                LblVistaRUTMOD.Text = ("El rut ingresado no existe")
                LblVistaRUTMOD.Visible = True
                CleanControls(Me.Controls)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub INSERTAR_USUARIO()

        Try
            objentidad.Rut = txtRutNC.Text
            objnegocio.COSULTAR_EXISTENCIA_USUARIO(objentidad)

            If (txtRutNC.Text = objentidad.Rut1) Then
                lblMensajeErrorRUTNC.ForeColor = Drawing.Color.Red
                lblMensajeErrorRUTNC.Text = ("El Rut ingresado ya existe")
                lblMesajeErrorMC.Visible = True
            ElseIf (txtContraseniaNC.Text <> txtRepetirContraNC.Text) Then
                lblmensajeError2NC.ForeColor = Drawing.Color.Red
                lblmensajeError2NC.Text = ("*Contraseñas no son iguales*")
                lblmensajeError2NC.Visible = True

            ElseIf (ddlPerfilesNC.SelectedValue <> "Profesional de la salud") Then
                objentidad.Rut = txtRutNC.Text
                objentidad.Rut1 = txtRutNC.Text
                objentidad.Nombres = txtNombresNC.Text
                objentidad.Apellidos = txtApellidosNC.Text
                objentidad.Sexo = ddlSexoNC.SelectedValue
                objentidad.Fecha_Nacimiento = txtFechaNacimientoNC.Text
                objentidad.Direccion = txtDireccionNC.Text
                objentidad.Fono = txtFonoNC.Text
                objentidad.Correo = txtCorreoNC.Text
                objentidad.Contrasenia = txtContraseniaNC.Text
                objentidad.Perfil = ddlPerfilesNC.SelectedIndex
                objentidad.Estado = ddlEstadoNC.SelectedValue
                objnegocio.INSERTAR_USUARIOS_SINESPECIALIDAD(objentidad)
                lblmensajeError2NC.Visible = False
                lblMesajeErrorMC.Visible = False
                lblMensajeRegistroExitosoNC.ForeColor = Drawing.Color.Blue
                lblMensajeRegistroExitosoNC.Visible = True
                lblMensajeRegistroExitosoNC.Text = ("Registro exitoso!!")

            Else
                objentidad.Rut = txtRutNC.Text
                objentidad.Rut1 = txtRutNC.Text
                objentidad.Nombres = txtNombresNC.Text
                objentidad.Apellidos = txtApellidosNC.Text
                objentidad.Sexo = ddlSexoNC.SelectedValue
                objentidad.Fecha_Nacimiento = txtFechaNacimientoNC.Text
                objentidad.Direccion = txtDireccionNC.Text
                objentidad.Fono = txtFonoNC.Text
                objentidad.Correo = txtCorreoNC.Text
                objentidad.Contrasenia = txtContraseniaNC.Text
                objentidad.Perfil = ddlPerfilesNC.SelectedIndex
                objentidad.Especialidad = ddlAsignarEspecialidadNC.SelectedIndex
                objentidad.Estado = ddlEstadoNC.SelectedValue
                objnegocio.INSERTAR_USUARIOS(objentidad)
                lblMesajeErrorMC.Visible = False
                lblMensajeRegistroExitosoNC.ForeColor = Drawing.Color.Blue
                lblMensajeRegistroExitosoNC.Visible = True
                lblMensajeRegistroExitosoNC.Text = ("Registro exitoso!!")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub MODIFICAR_USUARIO()

        Try
            objentidad.Rut = txtBuscarporRUTMOD.Text
            objnegocio.COSULTAR_EXISTENCIA_USUARIO(objentidad)

            If (ddlPerfilesMOD.SelectedIndex = 2) Then
                objentidad.Rut = txtBuscarporRUTMOD.Text
                objentidad.Rut1 = txtBuscarporRUTMOD.Text
                objentidad.Nombres = txtNombresMOD.Text
                objentidad.Apellidos = txtApellidosMOD.Text
                objentidad.Sexo = ddlSexoMOD.SelectedValue
                objentidad.Fecha_Nacimiento = txtFechaNacimientoMOD.Text
                objentidad.Direccion = txtDireccionMOD.Text
                objentidad.Fono = txtFonoMOD.Text
                objentidad.Correo = txtCorreoMOD.Text
                objentidad.Perfil = ddlPerfilesMOD.SelectedIndex
                objentidad.Especialidad = ddlAsignarEspecialidadMOD.SelectedIndex
                objnegocio.MODIFICAR_USUARIOS(objentidad)
                lblmensaje1MOD.ForeColor = Drawing.Color.Blue
                lblmensaje1MOD.Visible = True
                lblmensaje1MOD.Text = ("Registro exitoso!!")
                LblVistaRUTMOD.Text = ""

            Else

                objentidad.Rut = txtBuscarporRUTMOD.Text
                objentidad.Rut1 = txtBuscarporRUTMOD.Text
                objentidad.Nombres = txtNombresMOD.Text
                objentidad.Apellidos = txtApellidosMOD.Text
                objentidad.Sexo = ddlSexoMOD.SelectedValue
                objentidad.Fecha_Nacimiento = txtFechaNacimientoMOD.Text
                objentidad.Direccion = txtDireccionMOD.Text
                objentidad.Fono = txtFonoMOD.Text
                objentidad.Correo = txtCorreoMOD.Text
                objentidad.Perfil = ddlPerfilesMOD.SelectedIndex
                objnegocio.MODIFICAR_USUARIOS_SINESPECIALIDAD(objentidad)
                lblmensaje1MOD.ForeColor = Drawing.Color.Blue
                lblmensaje1MOD.Visible = True
                lblmensaje1MOD.Text = ("Registro exitoso!!")
                LblVistaRUTMOD.Text = ""


            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub BtnBuscarRutMOES_Click(sender As Object, e As EventArgs) Handles BtnBuscarRutMOES.Click
        Try
            Dim dsListarPer As New DataSet
            Dim dsNomApell As New DataSet
            objentidad.Rut = txtBuscarporRutMOES.Text
            dsListarPer = objnegocio.CARGAR_ESTADO_USUARIO(objentidad)
            dsNomApell = objnegocio.CARGAR_NOMBRE_APELLIDO(objentidad)

            ''objentidad.Rut = txtBuscarporRUTMOD.Text
            If txtBuscarporRutMOES.Text = objentidad.Rut1 Then
                lblregistroexitosoMOES.Text = ""
                LblRutAsociadoMOES.Visible = False
                LblRutAsociadoMOES.ForeColor = Drawing.Color.Black
                LblRutAsociadoMOES.Text = ("El nombre asociado es : ") + dsNomApell.Tables(0).Rows(0).Item(0).ToString + " " + dsNomApell.Tables(0).Rows(0).Item(1).ToString
                LblRutAsociadoMOES.Visible = True
                ddlMOESmodificarEstado.SelectedValue = dsListarPer.Tables(0).Rows(0).Item(1).ToString


            Else
                LblRutAsociadoMOES.ForeColor = Drawing.Color.Red
                LblRutAsociadoMOES.Text = ("El rut ingresado no existe")
                LblRutAsociadoMOES.Visible = True
                CleanControls(Me.Controls)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnAceptarMOES_Click(sender As Object, e As EventArgs) Handles btnAceptarMOES.Click
        MODIFICAR_ESTADO_USUARIO()
        CleanControls(Me.Controls)
    End Sub
    Public Sub MODIFICAR_ESTADO_USUARIO()

        Try
            objentidad.Rut = txtBuscarporRutMOES.Text
            objnegocio.COSULTAR_EXISTENCIA_USUARIO(objentidad)

            objentidad.Rut1 = txtBuscarporRutMOES.Text
            objentidad.Estado = ddlMOESmodificarEstado.SelectedValue
            objnegocio.MODIFICAR_ESTADO_USUARIO(objentidad)
            lblregistroexitosoMOES.BackColor = Drawing.Color.Blue
            lblregistroexitosoMOES.Visible = True
            lblregistroexitosoMOES.Text = ("Modificación exitosa!!")

            LblRutAsociadoMOES.Text = ""
            LblRutAsociadoMOES.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnAceptarReesContra_Click(sender As Object, e As EventArgs) Handles btnAceptarReesContra.Click
        MODIFICAR_CONTRASENIA_USUARIO()
        CleanControls(Me.Controls)

    End Sub
    Protected Sub btnBuscarReesContra_Click(sender As Object, e As EventArgs) Handles btnBuscarReesContra.Click
        Try
            Dim dsListarPer As New DataSet
            Dim dsNomApell As New DataSet
            objentidad.Rut = txtRUTReesContra.Text
            dsListarPer = objnegocio.CARGAR_CONTRASEÑA_USUARIO(objentidad)
            dsNomApell = objnegocio.CARGAR_NOMBRE_APELLIDO(objentidad)

            ''objentidad.Rut = txtBuscarporRUTMOD.Text
            If txtRUTReesContra.Text = objentidad.Rut1 Then
                lblregistroexitosoReescontra.Text = ""
                lblContraseñaAnterior.Text = ""
                lblRUTReescontra.Text = ""
                lblRUTReescontra.Text = ("El nombre asociado es : ") + dsNomApell.Tables(0).Rows(0).Item(0).ToString + " " + dsNomApell.Tables(0).Rows(0).Item(1).ToString
                lblRUTReescontra.Visible = True
                lblContraseñaAnterior.ForeColor = Drawing.Color.Blue
                lblContraseñaAnterior.Text = ("Contaseña anterior :") + dsListarPer.Tables(0).Rows(0).Item(1).ToString
            Else
                lblregistroexitosoReescontra.Text = ""
                lblRUTReescontra.ForeColor = Drawing.Color.Red
                lblRUTReescontra.Text = ("El rut ingresado no existe")
                lblRUTReescontra.Visible = True
                lblContraseñaAnterior.Text = ""
                CleanControls(Me.Controls)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub MODIFICAR_CONTRASENIA_USUARIO()

        Try
            objentidad.Rut = txtRUTReesContra.Text
            objnegocio.COSULTAR_EXISTENCIA_USUARIO(objentidad)

            objentidad.Rut1 = txtRUTReesContra.Text
            objentidad.Contrasenia = txtContraseniaReesContra.Text
            objnegocio.MODIFICAR_CONTRASEÑA(objentidad)

            lblregistroexitosoReescontra.ForeColor = Drawing.Color.Blue
            lblregistroexitosoReescontra.Visible = True
            lblregistroexitosoReescontra.Text = ("Contraseña modificada!!")
            lblRUTReescontra.Text = ""
            lblContraseñaAnterior.Text = ""

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub CleanControls(ByVal controles As ControlCollection)
        For Each control As Control In controles
            If TypeOf control Is TextBox Then
                DirectCast(control, TextBox).Text = String.Empty
            ElseIf TypeOf control Is DropDownList Then
                DirectCast(control, DropDownList).ClearSelection()
            ElseIf TypeOf control Is RadioButtonList Then
                DirectCast(control, RadioButtonList).ClearSelection()
            ElseIf TypeOf control Is CheckBoxList Then
                DirectCast(control, CheckBoxList).ClearSelection()
            ElseIf TypeOf control Is RadioButton Then
                DirectCast(control, RadioButton).Checked = False
            ElseIf TypeOf control Is CheckBox Then
                DirectCast(control, CheckBox).Checked = False
            ElseIf control.HasControls() Then
                CleanControls(control.Controls)
            End If
        Next
    End Sub

    'AGREGAR ESPECIALIDAD
    Public Sub INSERTAR()
        Try
            Dim nombre As String
            objentidadE.NombreEspCons = TxtNombre.Text
            objnegocioE.NOMBRE_ESPECIALIDAD(objentidadE)
            nombre = objentidadE.NombreEsp
            If (TxtNombre.Text = "") Then
                LblErrorNombre.Text = ("El campo esta vacio")
                LblErrorNombre.Visible = True
            ElseIf (TxtNombre.Text = nombre) Then
                LblErrorNombre.Text = ("La especialidad ingresada ya se encuentra en el sistema")
                LblErrorNombre.Visible = True
            Else
                objentidadE.NombreEsp = TxtNombre.Text
                objentidadE.Estado = LblEstadoNvaEsp.Text
                objnegocioE.INSERTAR_ESPECIALIDAD(objentidadE)
                LblErrorNombre.Visible = False
                If (Page.IsValid) Then
                    MsgBox("Registro exitoso!!", MsgBoxStyle.Information, "REGISTRO")
                    TxtNombre.Text = ""
                Else
                    MsgBox("El registro a fallado", MsgBoxStyle.Exclamation, "REGISTRO")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnAceptarEs_Click(sender As Object, e As EventArgs) Handles BtnAceptarEs.Click
        INSERTAR()
    End Sub

    'MODIFICAR NOMBRE ESPECIALIDAD
    Public Sub CARGARNOMBREACTIVAS()
        Try
            Dim dsCargarEspecialidad As New DataSet
            dsCargarEspecialidad = objnegocioE.LISTAR_ESPECIALIDADESACTIVAS
            Me.DropDownNombreEs.DataSource = dsCargarEspecialidad
            Me.DropDownNombreEs.DataValueField = "NOMBRE_ESPECIALIDAD"
            Me.DropDownNombreEs.DataTextField = "NOMBRE_ESPECIALIDAD"
            Me.DropDownNombreEs.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DropDownNombreEs_Init(sender As Object, e As EventArgs) Handles DropDownNombreEs.Init
        CARGARNOMBREACTIVAS()
    End Sub

    Public Sub MODIFICARNOMBREESP()
        Try
            objentidadE.NombreEspCons = TxtNuevoNombre.Text
            objnegocioE.NOMBRE_ESPECIALIDAD(objentidadE)
            If TxtNuevoNombre.Text = objentidadE.NombreEsp Then
                LblError.Visible = True
                LblError.Text = TxtNuevoNombre.Text + " ya es encuentra registrada en el sistema"
            Else
                LblError.Visible = False
                objentidadE.NombreEsp = DropDownNombreEs.SelectedValue
                objentidadE.NombreEspCons = TxtNuevoNombre.Text
                objnegocioE.MODIFICAR_NOMBRE_ESPECIALIDAD(objentidadE)
                MsgBox(DropDownNombreEs.SelectedValue + " ha sido modificado", MsgBoxStyle.Information, "Modificación")
                DropDownNombreEs.Items.Clear()
                CARGARNOMBREACTIVAS()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnModificarNes_Click(sender As Object, e As EventArgs) Handles BtnModificarNes.Click
        MODIFICARNOMBREESP()
    End Sub

    'DESHABILITAR ESPECIALIDAD
    Private Sub DropDownTdasEsp_Init(sender As Object, e As EventArgs) Handles DropDownTdasEsp.Init
        LISTARESPECIALIDAD()
    End Sub
    Public Sub LISTARESPECIALIDAD()
        Try
            Dim dsListarEsp As New DataSet
            dsListarEsp = objnegocioE.LISTAR_ESPECIALIDADES
            Me.DropDownTdasEsp.DataSource = dsListarEsp
            Me.DropDownTdasEsp.DataValueField = "NOMBRE_ESPECIALIDAD"
            Me.DropDownTdasEsp.DataTextField = "NOMBRE_ESPECIALIDAD"
            Me.DropDownTdasEsp.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Protected Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificarNes.Click
    '    MODIFICAR_EST_ESP()
    'End Sub

    Public Sub CARGARESTADO()
        Try
            objentidadE.NombreEspCons = DropDownTdasEsp.SelectedValue
            objnegocioE.MOSTRAR_ESTADO_ESPECIALIDAD(objentidadE)
            TxtEstadoActual.Text = objentidadE.Estado
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub DropDownTdasEsp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownTdasEsp.SelectedIndexChanged
        CARGARESTADO()
    End Sub

    Public Sub MODIFICAR_EST_ESP()
        Try
            objentidadE.NombreEsp = DropDownTdasEsp.SelectedValue
            objentidadE.Estado = DropDownNuevoEstado.SelectedValue
            objnegocioE.MODIFICAR_ESTADO_ESPECIALIDAD(objentidadE)
            MsgBox(DropDownTdasEsp.SelectedValue + " ha sido " + DropDownNuevoEstado.SelectedValue, MsgBoxStyle.Information, "Modificación")
            CARGARESTADO()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnModificarEs_Click1(sender As Object, e As EventArgs) Handles BtnModificarEs.Click
        MODIFICAR_EST_ESP()
    End Sub

    Public Sub CleanControlTxt(ByVal controles As ControlCollection)
        For Each control As Control In controles
            If TypeOf control Is TextBox Then
                DirectCast(control, TextBox).Enabled = False
            ElseIf TypeOf control Is RadioButtonList Then
                DirectCast(control, RadioButtonList).ClearSelection()
            ElseIf TypeOf control Is CheckBoxList Then
                DirectCast(control, CheckBoxList).ClearSelection()
            ElseIf TypeOf control Is RadioButton Then
                DirectCast(control, RadioButton).Checked = False
            ElseIf TypeOf control Is CheckBox Then
                DirectCast(control, CheckBox).Checked = False
            ElseIf control.HasControls() Then
                CleanControlTxt(control.Controls)
            End If
        Next
    End Sub


    Protected Sub btnCargarProfesional_MH_Click(sender As Object, e As EventArgs) Handles btnCargarProfesional_MH.Click
        Try


            Dim dsListarPer As New DataSet
            objentidad.Rut = ddlAsignarProfesional_MH.SelectedValue
            dsListarPer = objnegocio.CARGAR_HORARIOA_MODIFICAR(objentidad)

            For Each myRow In dsListarPer.Tables(0).Rows
                Select Case myRow("DIA").ToString
                    Case 1
                        txtLunesHoraInicio1_MH.Text = myRow("HORA_INICIO_1").ToString()
                        txtLunesMinutoInicio1_MH.Text = myRow("MINUTO_INICIO_1").ToString()
                        txtLunesHoraTermino2_MH.Text = myRow("HORA_TERMINO_2").ToString()
                        txtLunesMinutoTermino2_MH.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtLunesHoraInicio3_MH.Text = myRow("HORA_INICIO_3").ToString()
                        txtLunesMinutoInicio3_MH.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtLunesHoraTermino4_MH.Text = myRow("HORA_TERMINO_4").ToString()
                        txtLunesMinutoTermino4_MH.Text = myRow("MINUTO_TERMINO_4").ToString()
                    Case 2
                        txtMartesHoraInicio1_MH.Text = myRow("HORA_INICIO_1").ToString()
                        txtMartesMinutoInicio1_MH.Text = myRow("MINUTO_INICIO_1").ToString()
                        xtMartesHoraTermino2_MH.Text = myRow("HORA_TERMINO_2").ToString()
                        txtMartesMinutoTermino2_MH.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtMartesHoraInicio3_MH.Text = myRow("HORA_INICIO_3").ToString()
                        txtMartesMinutoInicio3_MH.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtMartesHoraTermino4_MH.Text = myRow("HORA_TERMINO_4").ToString()
                        txtMartesMinutoTermino4_MH.Text = myRow("MINUTO_TERMINO_4").ToString()
                    Case 3
                        txtMiercolesHoraInicio1_MH.Text = myRow("HORA_INICIO_1").ToString()
                        txtMiercolesMinutoInicio1_MH.Text = myRow("MINUTO_INICIO_1").ToString()
                        xtMiercolesHoraTermino2_MH.Text = myRow("HORA_TERMINO_2").ToString()
                        txtMiercolesMinutoTermino2_MH.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtMiercolesHoraInicio3_MH.Text = myRow("HORA_INICIO_3").ToString()
                        txtMiercolesMinutoInicio3_MH.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtMiercolesHoraTermino4_MH.Text = myRow("HORA_TERMINO_4").ToString()
                        txtMiercolesMinutoTermino4_MH.Text = myRow("MINUTO_TERMINO_4").ToString()
                    Case 4
                        txtJuevesHoraInicio1_MH.Text = myRow("HORA_INICIO_1").ToString()
                        txtJuevesMinutoInicio1_MH.Text = myRow("MINUTO_INICIO_1").ToString()
                        xtJuevessHoraTermino2_MH.Text = myRow("HORA_TERMINO_2").ToString()
                        txtJuevesMinutoTermino2_MH.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtJuevessHoraInicio3_MH.Text = myRow("HORA_INICIO_3").ToString()
                        txtJuevesMinutoInicio3_MH.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtJuevesHoraTermino4_MH.Text = myRow("HORA_TERMINO_4").ToString()
                        txtJuevesMinutoTermino4_MH.Text = myRow("MINUTO_TERMINO_4").ToString()
                    Case 5
                        txtViernesHoraInicio1_MH.Text = myRow("HORA_INICIO_1").ToString()
                        txtViernesMinutoInicio1_MH.Text = myRow("MINUTO_INICIO_1").ToString()
                        xtViernesHoraTermino2_MH.Text = myRow("HORA_TERMINO_2").ToString()
                        txtViernesMinutoTermino2_MH.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtViernesHoraInicio3_MH.Text = myRow("HORA_INICIO_3").ToString()
                        txtViernesMinutoInicio3_MH.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtViernesHoraTermino4_MH.Text = myRow("HORA_TERMINO_4").ToString()
                        txtViernesMinutoTermino4_MH.Text = myRow("MINUTO_TERMINO_4").ToString()

                    Case 6
                        txtSabadoHoraInicio1_MH.Text = myRow("HORA_INICIO_1").ToString()
                        txtSabadoMinutoInicio1_MH.Text = myRow("MINUTO_INICIO_1").ToString()
                        xtSabadoHoraTermino2_MH.Text = myRow("HORA_TERMINO_2").ToString()
                        txtSabadoMinutoTermino2_MH.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtSabadoHoraInicio3_MH.Text = myRow("HORA_INICIO_3").ToString()
                        txtSabadoMinutoInicio3_MH.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtSabadoHoraTermino4_MH.Text = myRow("HORA_TERMINO_4").ToString()
                        txtSabadoMinutoTermino4_MH.Text = myRow("MINUTO_TERMINO_4").ToString()
                    Case Else
                        MsgBox("Este usuario no tiene horarios asignados")
                End Select

            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarNuevaCuentaMOD.Click, btnCancelarNuevaCuenta.Click,
        btnLunesAH.Click, btnMartesAH.Click, btnMiercolesAH.Click, btnJuevesAH.Click, btnJuevesAH.Click, btnViernesAH.Click, btnSabadoAH.Click,
        btnModificarLUNESMH.Click, btnModificarMARTESMH.Click, btnModificarMIERCOLESMH.Click, btnModificarJUEVESMH.Click,
        btnModificarVIERNESMH.Click, btnModificarSABADOSMH.Click

        Select Case DirectCast(sender, Button).CommandName
            Case "Cancelar MOD"
                MW_CuentasUsuarios.ActiveViewIndex = 1
                CleanControls(Me.Controls)

            Case "Cancelar"
                MW_CuentasUsuarios.ActiveViewIndex = 0
                CleanControls(Me.Controls)
            Case "GuardarLUNES"
                Try

                    If txtLunesHoraTermino2.Text = "" And txtLunesMinutoTermino2.Text = "" And txtLunesHoraInicio3.Text = "" And txtLunesMinutoInicio3.Text = "" Then
                        objentidad.HORA_INICIO_1 = txtLunesHoraInicio1.Text
                        objentidad.MINUTO_INICIO_1 = txtLunesMinutoInicio1.Text
                        objentidad.HORA_TERMINO_2 = 0
                        objentidad.MINUTO_TERMINO_2 = 0
                        objentidad.HORA_INICIO_3 = 0
                        objentidad.MINUTO_INICIO_3 = 0
                        objentidad.HORA_TERMINO_4 = txtLunesHoraTermino4.Text
                        objentidad.MINUTO_TERMINO_4 = txtLunesMinutoTermino4.Text
                        objentidad.DIA = 1
                        objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue.ToString
                        objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                        imgbtnLunes.Visible = True
                        txtLunesHoraInicio1.Enabled = False
                        txtLunesMinutoInicio1.Enabled = False
                        txtLunesHoraTermino2.Enabled = False
                        txtLunesMinutoTermino2.Enabled = False
                        txtLunesHoraInicio3.Enabled = False
                        txtLunesMinutoInicio3.Enabled = False
                        txtLunesHoraTermino4.Enabled = False
                        txtLunesMinutoTermino4.Enabled = False
                        btnLunesAH.Enabled = False
                    Else
                        objentidad.HORA_INICIO_1 = txtLunesHoraInicio1.Text
                        objentidad.MINUTO_INICIO_1 = txtLunesMinutoInicio1.Text
                        objentidad.HORA_TERMINO_2 = txtLunesHoraTermino2.Text
                        objentidad.MINUTO_TERMINO_2 = txtLunesMinutoTermino2.Text
                        objentidad.HORA_INICIO_3 = txtLunesHoraInicio3.Text
                        objentidad.MINUTO_INICIO_3 = txtLunesMinutoInicio3.Text
                        objentidad.HORA_TERMINO_4 = txtLunesHoraTermino4.Text
                        objentidad.MINUTO_TERMINO_4 = txtLunesMinutoTermino4.Text
                        objentidad.DIA = 1
                        objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue.ToString
                        objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                        imgbtnLunes.Visible = True
                        txtLunesHoraInicio1.Enabled = False
                        txtLunesMinutoInicio1.Enabled = False
                        txtLunesHoraTermino2.Enabled = False
                        txtLunesMinutoTermino2.Enabled = False
                        txtLunesHoraInicio3.Enabled = False
                        txtLunesMinutoInicio3.Enabled = False
                        txtLunesHoraTermino4.Enabled = False
                        txtLunesMinutoTermino4.Enabled = False
                        btnLunesAH.Enabled = False
                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case "GuardarMARTES"
                If txtMartesHoraTermino2.Text = "" And txtMartesMinutoTermino2.Text = "" And txtMartesHoraInicio3.Text = "" And txtMartesMinutoInicio3.Text = "" Then
                    objentidad.HORA_INICIO_1 = txtMartesHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtMartesMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = 0
                    objentidad.MINUTO_TERMINO_2 = 0
                    objentidad.HORA_INICIO_3 = 0
                    objentidad.MINUTO_INICIO_3 = 0
                    objentidad.HORA_TERMINO_4 = txtMartesHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtMartesMinutoTermin4.Text
                    objentidad.DIA = 2
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnMartes.Visible = True
                    btnMartesAH.Enabled = False
                    txtMartesHoraInicio1.Enabled = False
                    txtMartesMinutoInicio1.Enabled = False
                    txtMartesHoraTermino2.Enabled = False
                    txtMartesMinutoTermino2.Enabled = False
                    txtMartesHoraInicio3.Enabled = False
                    txtMartesMinutoInicio3.Enabled = False
                    txtMartesHoraTermino4.Enabled = False
                    txtMartesMinutoTermin4.Enabled = False


                Else
                    objentidad.HORA_INICIO_1 = txtMartesHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtMartesMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = txtMartesHoraTermino2.Text
                    objentidad.MINUTO_TERMINO_2 = txtMartesMinutoTermino2.Text
                    objentidad.HORA_INICIO_3 = txtMartesHoraInicio3.Text
                    objentidad.MINUTO_INICIO_3 = txtMartesMinutoInicio3.Text
                    objentidad.HORA_TERMINO_4 = txtMartesHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtMartesMinutoTermin4.Text
                    objentidad.DIA = 2
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnMartes.Visible = True
                    btnMartesAH.Enabled = False
                    txtMartesHoraInicio1.Enabled = False
                    txtMartesMinutoInicio1.Enabled = False
                    txtMartesHoraTermino2.Enabled = False
                    txtMartesMinutoTermino2.Enabled = False
                    txtMartesHoraInicio3.Enabled = False
                    txtMartesMinutoInicio3.Enabled = False
                    txtMartesHoraTermino4.Enabled = False
                    txtMartesMinutoTermin4.Enabled = False

                End If
            Case "GuardarMIERCOLES"
                If txtMiercolesHoraTermino2.Text = "" And txtMiercolesMinutoTermino2.Text = "" And txtMiercolesHoraTermino3.Text = "" And txtMiercolesMinutoTermino3.Text = "" Then
                    objentidad.HORA_INICIO_1 = txtMiercolesHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtMiercolesMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = 0
                    objentidad.MINUTO_TERMINO_2 = 0
                    objentidad.HORA_INICIO_3 = 0
                    objentidad.MINUTO_INICIO_3 = 0
                    objentidad.HORA_TERMINO_4 = txtMiercolesHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtMiercolesMinutoTermino4.Text
                    objentidad.DIA = 3
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnMiercoles.Visible = True
                    txtMiercolesHoraInicio1.Enabled = False
                    txtMiercolesMinutoInicio1.Enabled = False
                    txtMiercolesHoraTermino2.Enabled = False
                    txtMiercolesMinutoTermino2.Enabled = False
                    txtMiercolesHoraTermino3.Enabled = False
                    txtMiercolesMinutoTermino3.Enabled = False
                    txtMiercolesHoraTermino4.Enabled = False
                    txtMiercolesMinutoTermino4.Enabled = False
                    btnMartesAH.Enabled = False
                Else
                    objentidad.HORA_INICIO_1 = txtMiercolesHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtMiercolesMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = txtMiercolesHoraTermino2.Text
                    objentidad.MINUTO_TERMINO_2 = txtMiercolesMinutoTermino2.Text
                    objentidad.HORA_INICIO_3 = txtMiercolesHoraTermino3.Text
                    objentidad.MINUTO_INICIO_3 = txtMiercolesMinutoTermino3.Text
                    objentidad.HORA_TERMINO_4 = txtMiercolesHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtMiercolesMinutoTermino4.Text
                    objentidad.DIA = 3
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnMiercoles.Visible = True
                    txtMiercolesHoraInicio1.Enabled = False
                    txtMiercolesMinutoInicio1.Enabled = False
                    txtMiercolesHoraTermino2.Enabled = False
                    txtMiercolesMinutoTermino2.Enabled = False
                    txtMiercolesHoraTermino3.Enabled = False
                    txtMiercolesMinutoTermino3.Enabled = False
                    txtMiercolesHoraTermino4.Enabled = False
                    txtMiercolesMinutoTermino4.Enabled = False
                    btnMartesAH.Enabled = False
                End If

            Case "GuardarJUEVES"
                If txtJuevesHoraTermino2.Text = "" And txtJuevesMinutoTermino2.Text = "" And txtJuevesHoraInicio3.Text = "" And txtJuevesMinutoInicio3.Text = "" Then

                    objentidad.HORA_INICIO_1 = txtJuevesHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtJuevesMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = 0
                    objentidad.MINUTO_TERMINO_2 = 0
                    objentidad.HORA_INICIO_3 = 0
                    objentidad.MINUTO_INICIO_3 = 0
                    objentidad.HORA_TERMINO_4 = txtJuevesHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtJuevesMinutoTermino4.Text
                    objentidad.DIA = 4
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnJueves.Visible = True


                    txtJuevesHoraInicio1.Enabled = False
                    txtJuevesMinutoInicio1.Enabled = False
                    txtJuevesHoraTermino2.Enabled = False
                    txtJuevesMinutoTermino2.Enabled = False
                    txtJuevesHoraInicio3.Enabled = False
                    txtJuevesMinutoInicio3.Enabled = False
                    txtJuevesHoraTermino4.Enabled = False
                    txtJuevesMinutoTermino4.Enabled = False
                    btnJuevesAH.Enabled = False
                Else

                    objentidad.HORA_INICIO_1 = txtJuevesHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtJuevesMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = txtJuevesHoraTermino2.Text
                    objentidad.MINUTO_TERMINO_2 = txtJuevesMinutoTermino2.Text
                    objentidad.HORA_INICIO_3 = txtJuevesHoraInicio3.Text
                    objentidad.MINUTO_INICIO_3 = txtJuevesMinutoInicio3.Text
                    objentidad.HORA_TERMINO_4 = txtJuevesHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtJuevesMinutoTermino4.Text
                    objentidad.DIA = 4
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnJueves.Visible = True


                    txtJuevesHoraInicio1.Enabled = False
                    txtJuevesMinutoInicio1.Enabled = False
                    txtJuevesHoraTermino2.Enabled = False
                    txtJuevesMinutoTermino2.Enabled = False
                    txtJuevesHoraInicio3.Enabled = False
                    txtJuevesMinutoInicio3.Enabled = False
                    txtJuevesHoraTermino4.Enabled = False
                    txtJuevesMinutoTermino4.Enabled = False
                    btnJuevesAH.Enabled = False

                End If

            Case "GuardarVIERNES"

                If txtViernesHoraTermino2.Text = "" And txtViernesMinutoTermino2.Text = "" And txtViernesHoraTermino3.Text = "" And txtViernesMinutoTermino3.Text = "" Then

                    objentidad.HORA_INICIO_1 = txtViernesHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtViernesMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = 0
                    objentidad.MINUTO_TERMINO_2 = 0
                    objentidad.HORA_INICIO_3 = 0
                    objentidad.MINUTO_INICIO_3 = 0
                    objentidad.HORA_TERMINO_4 = txtViernesHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtViernesMinutoTermino4.Text
                    objentidad.DIA = 5
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnViernes.Visible = True

                    txtViernesHoraInicio1.Enabled = False
                    txtViernesMinutoInicio1.Enabled = False
                    txtViernesHoraTermino2.Enabled = False
                    txtViernesMinutoTermino2.Enabled = False
                    txtViernesHoraTermino3.Enabled = False
                    txtViernesMinutoTermino3.Enabled = False
                    txtViernesHoraTermino4.Enabled = False
                    txtViernesMinutoTermino4.Enabled = False
                    btnViernesAH.Enabled = False

                Else
                    objentidad.HORA_INICIO_1 = txtViernesHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtViernesMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = txtViernesHoraTermino2.Text
                    objentidad.MINUTO_TERMINO_2 = txtViernesMinutoTermino2.Text
                    objentidad.HORA_INICIO_3 = txtViernesHoraTermino3.Text
                    objentidad.MINUTO_INICIO_3 = txtViernesMinutoTermino3.Text
                    objentidad.HORA_TERMINO_4 = txtViernesHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtViernesMinutoTermino4.Text
                    objentidad.DIA = 5
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnViernes.Visible = True

                    txtViernesHoraInicio1.Enabled = False
                    txtViernesMinutoInicio1.Enabled = False
                    txtViernesHoraTermino2.Enabled = False
                    txtViernesMinutoTermino2.Enabled = False
                    txtViernesHoraTermino3.Enabled = False
                    txtViernesMinutoTermino3.Enabled = False
                    txtViernesHoraTermino4.Enabled = False
                    txtViernesMinutoTermino4.Enabled = False
                    btnViernesAH.Enabled = False

                End If



            Case "GuardarSABADO"

                If txtSabadoHoraTermino2.Text = "" And txtSabadoMinutoTermino2.Text = "" And txtLSabadoHoraInicio3.Text = "" And txtSabadoMinuTermino3.Text = "" Then



                    objentidad.HORA_INICIO_1 = txtLSabadoHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtSabadoMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = txtSabadoHoraTermino2.Text
                    objentidad.MINUTO_TERMINO_2 = txtSabadoMinutoTermino2.Text
                    objentidad.HORA_INICIO_3 = txtLSabadoHoraInicio3.Text
                    objentidad.MINUTO_INICIO_3 = txtSabadoMinuTermino3.Text
                    objentidad.HORA_TERMINO_4 = txtSabadoHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtSabadoMinutoTermino4.Text
                    objentidad.DIA = 6
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnSabado.Visible = True

                    txtLSabadoHoraInicio1.Enabled = False
                    txtSabadoMinutoInicio1.Enabled = False
                    txtSabadoHoraTermino2.Enabled = False
                    txtSabadoMinutoTermino2.Enabled = False
                    txtLSabadoHoraInicio3.Enabled = False
                    txtSabadoMinuTermino3.Enabled = False
                    txtSabadoHoraTermino4.Enabled = False
                    txtSabadoMinutoTermino4.Enabled = False
                    btnSabadoAH.Enabled = False
                Else
                    objentidad.HORA_INICIO_1 = txtLSabadoHoraInicio1.Text
                    objentidad.MINUTO_INICIO_1 = txtSabadoMinutoInicio1.Text
                    objentidad.HORA_TERMINO_2 = txtSabadoHoraTermino2.Text
                    objentidad.MINUTO_TERMINO_2 = txtSabadoMinutoTermino2.Text
                    objentidad.HORA_INICIO_3 = txtLSabadoHoraInicio3.Text
                    objentidad.MINUTO_INICIO_3 = txtSabadoMinuTermino3.Text
                    objentidad.HORA_TERMINO_4 = txtSabadoHoraTermino4.Text
                    objentidad.MINUTO_TERMINO_4 = txtSabadoMinutoTermino4.Text
                    objentidad.DIA = 6
                    objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
                    objnegocio.INSERTAR_ASIGNACION_DEHORARIO(objentidad)
                    imgbtnSabado.Visible = True

                    txtLSabadoHoraInicio1.Enabled = False
                    txtSabadoMinutoInicio1.Enabled = False
                    txtSabadoHoraTermino2.Enabled = False
                    txtSabadoMinutoTermino2.Enabled = False
                    txtLSabadoHoraInicio3.Enabled = False
                    txtSabadoMinuTermino3.Enabled = False
                    txtSabadoHoraTermino4.Enabled = False
                    txtSabadoMinutoTermino4.Enabled = False
                    btnSabadoAH.Enabled = False

                End If


            Case "ModificarLUNES"

                objentidad.Rut = ddlAsignarProfesional_MH.SelectedValue
                objentidad.HORA_INICIO_1 = txtLunesHoraInicio1_MH.Text
                objentidad.MINUTO_INICIO_1 = txtLunesMinutoInicio1_MH.Text
                objentidad.HORA_TERMINO_2 = txtLunesHoraTermino2_MH.Text
                objentidad.MINUTO_TERMINO_2 = txtLunesMinutoTermino2_MH.Text
                objentidad.HORA_INICIO_3 = txtLunesHoraInicio3_MH.Text
                objentidad.MINUTO_INICIO_3 = txtLunesMinutoInicio3_MH.Text
                objentidad.HORA_TERMINO_4 = txtLunesHoraTermino4_MH.Text
                objentidad.MINUTO_TERMINO_4 = txtLunesMinutoTermino4_MH.Text
                objentidad.DIA = 1
                objnegocio.MODIFICAR_HORARIO(objentidad)
                imgbtnLunes0.Visible = True

            Case "ModificarMARTES"
                objentidad.Rut = ddlAsignarProfesional_MH.SelectedValue
                objentidad.HORA_INICIO_1 = txtMartesHoraInicio1_MH.Text
                objentidad.HORA_INICIO_1 = txtMartesMinutoInicio1_MH.Text
                objentidad.HORA_TERMINO_2 = xtMartesHoraTermino2_MH.Text
                objentidad.MINUTO_TERMINO_2 = txtMartesMinutoTermino2_MH.Text
                objentidad.HORA_INICIO_3 = txtMartesHoraInicio3_MH.Text
                objentidad.MINUTO_INICIO_3 = txtMartesMinutoInicio3_MH.Text
                objentidad.HORA_TERMINO_4 = txtMartesHoraTermino4_MH.Text
                objentidad.MINUTO_TERMINO_4 = txtMartesMinutoTermino4_MH.Text
                objentidad.DIA = 2
                objnegocio.MODIFICAR_HORARIO(objentidad)
                imgbtnMartes0.Visible = True

            Case "ModificarMIERCOLES"

                objentidad.Rut = ddlAsignarProfesional_MH.SelectedValue
                objentidad.HORA_INICIO_1 = txtMiercolesHoraInicio1_MH.Text
                objentidad.HORA_INICIO_1 = txtMiercolesMinutoInicio1_MH.Text
                objentidad.HORA_TERMINO_2 = xtMiercolesHoraTermino2_MH.Text
                objentidad.MINUTO_TERMINO_2 = txtMiercolesMinutoTermino2_MH.Text
                objentidad.HORA_INICIO_3 = txtMiercolesHoraInicio3_MH.Text
                objentidad.MINUTO_INICIO_3 = txtMiercolesMinutoInicio3_MH.Text
                objentidad.HORA_TERMINO_4 = txtMiercolesHoraTermino4_MH.Text
                objentidad.MINUTO_TERMINO_4 = txtMiercolesMinutoTermino4_MH.Text
                objentidad.DIA = 3
                objnegocio.MODIFICAR_HORARIO(objentidad)
                imgbtnMiercoles0.Visible = True

            Case "ModificarJUEVES"

                objentidad.Rut = ddlAsignarProfesional_MH.SelectedValue
                objentidad.HORA_INICIO_1 = txtJuevesHoraInicio1_MH.Text
                objentidad.HORA_INICIO_1 = txtJuevesMinutoInicio1_MH.Text
                objentidad.HORA_TERMINO_2 = xtJuevessHoraTermino2_MH.Text
                objentidad.MINUTO_TERMINO_2 = txtJuevesMinutoTermino2_MH.Text
                objentidad.HORA_INICIO_3 = txtJuevessHoraInicio3_MH.Text
                objentidad.MINUTO_INICIO_3 = txtJuevesMinutoInicio3_MH.Text
                objentidad.HORA_TERMINO_4 = txtJuevesHoraTermino4_MH.Text
                objentidad.MINUTO_TERMINO_4 = txtJuevesMinutoTermino4_MH.Text
                objentidad.DIA = 4
                objnegocio.MODIFICAR_HORARIO(objentidad)
                imgbtnJueves0.Visible = True

            Case "ModificarVIERNES"

                objentidad.Rut = ddlAsignarProfesional_MH.SelectedValue
                objentidad.HORA_INICIO_1 = txtViernesHoraInicio1_MH.Text
                objentidad.HORA_INICIO_1 = txtViernesMinutoInicio1_MH.Text
                objentidad.HORA_TERMINO_2 = xtViernesHoraTermino2_MH.Text
                objentidad.MINUTO_TERMINO_2 = txtViernesMinutoTermino2_MH.Text
                objentidad.HORA_INICIO_3 = txtViernesHoraInicio3_MH.Text
                objentidad.MINUTO_INICIO_3 = txtViernesMinutoInicio3_MH.Text
                objentidad.HORA_TERMINO_4 = txtViernesHoraTermino4_MH.Text
                objentidad.MINUTO_TERMINO_4 = txtViernesMinutoTermino4_MH.Text
                objentidad.DIA = 5
                objnegocio.MODIFICAR_HORARIO(objentidad)
                imgbtnViernes0.Visible = True

            Case "ModificarSABADO"

                objentidad.Rut = ddlAsignarProfesional_MH.SelectedValue
                objentidad.HORA_INICIO_1 = txtSabadoHoraInicio1_MH.Text
                objentidad.HORA_INICIO_1 = txtSabadoMinutoInicio1_MH.Text
                objentidad.HORA_TERMINO_2 = xtSabadoHoraTermino2_MH.Text
                objentidad.MINUTO_TERMINO_2 = txtSabadoMinutoTermino2_MH.Text
                objentidad.HORA_INICIO_3 = txtSabadoHoraInicio3_MH.Text
                objentidad.MINUTO_INICIO_3 = txtSabadoMinutoInicio3_MH.Text
                objentidad.HORA_TERMINO_4 = txtSabadoHoraTermino4_MH.Text
                objentidad.MINUTO_TERMINO_4 = txtSabadoMinutoTermino4_MH.Text
                objentidad.DIA = 6
                objnegocio.MODIFICAR_HORARIO(objentidad)
                imgbtnSabado0.Visible = True

        End Select
    End Sub



    Protected Sub btnVerDisponibilidadAH_Click(sender As Object, e As EventArgs) Handles btnVerDisponibilidadAH.Click
        Try
            Dim dsListarDis As New DataSet

            objentidad.Rut = ddlAsignarProfesionalAH.SelectedValue
            dsListarDis = objnegocio.CARGAR_HORARIOA_MODIFICAR(objentidad)

            For Each myRow In dsListarDis.Tables(0).Rows
                Select Case myRow("DIA").ToString
                    Case 1
                        txtLunesHoraInicio1.Text = myRow("HORA_INICIO_1").ToString()
                        txtLunesMinutoInicio1.Text = myRow("MINUTO_INICIO_1").ToString()
                        txtLunesHoraTermino2.Text = myRow("HORA_TERMINO_2").ToString()
                        txtLunesMinutoTermino2.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtLunesHoraInicio3.Text = myRow("HORA_INICIO_3").ToString()
                        txtLunesMinutoInicio3.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtLunesHoraTermino4.Text = myRow("HORA_TERMINO_4").ToString()
                        txtLunesMinutoTermino4.Text = myRow("MINUTO_TERMINO_4").ToString()
                        If txtLunesHoraInicio1.Text > 1 And txtLunesHoraTermino4.Text > 1 Then

                            txtLunesHoraInicio1.Enabled = False
                            txtLunesMinutoInicio1.Enabled = False
                            txtLunesHoraTermino2.Enabled = False
                            txtLunesMinutoTermino2.Enabled = False
                            txtLunesHoraInicio3.Enabled = False
                            txtLunesMinutoInicio3.Enabled = False
                            txtLunesHoraTermino4.Enabled = False
                            txtLunesMinutoTermino4.Enabled = False
                            btnLunesAH.Enabled = False


                        End If

                    Case 2
                        txtMartesHoraInicio1.Text = myRow("HORA_INICIO_1").ToString()
                        txtMartesMinutoInicio1.Text = myRow("MINUTO_INICIO_1").ToString()
                        txtMartesHoraTermino2.Text = myRow("HORA_TERMINO_2").ToString()
                        txtMartesMinutoTermino2.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtMartesHoraInicio3.Text = myRow("HORA_INICIO_3").ToString()
                        txtMartesMinutoInicio3.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtMartesHoraTermino4.Text = myRow("HORA_TERMINO_4").ToString()
                        txtMartesMinutoTermin4.Text = myRow("MINUTO_TERMINO_4").ToString()

                        If txtMartesHoraInicio1.Text > 1 And txtMartesHoraTermino4.Text > 1 Then

                            txtMartesHoraInicio1.Enabled = False
                            txtMartesMinutoInicio1.Enabled = False
                            txtMartesHoraTermino2.Enabled = False
                            txtMartesMinutoTermino2.Enabled = False
                            txtMartesHoraInicio3.Enabled = False
                            txtMartesMinutoInicio3.Enabled = False
                            txtMartesHoraTermino4.Enabled = False
                            txtMartesMinutoTermin4.Enabled = False
                            btnMartesAH.Enabled = False
                        End If
                    Case 3


                        txtMiercolesHoraInicio1.Text = myRow("HORA_INICIO_1").ToString()
                        txtMiercolesMinutoInicio1.Text = myRow("MINUTO_INICIO_1").ToString()
                        txtMiercolesHoraTermino2.Text = myRow("HORA_TERMINO_2").ToString()
                        txtMiercolesMinutoTermino2.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtMiercolesHoraTermino3.Text = myRow("HORA_INICIO_3").ToString()
                        txtMiercolesMinutoTermino3.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtMiercolesHoraTermino4.Text = myRow("HORA_TERMINO_4").ToString()
                        txtMiercolesMinutoTermino4.Text = myRow("MINUTO_TERMINO_4").ToString()

                        If txtMiercolesHoraInicio1.Text > 1 And txtMiercolesHoraTermino4.Text > 1 Then

                            txtMiercolesHoraInicio1.Enabled = False
                            txtMiercolesMinutoInicio1.Enabled = False
                            txtMiercolesHoraTermino2.Enabled = False
                            txtMiercolesMinutoTermino2.Enabled = False
                            txtMiercolesHoraTermino3.Enabled = False
                            txtMiercolesMinutoTermino3.Enabled = False
                            txtMiercolesHoraTermino4.Enabled = False
                            txtMiercolesMinutoTermino4.Enabled = False
                            btnMiercolesAH.Enabled = False
                        End If

                    Case 4
                        txtJuevesHoraInicio1.Text = myRow("HORA_INICIO_1").ToString()
                        txtJuevesMinutoInicio1.Text = myRow("MINUTO_INICIO_1").ToString()
                        txtJuevesHoraTermino2.Text = myRow("HORA_TERMINO_2").ToString()
                        txtJuevesMinutoTermino2.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtJuevesHoraInicio3.Text = myRow("HORA_INICIO_3").ToString()
                        txtJuevesMinutoInicio3.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtJuevesHoraTermino4.Text = myRow("HORA_TERMINO_4").ToString()
                        txtJuevesMinutoTermino4.Text = myRow("MINUTO_TERMINO_4").ToString()

                        If txtJuevesHoraInicio1.Text > 1 And txtJuevesHoraTermino4.Text > 1 Then

                            txtJuevesHoraInicio1.Enabled = False
                            txtJuevesMinutoInicio1.Enabled = False
                            txtJuevesHoraTermino2.Enabled = False
                            txtJuevesMinutoTermino2.Enabled = False
                            txtJuevesHoraInicio3.Enabled = False
                            txtJuevesMinutoInicio3.Enabled = False
                            txtJuevesHoraTermino4.Enabled = False
                            txtJuevesMinutoTermino4.Enabled = False
                            btnJuevesAH.Enabled = False
                        End If

                    Case 5
                        txtViernesHoraInicio1.Text = myRow("HORA_INICIO_1").ToString()
                        txtViernesMinutoInicio1.Text = myRow("MINUTO_INICIO_1").ToString()
                        txtViernesHoraTermino2.Text = myRow("HORA_TERMINO_2").ToString()
                        txtViernesMinutoTermino2.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtViernesHoraTermino3.Text = myRow("HORA_INICIO_3").ToString()
                        txtViernesMinutoTermino3.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtViernesHoraTermino4.Text = myRow("HORA_TERMINO_4").ToString()
                        txtViernesMinutoTermino4.Text = myRow("MINUTO_TERMINO_4").ToString()

                        If txtViernesHoraInicio1.Text > 1 And txtViernesHoraTermino4.Text > 1 Then

                            txtViernesHoraInicio1.Enabled = False
                            txtViernesMinutoInicio1.Enabled = False
                            txtViernesHoraTermino2.Enabled = False
                            txtViernesMinutoTermino2.Enabled = False
                            txtViernesHoraTermino3.Enabled = False
                            txtViernesMinutoTermino3.Enabled = False
                            txtViernesHoraTermino4.Enabled = False
                            txtViernesMinutoTermino4.Enabled = False
                            btnViernesAH.Enabled = False
                        End If

                    Case 6
                        txtLSabadoHoraInicio1.Text = myRow("HORA_INICIO_1").ToString()
                        txtSabadoMinutoInicio1.Text = myRow("MINUTO_INICIO_1").ToString()
                        txtSabadoHoraTermino2.Text = myRow("HORA_TERMINO_2").ToString()
                        txtSabadoMinutoTermino2.Text = myRow("MINUTO_TERMINO_2").ToString()
                        txtLSabadoHoraInicio3.Text = myRow("HORA_INICIO_3").ToString()
                        txtSabadoMinuTermino3.Text = myRow("MINUTO_INICIO_3").ToString()
                        txtSabadoHoraTermino4.Text = myRow("HORA_TERMINO_4").ToString()
                        txtSabadoMinutoTermino4.Text = myRow("MINUTO_TERMINO_4").ToString()

                        If txtLSabadoHoraInicio1.Text > 1 And txtSabadoHoraTermino4.Text > 1 Then

                            txtLSabadoHoraInicio1.Enabled = False
                            txtSabadoMinutoInicio1.Enabled = False
                            txtSabadoHoraTermino2.Enabled = False
                            txtSabadoMinutoTermino2.Enabled = False
                            txtLSabadoHoraInicio3.Enabled = False
                            txtSabadoMinuTermino3.Enabled = False
                            txtSabadoHoraTermino4.Enabled = False
                            txtSabadoMinutoTermino4.Enabled = False
                            btnSabadoAH.Enabled = False
                        End If
                    Case Else

                        MsgBox("Este usuario no tiene horarios asignados")



                End Select

            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub ddlAsignarEspecialidadAH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAsignarEspecialidadAH.SelectedIndexChanged
        Dim dsListarPro As New DataSet
        objentidad.Especialidad = ddlAsignarEspecialidadAH.SelectedValue
        dsListarPro = objnegocio.CARGAR_DDL_PROFESIONALES(objentidad)
        Try
            Me.ddlAsignarProfesionalAH.DataSource = dsListarPro
            Me.ddlAsignarProfesionalAH.DataValueField = "RUT"
            Me.ddlAsignarProfesionalAH.DataTextField = "RUT"
            Me.ddlAsignarProfesionalAH.DataBind()
            If ddlAsignarProfesionalAH.Items.Count >= 1 Then

                ddlAsignarProfesionalAH.Enabled = True
            Else
                'Dejar todos los txt enable
                txtLunesHoraInicio1.Enabled = True
                txtLunesMinutoInicio1.Enabled = True
                txtLunesHoraTermino2.Enabled = True
                txtLunesMinutoTermino2.Enabled = True
                txtLunesHoraInicio3.Enabled = True
                txtLunesMinutoInicio3.Enabled = True
                txtLunesHoraTermino4.Enabled = True
                txtLunesMinutoTermino4.Enabled = True
                btnLunesAH.Enabled = True
                imgbtnLunes.Visible = False

                txtMartesHoraInicio1.Enabled = True
                txtMartesMinutoInicio1.Enabled = True
                txtMartesHoraTermino2.Enabled = True
                txtMartesMinutoTermino2.Enabled = True
                txtMartesHoraInicio3.Enabled = True
                txtMartesMinutoInicio3.Enabled = True
                txtMartesHoraTermino4.Enabled = True
                txtMartesMinutoTermin4.Enabled = True
                btnMartesAH.Enabled = True
                imgbtnMartes.Visible = False

                txtMiercolesHoraInicio1.Enabled = True
                txtMiercolesMinutoInicio1.Enabled = True
                txtMiercolesHoraTermino2.Enabled = True
                txtMiercolesMinutoTermino2.Enabled = True
                txtMiercolesHoraTermino3.Enabled = True
                txtMiercolesMinutoTermino3.Enabled = True
                txtMiercolesHoraTermino4.Enabled = True
                txtMiercolesMinutoTermino4.Enabled = True
                btnMiercolesAH.Enabled = True
                imgbtnMiercoles.Visible = False

                txtJuevesHoraInicio1.Enabled = True
                txtJuevesMinutoInicio1.Enabled = True
                txtJuevesHoraTermino2.Enabled = True
                txtJuevesMinutoTermino2.Enabled = True
                txtJuevesHoraInicio3.Enabled = True
                txtJuevesMinutoInicio3.Enabled = True
                txtJuevesHoraTermino4.Enabled = True
                txtJuevesMinutoTermino4.Enabled = True
                btnJuevesAH.Enabled = True
                imgbtnJueves.Visible = False

                txtViernesHoraInicio1.Enabled = True
                txtViernesMinutoInicio1.Enabled = True
                txtViernesHoraTermino2.Enabled = True
                txtViernesMinutoTermino2.Enabled = True
                txtViernesHoraTermino3.Enabled = True
                txtViernesMinutoTermino3.Enabled = True
                txtViernesHoraTermino4.Enabled = True
                txtViernesMinutoTermino4.Enabled = True
                btnViernesAH.Enabled = True
                imgbtnViernes.Visible = False

                txtLSabadoHoraInicio1.Enabled = True
                txtSabadoMinutoInicio1.Enabled = True
                txtSabadoHoraTermino2.Enabled = True
                txtSabadoMinutoTermino2.Enabled = True
                txtLSabadoHoraInicio3.Enabled = True
                txtSabadoMinuTermino3.Enabled = True
                txtSabadoHoraTermino4.Enabled = True
                txtSabadoMinutoTermino4.Enabled = True
                btnSabadoAH.Enabled = True
                imgbtnSabado.Visible = False




                ddlAsignarProfesionalAH.Enabled = False
                imgbtnLunes.Visible = False
                imgbtnMartes.Visible = False
                ddlAsignarProfesional_MH.Enabled = False
                CleanControls(Me.Controls)


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub ddlAsignarEspecialidad_MH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAsignarEspecialidad_MH.SelectedIndexChanged
        Dim dsListarPro As New DataSet
        objentidad.Especialidad = ddlAsignarEspecialidad_MH.SelectedValue
        dsListarPro = objnegocio.CARGAR_DDL_PROFESIONALES(objentidad)
        Try
            Me.ddlAsignarProfesional_MH.DataSource = dsListarPro
            Me.ddlAsignarProfesional_MH.DataValueField = "RUT"
            Me.ddlAsignarProfesional_MH.DataTextField = "RUT"
            Me.ddlAsignarProfesional_MH.DataBind()
            If ddlAsignarProfesional_MH.Items.Count >= 1 Then

            Else

                ddlAsignarProfesional_MH.Enabled = False
                imgbtnLunes0.Visible = False
                imgbtnMartes0.Visible = False
                imgbtnMiercoles0.Visible = False
                CleanControls(Me.Controls)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
