Public Class RegistroUsuarioPagWeb
    Inherits System.Web.UI.Page
    Public objnegocio As New CAPA_NEGOCIO.CpN_Clc_UsuarioPagWEb
    Public objentidad As New CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb
    Public Sub VALIDARRUT()
        Try
            Dim rutLimpio As String
            Dim digitoVerificador As String
            Dim suma As Integer
            Dim contador As Integer = 2

            rutLimpio = Me.TxtRut.Text
            rutLimpio = rutLimpio.Replace("-", "")
            rutLimpio = rutLimpio.Replace(" ", "")
            rutLimpio = rutLimpio.Substring(0, rutLimpio.Length - 1)
            digitoVerificador = Me.TxtRut.Text.Substring(TxtRut.Text.Length - 1, 1)


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
                LblValidarRut.Visible = False
                REGISTRARUSUEXT()
            Else
                Me.LblValidarRut.Visible = True
                Me.LblValidarRut.Text = "Rut Invalido"
                Me.TxtRut.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        VALIDARRUT()
    End Sub

    Public Sub REGISTRARUSUEXT()
        Try
            objentidad.Rut = TxtRut.Text
            objnegocio.CONSULTAR_EXISTENCIA_USUARIO(objentidad)

            If (TxtRut.Text = objentidad.Rut1) Then
                LblValidarRut.Visible = True
                LblValidarRut.Text = "El rut ya se encuentra registrado en el sistema"
            ElseIf (TxtContrasena.Text <> TxtRepContrasena.Text)
                LBlErrorPass.Visible = True
                LBlErrorPass.Text = "La contraseña debe coincidir"
                'ElseIf TxtCalendario.Text = ""
                '    LblValidarRut.Visible = True
                '    LblValidarRut.Text = "debe ingresar fecha de nacimiento"
            Else
                LBlErrorPass.Visible = False
                LblValidarRut.Visible = False
                objentidad.Rut = TxtRut.Text
                objentidad.Nombres = TxtNombres.Text
                objentidad.Apellidos = TxtApellidos.Text
                If RadioFemenino.Checked = True Then
                    objentidad.Sexo = RadioFemenino.Text
                ElseIf RadioMasculino.Checked = True
                    objentidad.Sexo = RadioMasculino.Text
                End If
                objentidad.FechaNac = TxtCalendario.Text
                objentidad.Direccion = TxtDireccion.Text
                objentidad.Fono = TxtFono.Text
                objentidad.Email = TxtEmail.Text
                objentidad.Contrasena = TxtContrasena.Text
                objentidad.IdPerfil = 3
                objentidad.Estado = "Habilitado"
                objnegocio.REGISTRAR_USUARIO_EXT(objentidad)
                MsgBox("Registro exitoso!!", MsgBoxStyle.Information, "REGISTRO")
                TxtRut.Text = ""
                TxtNombres.Text = ""
                TxtApellidos.Text = ""
                TxtDireccion.Text = ""
                TxtFono.Text = ""
                TxtEmail.Text = ""
                TxtCalendario.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RegistroUsuarioPagWeb_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("usuario") = "" Then
        Else
            Response.Redirect("/Index.aspx")
        End If
    End Sub
End Class