<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DeshabilitarEspecialidad.aspx.vb" Inherits="CAPA_PRESENTACION.DeshabilitarEspecialidad" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Deshabilitar Especialidad</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 224px;
        }
        .auto-style3 {
            width: 224px;
            text-align: right;
        }
    </style>
</head>
<body>--%>

<%--    <form id="form1" runat="server">--%>
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <h2>
                        <asp:Label ID="Label1" runat="server" Text="DESHABILITAR ESPECIALIDAD"></asp:Label>
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
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownNombre" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                        <asp:ListItem>Eliga espelialidad</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Estado actual:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtEstadoActual" runat="server" Enabled="False" required></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label4" runat="server" Text="Nuevo estado:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownNuevoEstado" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Habilitado</asp:ListItem>
                        <asp:ListItem>Inhabilitado</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
<%--    </form>
</body>
</html>--%>
