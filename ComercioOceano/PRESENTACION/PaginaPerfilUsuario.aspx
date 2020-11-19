<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPerfilUsuario.aspx.cs" Inherits="PRESENTACION.PaginaPerfilUsuario" %>

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
        .auto-style3 {
            width: 280px;
        }
        .auto-style4 {
            width: 100%;
            height: 113px;
        }
        .auto-style7 {
            width: 296px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
        }
        .auto-style9 {
            width: 124px;
            height: 24px;
        }
        .auto-style10 {
            width: 280px;
            height: 24px;
        }
        .auto-style12 {
            width: 124px;
            height: 25px;
        }
        .auto-style13 {
            width: 280px;
            height: 25px;
        }
        .auto-style14 {
            width: 124px;
        }
        .auto-style15 {
            width: 296px;
        }
        .auto-style16 {
            width: 124px;
            height: 23px;
        }
        .auto-style17 {
            width: 280px;
            height: 23px;
        }
        .auto-style18 {
            width: 100%;
            height: 47px;
        }
        .auto-style19 {
            height: 45px;
        }
        .auto-style20 {
            height: 45px;
            width: 160px;
        }
        .auto-style22 {
            width: 133px;
        }
        .auto-style23 {
            width: 296px;
            height: 29px;
        }
        .auto-style24 {
            height: 29px;
        }
        .auto-style25 {
            width: 296px;
            height: 24px;
        }
        .auto-style26 {
            height: 24px;
        }
    </style>
</head>
<body style="height: 557px">
    <form id="form1" runat="server">
            <table class="tablacabecera">
                <tr>
                    <td class="auto-style22" >
                        <asp:LinkButton ID="lkbPaginaPrincipal" runat="server" OnClick="lkbPaginaPrincipal_Click">Pagina Principal</asp:LinkButton>
                    </td>
                    <td class="style-tablaenblanco">
                        <asp:LinkButton ID="lkbCarrito" runat="server" OnClick="lkbCarrito_Click">Carrito</asp:LinkButton>
                    </td>
                    <td class="style-tablaenblanco" ></td>
                    <td class="style-tablaenblanco" ></td>
                    <td class="style-tablaenblanco" >&nbsp;</td>
                    <td class="style-tablaenblanco" >&nbsp;</td>
                </tr>
            </table>
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="lblDatosPersonales" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Strikeout="False" Font-Underline="True" Text="Datos personales"></asp:Label>
                    </td>
                    <td class="auto-style17"></td>
                </tr>
                <tr>
                    <td class="auto-style16">Apellidos</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="txtApellidos" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">Nombres</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtNombres" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">Fecha de nacimiento</td>
                    <td class="auto-style3">Dia
                        <asp:TextBox ID="txtDia" runat="server" Width="34px"></asp:TextBox>
&nbsp;Mes
                        <asp:TextBox ID="txtMes" runat="server" Width="34px"></asp:TextBox>
&nbsp;Año
                        <asp:TextBox ID="txtAnio" runat="server" Width="34px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Genero</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtGenero" runat="server" Width="34px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">Telefono</td>
                    <td class="auto-style13">
                        <asp:TextBox ID="txtTelefono" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">Dirección</td>
                    <td class="auto-style13">
                        <asp:TextBox ID="txtDireccion" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style25">
                        <asp:Label ID="lblDatosCuenta" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Strikeout="False" Font-Underline="True" Text="Datos de la cuenta"></asp:Label>
                    </td>
                    <td class="auto-style26"></td>
                </tr>
                <tr>
                    <td class="auto-style7">Mail</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtMail" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">Nombre de usuario</td>
                    <td>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style23">Contraseña</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="txtContra" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
            </table>
                        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnModificar" runat="server" Text="Agregar cambios" OnClick="btnModificar_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Strikeout="False" Font-Underline="True" Text="Compras"></asp:Label>
            <br />
            <asp:GridView ID="grid_Compras" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:TemplateField HeaderText="Fecha Venta">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("fechaVenta") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Articulo">
                        <ItemTemplate>
                            <asp:Label ID="lblArt" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Label ID="lblCant" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("PrecioArticulo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sub Total">
                        <ItemTemplate>
                            <asp:Label ID="lblSubTotal" runat="server" Text='<%# Bind("SubTotal") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <br />
            <table class="auto-style18">
                <tr>
                    <td class="auto-style20">
                        &nbsp;</td>
                    <td class="auto-style19">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
