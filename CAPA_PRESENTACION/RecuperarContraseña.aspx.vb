Public Class RecuperarContraseña
    Inherits System.Web.UI.Page
    Public objnegocio As New CAPA_NEGOCIO.CpN_Clc_UsuarioPagWEb
    Public objentidad As New CAPA_ENTIDAD.CpE_Clc_UsuarioPagWEb
    Public Sub RECUPERAR()

        objentidad.Rut = TxtRut.Text
        objnegocio.CONSULTAR_EXISTENCIA_USUARIO(objentidad)
        If (TxtRut.Text <> objentidad.Rut1) Then
            LblError.Visible = True
            LblError.Text = "El rut ingresado no se encuentra en nuestro sistema"
        Else
            Dim dsdatos As New DataSet
            Dim destinatario As String
            Dim nombre As String
            Dim apellido As String
            Dim pass As String
            Dim email As String
            dsdatos = objnegocio.LISTAR_DATOS_PASS(objentidad)
            email = dsdatos.Tables(0).Rows(0).Item(0).ToString
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress("healthsystemcompany@gmail.com")
            destinatario = email
            correo.To.Add(email)
            correo.Subject = "Recuperación De Contraseña"
            nombre = dsdatos.Tables(0).Rows(0).Item(1).ToString
            apellido = dsdatos.Tables(0).Rows(0).Item(2).ToString
            pass = dsdatos.Tables(0).Rows(0).Item(3).ToString
            correo.Body = "Hola " + nombre + " " + apellido + " tú actual clave es: " + pass + " recuerda que es importante que la actualizes" & vbCrLf & vbCrLf &
                        "Fecha y hora GMT: " &
                        DateTime.Now.ToLocalTime.ToString("dd/MM/yyyy HH:mm:ss") & vbCrLf & vbCrLf & "HEALTHSYSTEM "

            correo.IsBodyHtml = False
            correo.Priority = System.Net.Mail.MailPriority.Normal

            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = ("smtp.gmail.com")
            smtp.EnableSsl = True
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("healthsystemcompany@gmail.com", "HealthSystem1234")
            Dim destinatario1 As String
            Dim nrocrtrs As Integer
            Dim dif As Integer
            nrocrtrs = Len(destinatario)
            dif = (nrocrtrs - 5)
            destinatario1 = destinatario.Substring(5, dif)

            Try
                smtp.Send(correo)
                MsgBox("Hemos enviado la clave al correo: " + "*****" + destinatario1, MsgBoxStyle.Information, "Envio")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub BtnRecuperar_Click(sender As Object, e As EventArgs) Handles BtnRecuperar.Click
        VALIDARRUT()
    End Sub

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
                LblError.Visible = False
                RECUPERAR()
            Else
                LblError.Visible = True
                LblError.Text = "Rut Invalido"
                Me.TxtRut.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class