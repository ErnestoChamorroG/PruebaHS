<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Admin.aspx.vb" Inherits="CAPA_PRESENTACION.Admin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 173px;
        }
        .auto-style4 {
            width: 107px;
        }
        #tabla2 {
            margin-right: 0px;
        }
        .auto-style24 {
            width: 978px;
        }
        .auto-style38 {
            width: 32%;
        }
        .auto-style39 {
            margin-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <table id="tabla2" runat="server" border="0" >
                <tr>
                    <td class="auto-style38">
                       <div> <ul>
                            <li><asp:LinkButton ID="LinkbtnCuentasUsuario" runat="server">Cuentas de usuarios</asp:LinkButton>
                                <ul>
                                    <li><asp:LinkButton CommandName="Crear Cuenta" ID="LinkbtnCrearCuenta" runat="server">Crear nueva Cuenta</asp:LinkButton></li>
                                    <li><asp:LinkButton  ID="LinkbtnMOD" runat="server">Modificar Cuenta</asp:LinkButton>
                                        <ul>
                                            <li><asp:LinkButton CommandName="Modificar Datos" ID="LinkBtnModificardatos"  runat="server">Modificar datos personales</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton CommandName="ModificarEstado" ID="LinkBtnModificarEstado" runat="server">Modificar estado </asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton CommandName="ReestablecerContra" ID="LinkBtnReestrablecerContra" runat="server">Reestablecer contraseña</asp:LinkButton></li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                           <li><asp:LinkButton ID="LinkBtnHorarios" runat="server">Horarios</asp:LinkButton>
                               <ul>
                               <li><asp:LinkButton CommandName="RegistrarHorario" ID="LinkbtnRegistrarHorario" runat="server">Registrar Horario</asp:LinkButton></li>
                                     <li><asp:LinkButton CommandName="ModificarHorario" ID="LinkbtnModificarHorario" runat="server">Modificar Horario</asp:LinkButton></li>
                               </ul>
                           </li>
                           <li>
                               <asp:LinkButton ID="LinkbtnReserva" runat="server">Reserva</asp:LinkButton>
                               <ul>
                                   <li><asp:LinkButton CommandName="RegistrarReserva" ID="LinkbtnRegistrarReserva" runat="server">Registrar Reserva</asp:LinkButton></li> 
                                   <li><asp:LinkButton CommandName="CancelarReserva" ID="LinkbtnCancelarReserva" runat="server">Cancelar Reserva</asp:LinkButton>&nbsp;</li>
                               </ul>
                           </li>
                           <li>
                               <asp:LinkButton ID="LinkbtnEspecialidad" runat="server">Especialidad</asp:LinkButton>
                               <ul>
                                   <li><asp:LinkButton CommandName="RegistrarEspecialidad" ID="LinkBtnRegistrarEspecialidad" runat="server">Agregar Especialidad</asp:LinkButton></li>
                                   <li><asp:LinkButton CommandName="ModificarNombreEspecilidad" ID="LinkBtnModificarNombreEspecialidad" runat="server">Modificar Nombre Especialidad</asp:LinkButton></li>
                                   <li><asp:LinkButton CommandName="DeshabilitarEspecialidad" ID="linkBtnDeshabilitarEspecialidad" runat="server">Deshabilitar Especialidad</asp:LinkButton></li>
                               </ul>
                           </li>   
                        </ul> 
                           </div>
                    </td><td>&nbsp;</td>
                    <td class="auto-style24">
                      
                    
                            <asp:MultiView ID="MW_CuentasUsuarios" runat="server" Visible="true">
                                <asp:View ID="View0" runat="server"></asp:View>
                                <asp:View ID="View1" runat="server">
                                    <%-- VIEW CREAR NUEVO USUARIO --%>
                          <h2>Crear nueva cuenta</h2>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>

                                    <asp:Label ID="Label3" runat="server" Text="Label" ValidateRequestMode="Enabled">RUT :</asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtRutNC" runat="server" onkeypress="return rut(event)" MaxLength="9" required="" TabIndex="1"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="REV_NC_RUT" runat="server" ControlToValidate="txtRutNC" Display="Dynamic" ErrorMessage="Ingrese rut sin puntos ni guión" ForeColor="Red" ValidationExpression="[0-9]+[k|K|0-9]">Ingrese rut sin puntos ni guión</asp:RegularExpressionValidator>
                                    &nbsp;<asp:Label ID="lblMensajeErrorRUTNC" runat="server" Text="Label" Visible="false" ></asp:Label>
                                    <br />
                                    <br />&nbsp;<asp:Label ID="Label1" runat="server" Text="Label">Nombres :</asp:Label>
&nbsp;
                                    <asp:TextBox ID="txtNombresNC" runat="server" CssClass="auto-style39" TabIndex="2" Width="205px"></asp:TextBox>
                                    <br />
                                    <br/>
                                    <asp:Label ID="Label2" runat="server" Text="Label">Apellidos :</asp:Label>
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="txtApellidosNC" runat="server"  TabIndex="3" Width="201px" onkeypress="return soloLetras(event)"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label24" runat="server" Text="Sexo :"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlSexoNC" runat="server" AutoPostBack="true"  TabIndex="4">
                                        <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                                        <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Label ID="Label26" runat="server" Text="Fecha de nacimiento :"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtFechaNacimientoNC" runat="server" TabIndex="5" required="">dd/MM/aaaa</asp:TextBox>
                                    <asp:ImageButton ID="ImgCalendarioNC" runat="server" Height="25px" ImageUrl="~/Iconos/calendarioB.png" Width="25px" />
                                    <ajaxToolkit:CalendarExtender ID="Calenda" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarioNC" PopupPosition="BottomRight" TargetControlID="txtFechaNacimientoNC" />
                                    <br />
                                    <br/>
                                    <asp:Label ID="Label4" runat="server" Text="Label">Dirección :</asp:Label>
                                    &nbsp;&nbsp;
                            <asp:TextBox ID="txtDireccionNC" runat="server"  TabIndex="6" Width="206px" required=""></asp:TextBox>
                                    <br />
                                    <br/>
                            <asp:Label ID="Label5" runat="server" Text="Label">Fono :</asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtFonoNC" runat="server"  TabIndex="7" onkeypress="return soloNumeros(event)" TextMode="Phone" required=""></asp:TextBox><asp:Label ID="Label29" runat="server" Text="ej:(09)+12345678" ForeColor="#999999" style="font-style: italic"></asp:Label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFonoNC" Display="Dynamic" ErrorMessage="En fono: solo se permiten numeros" ForeColor="Red" ValidationExpression="^(09[6-9][0-9]{7})$">Solo se permiten numeros</asp:RegularExpressionValidator>
                                    <br />
                                    <br/>
                            <asp:Label ID="Label9" runat="server" Text="Label">Correo :</asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:TextBox ID="txtCorreoNC" runat="server"  TabIndex="8" Width="156px" required="" TextMode="Email"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCorreoNC" Display="Dynamic" ErrorMessage="Ingrese un correo válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Ingrese un correo válido</asp:RegularExpressionValidator>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label28" runat="server" Text="Label">Repetir Correo :</asp:Label>
                                    &nbsp;
                            <asp:TextBox ID="txtRepetirCorreoNC" runat="server"  TabIndex="8" Width="218px" required="" TextMode="Email"></asp:TextBox>
                                    <asp:CompareValidator ID="ReenterCorreoCompareValidator1" runat="server" ControlToCompare="txtCorreoNC" ControlToValidate="txtRepetirCorreoNC" Display="Dynamic" ErrorMessage="Correos son diferentes" ForeColor="Red">*</asp:CompareValidator>
                                    <br />
                                    <br/>
                            <asp:Label ID="Label8" runat="server" Text="Label">Tipo Perfil :</asp:Label>
                            <asp:DropDownList ID="ddlPerfilesNC" runat="server" AutoPostBack="True"  TabIndex="11"></asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblAsignarEspecialidadNC" runat="server" Text="Label" Visible="false"> Asignar especialidad : </asp:Label>
                                    <asp:DropDownList ID="ddlAsignarEspecialidadNC" runat="server" AutoPostBack="True" TabIndex="12" Visible="false">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label6" runat="server" Text="Label">Contraseña :</asp:Label>
                                    &nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtContraseniaNC" runat="server"  TabIndex="9" TextMode="Password" Width="149px" required=""></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtContraseniaNC" Display="Dynamic" ErrorMessage="La contraseña deber se de 8 caracteres minimo, contener una letra mayúscula, una minuscula y un número" ForeColor="Red" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"></asp:RegularExpressionValidator>
                                    <br />
                                    <br/>
                                    <asp:Label ID="Label7" runat="server" Text="Label">Repetir Contraseña :</asp:Label>
                                    &nbsp;<asp:TextBox ID="txtRepetirContraNC" runat="server" TabIndex="10" TextMode="Password" Width="129px" required=""></asp:TextBox>
                                    <asp:CompareValidator ID="ReenterEmailCompareValidator1" runat="server" ErrorMessage="Las contraseñas son diferentes" ControlToCompare="txtContraseniaNC" ControlToValidate="txtRepetirContraNC" Display="Dynamic" ForeColor="Red">*</asp:CompareValidator>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label25" runat="server" Text="Label">Estado :</asp:Label>
                                    <asp:DropDownList ID="ddlEstadoNC" runat="server"  TabIndex="13">
                                        <asp:ListItem Text="Habilitado" Value="Habilitado"></asp:ListItem>
                                        <asp:ListItem Text="Inhabilitado" Value="Inhabilitado"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Label ID="lblMesajeErrorMC" runat="server" Text="Label" Visible="false"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblmensajeError2NC" runat="server" Text="Label" Visible="False" ></asp:Label>
                                    <asp:Label ID="lblMensajeRegistroExitosoNC" runat="server" Text="Label" Visible="False"></asp:Label>
                                    <br />
                                    <asp:Button ID="btnAceptarNuevaCuenta" runat="server" Text="Aceptar" TabIndex="13" />
                                    <asp:Button ID="btnCancelarNuevaCuenta" runat="server" Text="Cancelar" TabIndex="14"  CommandName="Cancelar"/>
                                    <asp:Button ID="btnLimpiarNuevaCuenta" runat="server" Text="Limpiar" TabIndex="15" />
                                    <br/>
                                   
                         
                                </asp:View>
                                <%-- View MODIFICAR DATOS PERSONALES DE USUARIO --%>
                                <asp:View ID="View2" runat="server">
                             <h2>Modificar Datos personales </h2>
                         <asp:Label ID="Label10" runat="server" Text="Buscar por RUT :"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtBuscarporRUTMOD" runat="server" onkeypress="return rut(event)" AutoPostBack="True" required="" MaxLength="9"></asp:TextBox>
                                    &nbsp;
                                    <asp:Button ID="BtnBuscarPorRutMOD" runat="server" Text="Buscar"/>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtBuscarporRUTMOD" ErrorMessage="Ingresar rut sin puntos ni guión" ForeColor="Red" ValidationExpression="[0-9]+[k|K|0-9]" Display="Dynamic">*</asp:RegularExpressionValidator>
                                    <br />
                                    <hr />
                                    <h3><asp:Label ID="LblVistaRUTMOD" runat="server" Visible="false"></asp:Label></h3>
                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="Red" />
                                    <br/>
                                   
                                     <asp:Label ID="Label11" runat="server" Text="Label">Nombres :</asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtNombresMOD" runat="server" onkeypress="return soloLetras(event)" style="text-align: center" Width="205px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label12" runat="server" Text="Label">Apellidos :</asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtApellidosMOD" runat="server" onkeypress="return soloLetras(event)" Width="204px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label23" runat="server" Text="Sexo :"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:DropDownList ID="ddlSexoMOD" runat="server">
                                        <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                                        <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label27" runat="server" Text="Fecha de nacimiento :"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtFechaNacimientoMOD" runat="server" TabIndex="5">dd/MM/aaaa</asp:TextBox>
                                    <asp:ImageButton ID="ImgCalendarioMOD" runat="server" Height="25px" ImageUrl="~/Iconos/calendarioB.png" Width="25px" />
                                    <ajaxToolkit:CalendarExtender ID="Calenda0" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImgCalendarioMOD" PopupPosition="BottomRight" TargetControlID="txtFechaNacimientoMOD" />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label14" runat="server" Text="Label">Dirección :</asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtDireccionMOD" runat="server" Width="240px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label15" runat="server" Text="Label">Fono :</asp:Label>
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                      <asp:TextBox ID="txtFonoMOD" runat="server" onkeypress="return soloNumeros(event)"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label16" runat="server" Text="Label">Correo :</asp:Label>
                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                      <asp:TextBox ID="txtCorreoMOD" runat="server" Width="180px"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label19" runat="server" Text="Label">Tipo Perfil :</asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlPerfilesMOD" runat="server" style="margin-left: 0px" AutoPostBack="True">
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:Label ID="lblAsignarEspecialidadMOD" runat="server" Text="Label" Visible="false"> Asignar especialidad : </asp:Label>
                                    <asp:DropDownList ID="ddlAsignarEspecialidadMOD" runat="server" AutoPostBack="True" TabIndex="12" Visible="false">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="lblmensaje1MOD" runat="server" Text="" Visible="false" ></asp:Label>
                                    <asp:Label ID="lblmensaje2MOD" runat="server" Text="" Visible="false" ></asp:Label>
                                    <br />
                                    <asp:Button ID="btnModificarCuentaMOD" runat="server" Text="Modificar" />
                                    <asp:Button CommandName=" Cancelar MOD " ID="btnCancelarNuevaCuentaMOD" runat="server" Text="Cancelar" />
                                    <asp:Button ID="btnLimpiarNuevaCuentaMOD" runat="server" Text="Limpiar" />
                                    <br />
                                    <br />
                                </asp:View>
                                           
                                <%-- MODIFICAR ESTADO DE CUENTA --%>
                                <asp:View ID="View3" runat="server">
                                     <h2>Modificar estado de cuenta</h2>
                                    <asp:Label ID="Label13" runat="server" Text="Buscar por RUT :"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtBuscarporRutMOES" runat="server" onkeypress="return rut(event)" AutoPostBack="True" MaxLength="9"></asp:TextBox>
                                    &nbsp;
                                    <asp:Button ID="BtnBuscarRutMOES" runat="server" Text="Buscar" CommandName="Buscar por RUT MOES"/>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtBuscarporRutMOES" ErrorMessage="Ingrese RUT sin puntos ni guión" ForeColor="Red" ValidationExpression="[0-9]+[k|K|0-9]" Display="Dynamic">*</asp:RegularExpressionValidator>
                                    <hr />
                                    <h3><asp:Label ID="LblRutAsociadoMOES" runat="server" Text=""></asp:Label></h3>
                                     <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" />
                                   <asp:Label ID="Label17" runat="server" Text="Label">Estado de cuenta :</asp:Label>
                                     &nbsp;<asp:DropDownList ID="ddlMOESmodificarEstado" runat="server" AutoPostBack="True">
                                         <asp:ListItem Value="Habilitado">Habilitado</asp:ListItem>
                                         <asp:ListItem Value="Inhabilitado">Inhabilitado</asp:ListItem>
                                     </asp:DropDownList>
                                     <br />
                                     <asp:Label ID="lblregistroexitosoMOES" runat="server" Text="Label" Visible="False"></asp:Label>
                                     <br />
                                     <br />
                                     <asp:Button ID="btnAceptarMOES" runat="server" Text="Aceptar" CommandName="Aceptar MOES" />
                                    <asp:Button ID="btnCancelarMOES" runat="server" Text="Cancelar" CommandName="Cancelar MOES" />
                                     <br />
                                </asp:View>
                                <%-- REESTABLECER CONTRASEÑAS DE USUARIOS --%>
                                <asp:View ID="View4" runat="server">
                                    <h2>Reestablecer Contraseña</h2>
                                      <asp:Label ID="Label18" runat="server" Text="Buscar por RUT :"></asp:Label>
                                    &nbsp;<asp:TextBox ID="txtRUTReesContra" runat="server" AutoPostBack="True" required="" MaxLength="9"></asp:TextBox>
                                    &nbsp;
                                    <asp:Button ID="btnBuscarReesContra" runat="server" Text="Buscar" CommandName="Buscar por RUT ReesContra"/>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtRUTReesContra" Display="Dynamic" ErrorMessage="Ingrese RUT sin puntos ni guión" ForeColor="Red" ValidationExpression="[0-9]+[k|K|0-9]">*</asp:RegularExpressionValidator>
                                    <hr />
                                    <h3><asp:Label ID="lblRUTReescontra" runat="server" Text=""></asp:Label></h3>
                                   
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="SingleParagraph" ForeColor="Red" />
                                    <asp:Label ID="lblContraseñaAnterior" runat="server" Text=""></asp:Label>
                                    <br />
                                    <br />
                                   <asp:Label ID="Label22" runat="server" Text="Label">Nueva contraseña :</asp:Label>
                                    <asp:TextBox ID="txtContraseniaReesContra" runat="server" TextMode="Password"></asp:TextBox> 
                                    <br />
                                    <br/>

                                    <asp:Label ID="Label20" runat="server" Text="Label">Repetir contraseña :</asp:Label>
                                    <asp:TextBox ID="txtRepetirContraReesContra" runat="server" TextMode="Password"></asp:TextBox> 
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContraseniaReesContra" ControlToValidate="txtRepetirContraReesContra" Display="Dynamic" ErrorMessage="Contraseñas no son iguales" ForeColor="Red">*</asp:CompareValidator>
                                    <br />
                                    <br />
                                    <asp:Label ID="lblregistroexitosoReescontra" runat="server" Text=""></asp:Label>
                                    <br/>
                                    <asp:Button ID="btnAceptarReesContra" runat="server" Text="Aceptar" CommandName="Aceptar ReesContra" />
                                    <asp:Button ID="btnCancelarReesContra" runat="server" Text="Cancelar" CommandName="Cancelar ReesContra" />
                                </asp:View>
                                <%-- ASIGNAR HORARIO DE ATENCION --%>
                                <asp:View ID="View5" runat="server">

                                    <h2>Asignar horario de atención</h2>
                                    <br />

                                    &nbsp;
                                    <asp:Label ID="Label39" runat="server" Text="Label">Asignar Especialidad :</asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlAsignarEspecialidadAH" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text = "--Seleccione Especialidad--" Value = ""/>
                                    </asp:DropDownList>
                                    <br />
                                    <br />
&nbsp;
                                    <asp:Label ID="Label40" runat="server" Text="Label">Asignar Profesional :</asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                    <asp:DropDownList ID="ddlAsignarProfesionalAH" runat="server" AutoPostBack="True" Enabled="False" TabIndex="2" ValidationGroup="ValidacionDDL">
                                        <asp:ListItem Text="--Seleccione un profesional de la salud--" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnVerDisponibilidadAH" runat="server" Text="Ver Disponibilidad" ValidationGroup="ValidacionDDL" TabIndex="3" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage="Seleccione una especialidad y luego a un profesional" Display="Dynamic" ForeColor="Red" ValidationGroup="ValidacionDDL" ControlToValidate="ddlAsignarProfesionalAH">*</asp:RequiredFieldValidator>
                                    <asp:ValidationSummary ID="ValidationSummary7" runat="server" ForeColor="Red" ValidationGroup="ValidacionDDL" />
                                    <br />
                                    <table visible="true"  style="border-color:black" border="1" >
                                         <tr><td class="auto-style4"></td> <td class="auto-style35">Hora Inicio<br /> (hora:minuto)</td> <td class="auto-style35">Hora Término<br /> (hora:minuto)</td> <td class="auto-style35">Hora Inicio<br /> (hora:minuto)</td>
                                             <td class="auto-style35">Hora Término<br /> (hora:minuto)</td>
                                             <td class="auto-style35">Asignar</td>
                                         </tr>
                                        <tr><td class="auto-style30">Lunes :<asp:ImageButton ID="imgbtnLunes" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtLunesHoraInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="4" CausesValidation="True" ValidationGroup="GrupoLUNES"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLunesHoraInicio1" Display="Dynamic" ErrorMessage="Inserte HORA DE INICIO de dia LUNES" ForeColor="Red" ValidationGroup="GrupoLUNES">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtLunesHoraInicio1" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                            &nbsp;:
                                            <asp:TextBox ID="txtLunesMinutoInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="5" ValidationGroup="GrupoLUNES"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLunesMinutoInicio1" ErrorMessage="Inserte MINUTO DE INICIO de dia MARTES" ForeColor="Red" Display="Dynamic" ValidationGroup="GrupoLUNES">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtLunesMinutoInicio1" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtLunesHoraTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="6" ValidationGroup="GrupoLUNES"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtLunesHoraTermino2" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                                &nbsp;:
                                                <asp:TextBox ID="txtLunesMinutoTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="7" ValidationGroup="GrupoLUNES"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtLunesMinutoTermino2" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtLunesHoraInicio3" runat="server" Height="16px" MaxLength="2" TabIndex="8" ValidationGroup="GrupoLUNES" Width="20px"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtLunesHoraInicio3" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtLunesMinutoInicio3" runat="server" Height="16px" MaxLength="2" TabIndex="9" ValidationGroup="GrupoLUNES" Width="20px"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txtLunesMinutoInicio3" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtLunesHoraTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="10" ValidationGroup="GrupoLUNES" Width="20px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtLunesHoraTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia LUNES" ForeColor="Red" ValidationGroup="GrupoLUNES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator13" runat="server" ControlToValidate="txtLunesHoraTermino4" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtLunesMinutoTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="11" ValidationGroup="GrupoLUNES" Width="20px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtLunesMinutoTermino4" Display="Dynamic" ErrorMessage="Inserte minuno de término de dia LUNES" ForeColor="Red" ValidationGroup="GrupoLUNES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator14" runat="server" ControlToValidate="txtLunesMinutoTermino4" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnLunesAH" runat="server" style="text-align: center" TabIndex="12" Text="Guardar" ValidationGroup="GrupoLUNES" Width="82px" CommandName="GuardarLUNES" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Martes :<asp:ImageButton ID="imgbtnMartes" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtMartesHoraInicio1" runat="server" Height="16px" MaxLength="2" TabIndex="13" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMartesHoraInicio1" Display="Dynamic" ErrorMessage="Inserte HORA DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMARTES">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtMartesHoraInicio1" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            &nbsp;:
                                            <asp:TextBox ID="txtMartesMinutoInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="14" ValidationGroup="GrupoMARTES"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMartesMinutoInicio1" ErrorMessage="Inserte MINUTO DE INICIO de dia MARTES" ForeColor="Red" Display="Dynamic" ValidationGroup="GrupoMARTES">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtMartesMinutoInicio1" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtMartesHoraTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="15" ValidationGroup="GrupoMARTES"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtMartesHoraTermino2" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                                &nbsp;:
                                                <asp:TextBox ID="txtMartesMinutoTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="16" ValidationGroup="GrupoMARTES"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtMartesMinutoTermino2" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtMartesHoraInicio3" runat="server" Height="16px" MaxLength="2" TabIndex="17" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator17" runat="server" ControlToValidate="txtMartesHoraInicio3" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                                &nbsp;:
                                                <asp:TextBox ID="txtMartesMinutoInicio3" runat="server" Height="16px" MaxLength="2" TabIndex="18" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator18" runat="server" ControlToValidate="txtMartesMinutoInicio3" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtMartesHoraTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="19" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtMartesHoraTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMARTES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator15" runat="server" ControlToValidate="txtMartesHoraTermino4" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtMartesMinutoTermin4" runat="server" Height="16px" MaxLength="2" TabIndex="20" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtMartesMinutoTermin4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMARTES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator16" runat="server" ControlToValidate="txtMartesMinutoTermin4" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnMartesAH" runat="server" style="text-align: center" TabIndex="21" Text="Guardar" ValidationGroup="GrupoMARTES" Width="82px" CommandName="GuardarMARTES" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Miércoles:<asp:ImageButton ID="imgbtnMiercoles" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtMiercolesHoraInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="22" ValidationGroup="GrupoMiercoles"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtMiercolesHoraInicio1" Display="Dynamic" ErrorMessage="Inserte HORA DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMIERCOLES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator33" runat="server" ControlToValidate="txtMiercolesHoraInicio1" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMiercoles">*</asp:RangeValidator>
                                            &nbsp;:
                                            <asp:TextBox ID="txtMiercolesMinutoInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="23" ValidationGroup="GrupoMiercoles"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtMiercolesMinutoInicio1" Display="Dynamic" ErrorMessage="Inserte MINUTO DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMiercoles">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator34" runat="server" ControlToValidate="txtMiercolesMinutoInicio1" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMiercoles">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtMiercolesHoraTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="24" ValidationGroup="GrupoMiercoles"></asp:TextBox>
                                                &nbsp;<asp:RangeValidator ID="RangeValidator35" runat="server" ControlToValidate="txtMiercolesHoraTermino2" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMiercoles">*</asp:RangeValidator>
                                                :
                                                <asp:TextBox ID="txtMiercolesMinutoTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="25" ValidationGroup="GrupoMiercoles"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator36" runat="server" ControlToValidate="txtMiercolesMinutoTermino2" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMiercoles">*</asp:RangeValidator>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtMiercolesHoraTermino3" runat="server" Height="16px" MaxLength="2" TabIndex="26" Width="20px" ValidationGroup="GrupoMiercoles"></asp:TextBox>
                                                &nbsp;<asp:RangeValidator ID="RangeValidator37" runat="server" ControlToValidate="txtMiercolesHoraTermino3" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMiercoles">*</asp:RangeValidator>
                                                :&nbsp;<asp:TextBox ID="txtMiercolesMinutoTermino3" runat="server" Height="16px" MaxLength="2" TabIndex="27" Width="20px" ValidationGroup="GrupoMiercoles"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator38" runat="server" ControlToValidate="txtMiercolesMinutoTermino3" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMiercoles">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtMiercolesHoraTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="28" Width="20px" ValidationGroup="GrupoMiercoles"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtMiercolesHoraTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMiercoles">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator57" runat="server" ControlToValidate="txtMiercolesHoraTermino4" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMiercoles">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtMiercolesMinutoTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="29" Width="20px" ValidationGroup="GrupoMiercoles"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtMiercolesMinutoTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMiercoles">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator61" runat="server" ControlToValidate="txtMiercolesMinutoTermino4" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMiercoles">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnMiercolesAH" runat="server" style="text-align: center" TabIndex="30" Text="Guardar" Width="82px" ValidationGroup="GrupoMiercoles" CommandName="GuardarMIERCOLES" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Jueves :<asp:ImageButton ID="imgbtnJueves" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtJuevesHoraInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="31" ValidationGroup="GrupoJueves" TextMode="Number"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtJuevesHoraInicio1" Display="Dynamic" ErrorMessage="Inserte HORA DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoJueves">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator45" runat="server" ControlToValidate="txtJuevesHoraInicio1" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoJueves">*</asp:RangeValidator>
                                            &nbsp;:
                                            <asp:TextBox ID="txtJuevesMinutoInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="32" ValidationGroup="GrupoJueves"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtJuevesMinutoInicio1" Display="Dynamic" ErrorMessage="Inserte MINUTO DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoJueves">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator48" runat="server" ControlToValidate="txtJuevesMinutoInicio1" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoJueves">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtJuevesHoraTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="33" ValidationGroup="GrupoJueves"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator51" runat="server" ControlToValidate="txtJuevesHoraTermino2" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoJueves">*</asp:RangeValidator>
                                                &nbsp;:
                                                <asp:TextBox ID="txtJuevesMinutoTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="34" ValidationGroup="GrupoJueves"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator54" runat="server" ControlToValidate="txtJuevesMinutoTermino2" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoJueves">*</asp:RangeValidator>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtJuevesHoraInicio3" runat="server" Height="16px" MaxLength="2" TabIndex="35" Width="20px" ValidationGroup="GrupoJueves" TextMode="Number"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator42" runat="server" ControlToValidate="txtJuevesHoraInicio3" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoJueves">*</asp:RangeValidator>
                                                :&nbsp;<asp:TextBox ID="txtJuevesMinutoInicio3" runat="server" Height="16px" MaxLength="2" TabIndex="36" Width="20px" ValidationGroup="GrupoJueves"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator39" runat="server" ControlToValidate="txtJuevesMinutoInicio3" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoJueves">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtJuevesHoraTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="37" Width="20px" ValidationGroup="GrupoJueves" TextMode="Number"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtJuevesHoraTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoJueves">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator58" runat="server" ControlToValidate="txtJuevesHoraTermino4" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoJueves">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtJuevesMinutoTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="38" Width="20px" ValidationGroup="GrupoJueves"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtJuevesMinutoTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoJueves">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator62" runat="server" ControlToValidate="txtJuevesMinutoTermino4" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoJueves">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnJuevesAH" runat="server" style="text-align: center" TabIndex="39" Text="Guardar" Width="82px" ValidationGroup="GrupoJueves" CommandName="GuardarJUEVES" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Viernes :<asp:ImageButton ID="imgbtnViernes" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtViernesHoraInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="40" ValidationGroup="GrupoViernes" TextMode="Number"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtViernesHoraInicio1" Display="Dynamic" ErrorMessage="Inserte HORA DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoViernes">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator46" runat="server" ControlToValidate="txtViernesHoraInicio1" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            &nbsp;:
                                            <asp:TextBox ID="txtViernesMinutoInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="41" ValidationGroup="GrupoViernes"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtViernesMinutoInicio1" Display="Dynamic" ErrorMessage="Inserte MINUTO DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoViernes">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator49" runat="server" ControlToValidate="txtViernesMinutoInicio1" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoViernes">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtViernesHoraTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="42" ValidationGroup="GrupoViernes"></asp:TextBox>
                                                &nbsp;<asp:RangeValidator ID="RangeValidator52" runat="server" ControlToValidate="txtViernesHoraTermino2" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoViernes">*</asp:RangeValidator>
                                                :
                                                <asp:TextBox ID="txtViernesMinutoTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="43" ValidationGroup="GrupoViernes"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator55" runat="server" ControlToValidate="txtViernesMinutoTermino2" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoViernes">*</asp:RangeValidator>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtViernesHoraTermino3" runat="server" Height="16px" MaxLength="2" TabIndex="44" Width="20px" ValidationGroup="GrupoViernes" TextMode="Number"></asp:TextBox>
                                                &nbsp;<asp:RangeValidator ID="RangeValidator43" runat="server" ControlToValidate="txtViernesHoraTermino3" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoViernes">*</asp:RangeValidator>
                                                :&nbsp;<asp:TextBox ID="txtViernesMinutoTermino3" runat="server" Height="16px" MaxLength="2" TabIndex="45" Width="20px" ValidationGroup="GrupoViernes"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator40" runat="server" ControlToValidate="txtViernesMinutoTermino3" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoViernes">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtViernesHoraTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="46" Width="20px" ValidationGroup="GrupoViernes"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtViernesHoraTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoViernes">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator59" runat="server" ControlToValidate="txtViernesHoraTermino4" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoViernes">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtViernesMinutoTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="47" Width="20px" ValidationGroup="GrupoViernes"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtViernesMinutoTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoViernes">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator63" runat="server" ControlToValidate="txtViernesMinutoTermino4" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoViernes">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnViernesAH" runat="server" style="text-align: center" TabIndex="48" Text="Guardar" Width="82px" ValidationGroup="GrupoViernes" CommandName="GuardarVIERNES" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Sábado :<asp:ImageButton ID="imgbtnSabado" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtLSabadoHoraInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="28" ValidationGroup="GrupoSabado" TextMode="Number"></asp:TextBox>
                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtLSabadoHoraInicio1" Display="Dynamic" ErrorMessage="Inserte HORA DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoSabado">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator47" runat="server" ControlToValidate="txtLSabadoHoraInicio1" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoSabado">*</asp:RangeValidator>
                                                :
                                            <asp:TextBox ID="txtSabadoMinutoInicio1" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="50" ValidationGroup="GrupoSabado"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtSabadoMinutoInicio1" Display="Dynamic" ErrorMessage="Inserte MINUTO DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoSabado">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator50" runat="server" ControlToValidate="txtSabadoMinutoInicio1" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoSabado">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtSabadoHoraTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="51" ValidationGroup="GrupoSabado"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator53" runat="server" ControlToValidate="txtSabadoHoraTermino2" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoSabado">*</asp:RangeValidator>
                                                &nbsp;:
                                                <asp:TextBox ID="txtSabadoMinutoTermino2" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="52" ValidationGroup="GrupoSabado"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator56" runat="server" ControlToValidate="txtSabadoMinutoTermino2" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoSabado">*</asp:RangeValidator>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtLSabadoHoraInicio3" runat="server" Height="16px" MaxLength="2" TabIndex="53" Width="20px" ValidationGroup="GrupoSabado"></asp:TextBox>
                                                &nbsp;<asp:RangeValidator ID="RangeValidator44" runat="server" ControlToValidate="txtLSabadoHoraInicio3" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoSabado">*</asp:RangeValidator>
                                                :
                                                <asp:TextBox ID="txtSabadoMinuTermino3" runat="server" Height="16px" MaxLength="2" TabIndex="54" Width="20px" ValidationGroup="GrupoSabado"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator41" runat="server" ControlToValidate="txtSabadoMinuTermino3" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoSabado">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtSabadoHoraTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="55" Width="20px" ValidationGroup="GrupoSabado"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtSabadoHoraTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoSabado">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator60" runat="server" ControlToValidate="txtSabadoHoraTermino4" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoSabado">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtSabadoMinutoTermino4" runat="server" Height="16px" MaxLength="2" TabIndex="56" Width="20px" ValidationGroup="GrupoSabado"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtSabadoMinutoTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoSabado">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator64" runat="server" ControlToValidate="txtSabadoMinutoTermino4" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoSabado">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnSabadoAH" runat="server" style="text-align: center" TabIndex="57" Text="Guardar" Width="82px" ValidationGroup="GrupoSabado" CommandName="GuardarSABADO" />
                                            </td>
                                         </tr> 
                                    </table> 

                                </asp:View>
                                <%-- MODIFICAR HORARIO DE ATENCIÓN --%>
                                <asp:View ID="View7" runat="server">
                                    <h2>Modificar horario de atención</h2>
                                    <br />

                                    &nbsp;
                                    <asp:Label ID="Label41" runat="server" Text="Label">Asignar Especialidad :</asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlAsignarEspecialidad_MH" runat="server" TabIndex="1" AutoPostBack="True">
                                         <asp:ListItem Text = "--Seleccione Especialidad--" Value = ""></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <br />
&nbsp;
                                    <asp:Label ID="Label42" runat="server" Text="Label">Asignar Profesional :</asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                    <asp:DropDownList ID="ddlAsignarProfesional_MH" runat="server" TabIndex="2" AutoPostBack="True">
                               <asp:ListItem Text="--Seleccione un profesional de la salud--" Value=""></asp:ListItem>
                                      </asp:DropDownList>
                                     <asp:Button ID="btnCargarProfesional_MH" runat="server" Text="Buscar" />
                                    <br />
                                    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ForeColor="Red" />
                                    <br />
                                    <table border="1" >
                                         <tr><td class="auto-style4"></td> <td class="auto-style35">Hora Inicio<br /> (hora:minuto)</td> <td class="auto-style35">Hora Término<br /> (hora:minuto)</td> <td class="auto-style35">Hora Inicio<br /> (hora:minuto)</td>
                                             <td class="auto-style35">Hora Término<br /> (hora:minuto)</td>
                                             <td class="auto-style35">Asignar</td>
                                         </tr>
                                        <tr><td class="auto-style30">Lunes :<asp:ImageButton ID="imgbtnLunes0" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtLunesHoraInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="2" CausesValidation="True" ValidationGroup="GrupoLUNES"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtLunesHoraInicio1" Display="Dynamic" ErrorMessage="Inserte HORA DE INICIO de dia LUNES" ForeColor="Red" ValidationGroup="GrupoLUNES">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txtLunesHoraInicio1" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                            &nbsp;:
                                            <asp:TextBox ID="txtLunesMinutoInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="4" ValidationGroup="GrupoLUNES"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLunesMinutoInicio1" ErrorMessage="Inserte MINUTO DE INICIO de dia MARTES" ForeColor="Red" Display="Dynamic" ValidationGroup="GrupoLUNES">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator12" runat="server" ControlToValidate="txtLunesMinutoInicio1" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtLunesHoraTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="5" ValidationGroup="GrupoLUNES"></asp:TextBox>
                                                &nbsp;:
                                                <asp:TextBox ID="txtLunesMinutoTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="6" ValidationGroup="GrupoLUNES"></asp:TextBox>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="txtLunesHoraInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="2" ValidationGroup="GrupoLUNES" Width="20px"></asp:TextBox>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtLunesMinutoInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="4" ValidationGroup="GrupoLUNES" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtLunesHoraTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="5" ValidationGroup="GrupoLUNES" Width="20px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtLunesHoraTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia LUNES" ForeColor="Red" ValidationGroup="GrupoLUNES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator23" runat="server" ControlToValidate="txtLunesHoraTermino4" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtLunesMinutoTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="6" ValidationGroup="GrupoLUNES" Width="20px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtLunesMinutoTermino4" Display="Dynamic" ErrorMessage="Inserte minuno de término de dia LUNES" ForeColor="Red" ValidationGroup="GrupoLUNES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator24" runat="server" ControlToValidate="txtLunesMinutoTermino4" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="GrupoLUNES">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnModificarLUNESMH" runat="server" style="text-align: center" TabIndex="7" Text="Modificar" ValidationGroup="GrupoLUNES" Width="82px" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Martes :<asp:ImageButton ID="imgbtnMartes0" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            &nbsp;<asp:TextBox ID="txtMartesHoraInicio1_MH" runat="server" Height="16px" MaxLength="2" TabIndex="8" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtMartesHoraInicio1" Display="Dynamic" ErrorMessage="Inserte HORA DE INICIO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMARTES">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator25" runat="server" ControlToValidate="txtMartesHoraInicio1" Display="Dynamic" ErrorMessage="HORA INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            &nbsp;:
                                            <asp:TextBox ID="txtMartesMinutoInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="9" ValidationGroup="GrupoMARTES"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtMartesMinutoInicio1" ErrorMessage="Inserte MINUTO DE INICIO de dia MARTES" ForeColor="Red" Display="Dynamic" ValidationGroup="GrupoMARTES">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator26" runat="server" ControlToValidate="txtMartesMinutoInicio1" Display="Dynamic" ErrorMessage="MINUTO INICIO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="xtMartesHoraTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="10" ValidationGroup="GrupoMARTES"></asp:TextBox>
                                                &nbsp;:
                                                <asp:TextBox ID="txtMartesMinutoTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="11" ValidationGroup="GrupoMARTES"></asp:TextBox>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtMartesHoraInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="8" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                                &nbsp;:
                                                <asp:TextBox ID="txtMartesMinutoInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="9" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtMartesHoraTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="10" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtMartesHoraTermino4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMARTES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator31" runat="server" ControlToValidate="txtMartesHoraTermino4" Display="Dynamic" ErrorMessage="HORA TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="21" MinimumValue="08" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtMartesMinutoTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="11" ValidationGroup="GrupoMARTES" Width="20px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtMartesMinutoTermin4" Display="Dynamic" ErrorMessage="Inserte HORA DE TÉRMINO de dia MARTES" ForeColor="Red" ValidationGroup="GrupoMARTES">*</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator32" runat="server" ControlToValidate="txtMartesMinutoTermin4" Display="Dynamic" ErrorMessage="MINUTO TÉRMINO esta fuera del rango permitido" ForeColor="Red" MaximumValue="59" MinimumValue="00" ValidationGroup="GrupoMARTES">*</asp:RangeValidator>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnModificarMARTESMH" runat="server" style="text-align: center" TabIndex="12" Text="Modificar" ValidationGroup="GrupoMARTES" Width="82px" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Miércoles:<asp:ImageButton ID="imgbtnMiercoles0" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtMiercolesHoraInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="13"></asp:TextBox>
                                            &nbsp;:
                                            <asp:TextBox ID="txtMiercolesMinutoInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="14"></asp:TextBox>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="xtMiercolesHoraTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="15"></asp:TextBox>
                                                &nbsp;:
                                                <asp:TextBox ID="txtMiercolesMinutoTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="16"></asp:TextBox>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtMiercolesHoraInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="15" Width="20px"></asp:TextBox>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtMiercolesMinutoInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="16" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtMiercolesHoraTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="15" Width="20px"></asp:TextBox>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtMiercolesMinutoTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="16" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnModificarMIERCOLESMH" runat="server" style="text-align: center" TabIndex="17" Text="Modificar" Width="82px" ValidationGroup="GrupoMIERCOLES" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Jueves :<asp:ImageButton ID="imgbtnJueves0" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtJuevesHoraInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="18"></asp:TextBox>
                                            &nbsp;:
                                            <asp:TextBox ID="txtJuevesMinutoInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="19"></asp:TextBox>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="xtJuevessHoraTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="20"></asp:TextBox>
                                                &nbsp;:
                                                <asp:TextBox ID="txtJuevesMinutoTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="21"></asp:TextBox>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtJuevessHoraInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="20" Width="20px"></asp:TextBox>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtJuevesMinutoInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="21" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtJuevesHoraTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="20" Width="20px"></asp:TextBox>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtJuevesMinutoTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="21" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnModificarJUEVESMH" runat="server" style="text-align: center" TabIndex="22" Text="Modificar" Width="82px" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Viernes :<asp:ImageButton ID="imgbtnViernes0" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtViernesHoraInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="23"></asp:TextBox>
                                            &nbsp;:
                                            <asp:TextBox ID="txtViernesMinutoInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="24"></asp:TextBox>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="xtViernesHoraTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="25"></asp:TextBox>
                                                &nbsp;:
                                                <asp:TextBox ID="txtViernesMinutoTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="26"></asp:TextBox>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtViernesHoraInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="25" Width="20px"></asp:TextBox>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtViernesMinutoInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="26" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtViernesHoraTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="25" Width="20px"></asp:TextBox>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtViernesMinutoTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="26" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnModificarVIERNESMH" runat="server" style="text-align: center" TabIndex="27" Text="Modificar" Width="82px" />
                                            </td>
                                         </tr> 
                                        <tr><td class="auto-style30">Sábado :<asp:ImageButton ID="imgbtnSabado0" runat="server" Height="25px" ImageUrl="~/Iconos/small-green-check-mark.png" style="text-align: right" Visible="False" Width="25px" />
                                            </td> <td class="auto-style37">
                                            <asp:TextBox ID="txtSabadoHoraInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="28"></asp:TextBox>
                                            &nbsp;:
                                            <asp:TextBox ID="txtSabadoMinutoInicio1_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="29"></asp:TextBox>
                                            </td> <td class="auto-style37">
                                                <asp:TextBox ID="xtSabadoHoraTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="30"></asp:TextBox>
                                                &nbsp;:
                                                <asp:TextBox ID="txtSabadoMinutoTermino2_MH" runat="server" Height="16px" Width="20px" MaxLength="2" TabIndex="31"></asp:TextBox>
                                            </td><td class="auto-style37">
                                                <asp:TextBox ID="txtSabadoHoraInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="28" Width="20px"></asp:TextBox>
                                                &nbsp;:
                                                <asp:TextBox ID="txtSabadoMinutoInicio3_MH" runat="server" Height="16px" MaxLength="2" TabIndex="29" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:TextBox ID="txtSabadoHoraTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="30" Width="20px"></asp:TextBox>
                                                &nbsp;:&nbsp;<asp:TextBox ID="txtSabadoMinutoTermino4_MH" runat="server" Height="16px" MaxLength="2" TabIndex="31" Width="20px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style37">
                                                <asp:Button ID="btnModificarSABADOSMH" runat="server" style="text-align: center" TabIndex="32" Text="Modificar" Width="82px" />
                                            </td>
                                         </tr> 
                                    </table>
                                </asp:View>

                                <%-- View AGREGAR ESPECIALIDAD --%>
                                <asp:View ID="View8" runat="server">


                                    <div>
    
                                        <table class="auto-style1">
                                            <tr>
                                                <td class="auto-style2">&nbsp;</td>
                                                <td>
                                                    <h2>
                                                        <asp:Label ID="Label21" runat="server" Text="AGREGAR ESPECIALIDAD"></asp:Label>
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
                                                    <asp:Label ID="Label30" runat="server" Text="Nombre:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtNombre" onkeypress="return soloLetras(event)" runat="server" MaxLength="50"></asp:TextBox>
                                                    <asp:Label ID="LblErrorNombre" runat="server" ForeColor="Red"></asp:Label>
                                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="Debe el nuevo nombre" ForeColor="Red" ValidationGroup="AgrEsp">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">
                                                    <asp:Label ID="Label31" runat="server" Text="Estado:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="LblEstadoNvaEsp" runat="server" Enabled="False" Text="Habilitada"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">&nbsp;</td>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidationSummary8" runat="server" ForeColor="Red" ValidationGroup="AgrEsp" />
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
                                                    <asp:Button ID="BtnAceptarEs" runat="server" Text="Aceptar" ValidationGroup="AgrEsp" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:View>
                                <%-- View MODIFICAR NOMBRE ESPECIALIDAD --%>
                                <asp:View ID="View9" runat="server">
                                
                                <div>
    
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style2">&nbsp;</td>
                                            <td>
                                                <h2>
                                                    <asp:Label ID="Label32" runat="server" Text="MODIFICAR NOMBRE ESPECIALIDAD"></asp:Label>
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
                                                <asp:Label ID="Label33" runat="server" Text="Nombre:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownNombreEs" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3">
                                                <asp:Label ID="Label34" runat="server" Text="Nuevo Nombre:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtNuevoNombre" onkeypress="return soloLetras(event)" runat="server" MaxLength="50"></asp:TextBox>
                                                <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="TxtNuevoNombre" Display="Dynamic" ErrorMessage="Debe ingresar el nuevo nombre" ForeColor="Red" ValidationGroup="ModEs">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">&nbsp;</td>
                                            <td>
                                                <asp:ValidationSummary ID="ValidationSummary9" runat="server" ForeColor="Red" ValidationGroup="ModEs" />
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
                                                <asp:Button ID="BtnModificarNes" runat="server" Text="Modificar" ValidationGroup="ModEs" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                </asp:View>

                                <%--DESHABILITAR ESPECIALIDAD--%>
                                <asp:View ID="View10" runat="server">
                                    <div>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style2">&nbsp;</td>
                                            <td>
                                                <h2>
                                                    <asp:Label ID="Label35" runat="server" Text="DESHABILITAR ESPECIALIDAD"></asp:Label>
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
                                                <asp:Label ID="Label36" runat="server" Text="Nombre:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownTdasEsp" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                                                    <asp:ListItem>Eliga espelialidad</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3">
                                                <asp:Label ID="Label37" runat="server" Text="Estado actual:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtEstadoActual" runat="server" Enabled="False" required></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3">
                                                <asp:Label ID="Label38" runat="server" Text="Nuevo estado:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownNuevoEstado" runat="server" AutoPostBack="True">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Habilitada</asp:ListItem>
                                                    <asp:ListItem>Inhabilitada</asp:ListItem>
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
                                                <asp:Button ID="BtnModificarEs" runat="server" Text="Modificar" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
    
                                </div>
                                </asp:View>
                            </asp:MultiView>
                    </td>
                </tr>
            </table>   
</asp:Content>
