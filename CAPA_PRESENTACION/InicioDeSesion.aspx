<%@ Page Language="vb" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="false" CodeBehind="InicioDeSesion.aspx.vb" Inherits="CAPA_PRESENTACION.InicioDeSesion" %>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<%--<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio De Sesión</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 285px;
        }
        .auto-style3 {
            width: 341px;
        }
        .auto-style4 {
            text-align: center;
        }
    </style>
</head>--%>
<%--<body>--%>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
    .auto-style3 {
        text-align: center;
    }
    .auto-style4 {
        width: 251px;
    }
    .auto-style5 {
        text-align: center;
        width: 341px;
    }
    .auto-style6 {
        width: 433px;
        text-align: right;
    }
</style>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    </script>
        <div>
        <table class="auto-style1">
            <tr>
                <td colspan="3">
                    <h2 class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Inicio De Sesión"></asp:Label>
                    </h2>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Login ID="Login1" runat="server">
                    </asp:Login>
                </td>
                <td>
                    <asp:Label ID="LblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    
    </asp:Content>
<%--    
</body>--%>
<%--</html>--%>
