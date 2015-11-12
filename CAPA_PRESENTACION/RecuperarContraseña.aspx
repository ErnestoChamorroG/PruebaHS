<%@ Page Language="vb" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="false" CodeBehind="RecuperarContraseña.aspx.vb" Inherits="CAPA_PRESENTACION.RecuperarContraseña" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Recuperacion De Contraseña</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 254px;
        }
        .auto-style3 {
            width: 254px;
            height: 23px;
            text-align: right;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 254px;
            text-align: right;
        }
    </style>
</head>
<body>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <script type="text/javascript" src="Scripts/jquery-1.11.2.min.js"></script>
            <script type="text/javascript">
                function rut(e) {
                var key = window.Event ? e.which : e.keyCode
                return (key >= 48 && key <= 57 || key == 75 || key == 107)
            }
            </script>
    <%--form id="form1" runat="server">--%>
    <div>   
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <h2>
                        <asp:Label ID="Label1" runat="server" Text="RECUPERAR CONTRASEÑA"></asp:Label>
                    </h2>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Ingrese su rut:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtRut" runat="server" onkeypress="return rut(event)" MaxLength="10"></asp:TextBox>
                    <asp:Label ID="LblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnRecuperar" runat="server" Text="Recuperar" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
    
<%--    </form>
</body>
</html>--%>
