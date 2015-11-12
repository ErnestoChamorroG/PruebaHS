<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ModificarNombreEspecialidad.aspx.vb" Inherits="CAPA_PRESENTACION.ModificarNombreEspecialidad" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificar Nombre Especialidad</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 223px;
        }
        .auto-style3 {
            width: 223px;
            text-align: right;
        }
    </style>--%>
    <script type="text/javascript" src="Scripts/jquery-1.11.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TxtNuevoNombre").keypress(function (key) {
                window.console.log(key.charCode)
                if ((key.charCode < 97 || key.charCode > 122)//letras mayusculas
                    && (key.charCode < 65 || key.charCode > 90) //letras minusculas
                    && (key.charCode != 45) //retroceso
                    && (key.charCode != 241) //ñ
                     && (key.charCode != 209) //Ñ
                     && (key.charCode != 32) //espacio
                     && (key.charCode != 225) //á
                     && (key.charCode != 233) //é
                     && (key.charCode != 237) //í
                     && (key.charCode != 243) //ó
                     && (key.charCode != 250) //ú
                     && (key.charCode != 193) //Á
                     && (key.charCode != 201) //É
                     && (key.charCode != 205) //Í
                     && (key.charCode != 211) //Ó
                     && (key.charCode != 218) //Ú

                    )
                    return false;
            });
            });     
    </script>
<%--</head>
<body>
    <form id="form1" runat="server">--%>
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <h2>
                        <asp:Label ID="Label1" runat="server" Text="MODIFICAR NOMBRE ESPECIALIDAD"></asp:Label>
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
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownNombre" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Nuevo Nombre:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtNuevoNombre" runat="server" MaxLength="50" required></asp:TextBox>
                    <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
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
