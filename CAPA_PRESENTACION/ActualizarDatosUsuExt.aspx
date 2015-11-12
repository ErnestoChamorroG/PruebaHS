<%@ Page Language="vb" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="false" CodeBehind="ActualizarDatosUsuExt.aspx.vb" Inherits="CAPA_PRESENTACION.ActualizarDatosUsuExt" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Actualizar Datos</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            width: 270px;
        }
        .auto-style4 {
            width: 270px;
            text-align: right;
        }
    </style>
</head>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style5 {
            text-align: right;
            height: 30px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <form id="form1" runat="server">--%>
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
    </script>
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <h2 class="auto-style2">ACTUALIZAR DATOS</h2>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Rut:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtRut" runat="server" Enabled="False" MaxLength="10"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" Text="Nombres:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtNombres" runat="server" onkeypress="return soloLetras(event)" Enabled="False" MaxLength="50"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label4" runat="server" Text="Apellidos:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtApellidos" runat="server" Enabled="False" MaxLength="50"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label5" runat="server" Text="Fecha de  nacimiento:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtFechaNac" runat="server" Enabled="False" MaxLength="15"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label6" runat="server" Text="Dirección:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtDireccion" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="Debe ingresar su dirección" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label7" runat="server" Text="Fono:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtFono" runat="server" onkeypress="return soloNumeros(event)" MaxLength="12" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="Label30" runat="server" ForeColor="Gray" Text="ej:0912345678"></asp:Label>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ErrorMessage="Ingrese un celular valido" ForeColor="Red" ValidationExpression="^(09[6-9][0-9]{7})$" ControlToValidate="TxtFono"></asp:RegularExpressionValidator>
                &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label8" runat="server" Text="Correo electrónico:"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="TxtEmail" runat="server" MaxLength="35" TextMode="Email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Ingrese un Email valido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Debe ingresar el Email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label9" runat="server" Text="Nueva Contraseña:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txtpass" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Txtpass" ErrorMessage="Debe ingresar contraseña" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Txtpass" Display="Dynamic" ErrorMessage="La contraseña deber se de 8 caracteres minimo, contener una letra mayúscula, una minuscula y un número" ForeColor="Red" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label10" runat="server" Text="Repetir nueva contraseña:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtRepPass" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="LblErrorPass" runat="server" Enabled="False" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    <%--</form>--%>
</asp:Content>
<%--</body>
</html>--%>
