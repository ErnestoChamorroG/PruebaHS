<%@ Page Language="vb" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="false" CodeBehind="RegistroUsuarioPagWeb.aspx.vb" Inherits="CAPA_PRESENTACION.RegistroUsuarioPagWeb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 263px;
        }
        .auto-style3 {
            width: 263px;
            text-align: right;
        }
    </style>--%>
    
<%--</head>
<body>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style5 {
            text-align: right;
            height: 30px;
            width: 298px;
        }
        .auto-style6 {
            height: 30px;
        }
        .auto-style7 {
            width: 298px;
        }
        .auto-style8 {
            text-align: right;
            width: 298px;
        }
        .auto-style9 {
            width: 582px;
        }
        .auto-style10 {
            height: 30px;
            width: 582px;
        }
        .auto-style11 {
            width: 298px;
            height: 23px;
        }
        .auto-style12 {
            width: 582px;
            height: 23px;
        }
        .auto-style13 {
            height: 23px;
        }
    </style>

</asp:Content>

 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript" src="Scripts/jquery-1.11.2.min.js"></script>
    <script type="text/javascript">
        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
            especiales = [8, 37, 39, 46];

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial)
                return false;
        }
        
        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }

        function rut(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57 || key == 75 || key == 107)
        }
    </script>

     <%--<form id="form1" runat="server">--%>
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">
                    <h2>
                        <asp:Label ID="Label1" runat="server" Text="REGISTRO"></asp:Label>
                    </h2>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style12">
                </td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label2" runat="server" Text="Rut:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TxtRut" runat="server" MaxLength="9" onkeypress="return rut(event)" ToolTip="XXXXXXXXX"></asp:TextBox>
                    <asp:Label ID="LblValidarRut" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtRut" ErrorMessage="Debe ingresar Rut" ForeColor="Red" Display="Dynamic" ValidationGroup="pass">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label3" runat="server" Text="Nombres:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TxtNombres" runat="server" onkeypress="return soloLetras(event)" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombres" ErrorMessage="Debe ingresar los nombres" ForeColor="Red" Display="Dynamic" ValidationGroup="pass">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label4" runat="server" Text="Apellidos:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TxtApellidos" runat="server" MaxLength="50" onkeypress="return soloLetras(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtApellidos" ErrorMessage="Debe ingresar los apellidos" ForeColor="Red" Display="Dynamic" ValidationGroup="pass">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label10" runat="server" Text="Sexo:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:RadioButton ID="RadioFemenino" runat="server" Checked="True" GroupName="Genero" Text="Femenino" />
&nbsp;
                    <asp:RadioButton ID="RadioMasculino" runat="server" GroupName="Genero" Text="Masculino" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label11" runat="server" Text="Fecha de nacimiento:" requered></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TxtCalendario" runat="server" Enabled="False"></asp:TextBox>
                    <asp:ImageButton ID="ImgBtnCanlendario" runat="server" Height="25px" ImageUrl="~/Scripts/calendarIcon.png" Width="25px" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImgBtnCanlendario" PopupPosition="BottomRight" TargetControlID="TxtCalendario" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label5" runat="server" Text="Dirección:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TxtDireccion" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="Debe ingresar su dirección" ForeColor="Red" Display="Dynamic" ValidationGroup="pass">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label6" runat="server" Text="Fono:"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="TxtFono" runat="server" onkeypress="return soloNumeros(event)" MaxLength="50" extMode="Number" ValidationGroup="pass"></asp:TextBox>
                &nbsp;<asp:Label ID="Label30" runat="server" ForeColor="Gray" Text="ej:0912345678"></asp:Label>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ErrorMessage="Ingrese un celular valido" ForeColor="Red" ValidationExpression="^(09[6-9][0-9]{7})$" ControlToValidate="TxtFono"></asp:RegularExpressionValidator>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtFono" ErrorMessage="Debe ingresar el fono" ForeColor="Red" Display="Dynamic" ValidationGroup="pass">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label7" runat="server" Text="Correo electrónico:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TxtEmail" runat="server" MaxLength="20" ValidationGroup="pass"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Ingrese un Email valido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Debe ingresar el Email" ForeColor="Red" Display="Dynamic" ValidationGroup="pass">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label8" runat="server" Text="Contraeña:"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="TxtContrasena" runat="server" MaxLength="15" TextMode="Password" ValidationGroup="pass1"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtContrasena" ErrorMessage="Debe ingresar contraseña" ForeColor="Red" Display="Dynamic" ValidationGroup="pass">*</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtContrasena" Display="Dynamic" ErrorMessage="La contraseña deber se de 8 caracteres minimo, contener una letra mayúscula, una minuscula y un número" ForeColor="Red" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label9" runat="server" Text="Repita contraseña:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TxtRepContrasena" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="LBlErrorPass" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="pass" Width="579px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style12">
                </td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">
                    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" ValidationGroup="pass" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
   <%-- </form>--%>
 </asp:Content>
    
<%--</body>
</html>--%>
