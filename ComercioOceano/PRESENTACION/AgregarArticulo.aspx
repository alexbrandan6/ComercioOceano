<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="PRESENTACION.PaginaAdmin.AgregarArticulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../StyleSheet1.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
             width: 100%;
             
        }
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
        .auto-style2 {
            width: 196px;
        }
        .auto-style3 {
            width: 397px;
        }
        .auto-style6 {
            width: 397px;
            height: 27px;
        }
        .auto-style7 {
            height: 27px;
        }
        .auto-style8 {
            height: 23px;
        }
        .auto-style9 {
            width: 137px;
            height: 23px;
        }
        </style>
</head>
<link href="StyleSheet1.css" rel="stylesheet" />
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tablacabecera">
                <tr>
                    <td class="auto-style8">
                        <asp:LinkButton ID="lkbPaginaPrincipal" runat="server" OnClick="lkbPaginaPrincipal_Click">Pagina Principal</asp:LinkButton>
                    </td>
                    <td class="auto-style9">
                        <asp:LinkButton ID="lkbProveedores" runat="server" OnClick="lkbProveedores_Click">Proveedores</asp:LinkButton>
                    </td>
                    <td class="auto-style9">
                        <asp:LinkButton ID="lkbUsuarios" runat="server" OnClick="lkbUsuarios_Click">Usuarios</asp:LinkButton>
                    </td>
                    <td class="auto-style9">
                    </td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9">
                        <asp:Label ID="lblAdmin" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table><br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Underline="True" Text="Agregar Articulo"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">Descripcion</td>
                    <td>
                        <asp:TextBox ID="txt_Descripcion" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Stock</td>
                    <td>
                        <asp:TextBox ID="txt_Stock" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Precio de Compra</td>
                    <td>
                        <asp:TextBox ID="txt_PrecioCompra" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Precio de Venta</td>
                    <td>
                        <asp:TextBox ID="txt_PrecioVenta" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Proveedor</td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddl_Proveedor" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Fecha de Vencimiento</td>
                    <td style="margin-left: 40px">
                        <asp:TextBox ID="txt_Fecha" runat="server" style="margin-left: 0px" MaxLength="10" placeholder="Ej. DD/MM/YYYY"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Categoria</td>
                    <td>
                        <asp:DropDownList ID="ddl_Categoria" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Imagen</td>
                    <td>
                        <asp:TextBox ID="txt_ImagenUrl" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Estado</td>
                    <td>
                        <asp:DropDownList ID="ddl_Estado" runat="server">
                            <asp:ListItem Value="True">True</asp:ListItem>
                            <asp:ListItem>False</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="txt_Agregar" runat="server" Text="Agregar" Width="71px" OnClick="txt_Agregar_Click"  />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" Width="59px" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_Mensaje" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
