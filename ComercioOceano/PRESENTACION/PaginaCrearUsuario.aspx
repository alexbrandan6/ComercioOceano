<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaCrearUsuario.aspx.cs" Inherits="PRESENTACION.PaginaCrearUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
    <style type="text/css">
        #MenuPrincipal{
            width: 100%;
            height: 100px;
            color: black;
        }
        #MenuPrincipal table tr td{
            text-align: center;
        }
        #MenuPrincipal table tr td a{
            text-decoration: none;
        }
        .tablacabecera {
            width: 100%;
        }
        .style-tablaenblanco {
            width: 137px;
        }
        .auto-style1 {
            width: 100%;
            height: 144px;
        }
        .auto-style3 {
            width: 280px;
        }
        .auto-style4 {
            width: 100%;
        }
        .auto-style7 {
            width: 310px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
        }
        .auto-style9 {
            width: 113px;
        }
        .auto-style10 {
            width: 310px;
        }
        .auto-style11 {
            margin-top: 3px;
        }
        .auto-style12 {
            height: 74px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="MenuPrincipal" class="auto-style12">
            <table class="tablacabecera">
                <tr>
                    <td >
                        <asp:LinkButton ID="lkbPaginaPrincipal" runat="server" OnClick="lkbPaginaPrincipal_Click">Pagina Principal</asp:LinkButton>
                    </td>
                    <td class="style-tablaenblanco" >&nbsp;</td>
                    <td class="style-tablaenblanco" ></td>
                    <td class="style-tablaenblanco" ></td>
                    <td class="style-tablaenblanco" ></td>
                    <td class="style-tablaenblanco" >&nbsp;</td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Strikeout="False" Font-Underline="True" Text="Datos personales"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Apellidos</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtApellidos" runat="server" Width="202px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Nombres</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtNombres" runat="server" Width="203px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Fecha de nacimiento</td>
                    <td class="auto-style3">Dia:
                        <asp:TextBox ID="txtDia" runat="server" Width="43px"></asp:TextBox>
&nbsp; Mes:
                        <asp:TextBox ID="txtMes" runat="server" Width="43px"></asp:TextBox>
&nbsp; Año:<asp:TextBox ID="txtAnio" runat="server" Width="49px"></asp:TextBox>
&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Genero</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlGenero" runat="server" Width="49px">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Telefono</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtTelefono" runat="server" Width="193px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Dirección</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDireccion" runat="server" Width="194px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Strikeout="False" Font-Underline="True" Text="Datos de la cuenta"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblMail" runat="server" Text="Mail"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtMail" runat="server" Width="278px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" Width="278px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="lblContrasenia" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContra" runat="server" Width="278px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" Width="90px" CssClass="auto-style11" Height="30px" />
            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" Height="30px" OnClick="btnCancelar_Click" Text="Cancelar" Width="90px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblError" runat="server" BackColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
