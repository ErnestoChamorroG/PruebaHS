Public Class InicioDeSesion
    Inherits System.Web.UI.Page
    Public objnegocio As New CAPA_NEGOCIO.CpN_Clc_Login
    Public objentidad As New CAPA_ENTIDAD.CpE_Clc_Login
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") = "" Then
        Else
            Response.Redirect("/Index.aspx")
        End If
    End Sub

    Public Sub INICIARSESION()
        'Try
        Dim dsdatos As New DataSet
        objentidad.Rut = Login1.UserName
        objnegocio.CONSULTAR_EXISTENCIA_USUARIO(objentidad)
        dsdatos = objnegocio.LOGIN(objentidad)
        If (Login1.UserName <> objentidad.Rut1) Then
            LblError.Visible = True
            LblError.Text = "Usuario erroneo"
        ElseIf (Login1.Password <> dsdatos.Tables(0).Rows(0).Item(2).ToString) Then
            LblError.Visible = True
            LblError.Text = "Clave erronea"
        ElseIf (dsdatos.Tables(0).Rows(0).Item(3).ToString = "Inhabilitado") Then
            MsgBox("El rut ingresado se encuentra bloqueado en el sistema", MsgBoxStyle.Exclamation, "INICIO DE SESIÓN")
        Else
            If (Convert.ToInt32(dsdatos.Tables(0).Rows(0).Item(1).ToString) = 0) Then
                LblError.Visible = False
                Session("usuario") = dsdatos.Tables(0).Rows(0).Item(4).ToString
                Session("Perfil") = Convert.ToInt16(dsdatos.Tables(0).Rows(0).Item(1).ToString)
                Session("rut") = dsdatos.Tables(0).Rows(0).Item(0).ToString
                MsgBox("Bienvenido al sistema usuario " & Session("usuario"), MsgBoxStyle.Information, "INICIO DE SESIÓN")
                Response.Redirect("/Admin.aspx")
            ElseIf (Convert.ToInt32(dsdatos.Tables(0).Rows(0).Item(1).ToString) = 1) Then
                LblError.Visible = False
                Session("usuario") = dsdatos.Tables(0).Rows(0).Item(4).ToString
                Session("Perfil") = Convert.ToInt16(dsdatos.Tables(0).Rows(0).Item(1).ToString)
                Session("rut") = dsdatos.Tables(0).Rows(0).Item(0).ToString
                MsgBox("Bienvenido al sistema usuario " & Session("usuario"), MsgBoxStyle.Information, "INICIO DE SESIÓN")
                Response.Redirect("/MenuSecretaria.aspx")
            ElseIf (Convert.ToInt32(dsdatos.Tables(0).Rows(0).Item(1).ToString) = 2) Then
                LblError.Visible = False
                Session("usuario") = dsdatos.Tables(0).Rows(0).Item(4).ToString
                Session("Perfil") = Convert.ToInt16(dsdatos.Tables(0).Rows(0).Item(1).ToString)
                Session("rut") = dsdatos.Tables(0).Rows(0).Item(0).ToString
                MsgBox("Bienvenido al sistema usuario " & Session("usuario"), MsgBoxStyle.Information, "INICIO DE SESIÓN")
                Response.Redirect("/MenuProfesional.aspx")
            ElseIf (Convert.ToInt32(dsdatos.Tables(0).Rows(0).Item(1).ToString) = 3) Then
                LblError.Visible = False
                Session("usuario") = dsdatos.Tables(0).Rows(0).Item(4).ToString
                Session("Perfil") = Convert.ToInt16(dsdatos.Tables(0).Rows(0).Item(1).ToString)
                Session("rut") = dsdatos.Tables(0).Rows(0).Item(0).ToString
                MsgBox("Bienvenido al sistema usuario " & Session("usuario"), MsgBoxStyle.Information, "INICIO DE SESIÓN")
                Response.Redirect("/MenuPaciente.aspx")
            End If
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Public Sub VALIDARRUT()
        'Try
        Dim rutLimpio As String
            Dim digitoVerificador As String
            Dim suma As Integer
            Dim contador As Integer = 2
            Dim rut As String

            rut = Login1.UserName
            rutLimpio = Login1.UserName
            rutLimpio = rutLimpio.Replace("-", "")
            rutLimpio = rutLimpio.Replace(" ", "")
            rutLimpio = rutLimpio.Substring(0, rutLimpio.Length - 1)
            digitoVerificador = rut.Substring(rut.Length - 1, 1)


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
                INICIARSESION()
            Else
                Me.LblError.Visible = True
                Me.LblError.Text = "Rut Invalido"
            End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        VALIDARRUT()
    End Sub
End Class