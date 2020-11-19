<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="PRESENTACION.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/StyleSheet1.css" type="text/css" rel="stylesheet" />    
    <style type="text/css">
        #MenuPrincipal{
            width: 100%;
            height: 100px;                     
        }
        #MenuPrincipal table tr td{
            text-align: center;     
        }
        #MenuPrincipal table tr td a{
            text-decoration: none;
            display: block;                     	        
	        border-radius: 30%;
        }
        #MenuPrincipal table tr td a:hover{
            background-color: white;
        }
        .tablacabecera {
            width: 100%;
        }
        .style-tablaenblanco {
            width: 137px;
        }
        .auto-style15 {
            width: 100%;
        }
        .auto-style24 {
            width: 134px;
        }
        .auto-style25 {
            width: 149px;
        }
        .auto-style26 {
            width: 84px;
        }
        
        .auto-style27 {
            width: 374px;
        }
        .auto-style28 {
            height: 83px;
        }
        .auto-style30 {
            width: 137px;
            height: 23px;
        }
        
        .auto-style31 {
            width: 244px;
        }
        .auto-style35 {
            width: 84px;
            height: 23px;
        }
        .auto-style36 {
            width: 96px;
            height: 23px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="MenuPrincipal" class="auto-style28">
            <table class="tablacabecera">
                <tr>
                    <td class="auto-style36" >
                        <asp:LinkButton ID="lkbRegistrarse" runat="server" OnClick="lkbRegistrarse_Click">Registrarse</asp:LinkButton>
                    </td>
                    <td class="auto-style35" >
                        <asp:LinkButton ID="lkbCarrito" runat="server" OnClick="lkbCarrito_Click">Carrito</asp:LinkButton>
                    </td>
                    <td class="auto-style30" >&nbsp;</td>
                </tr>
            </table>
            <table class="auto-style15">
                <tr>
                    <td class="auto-style24">
                        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style25">
                        <asp:TextBox ID="txtContra" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style26">
                        <asp:Button ID="btnEntrar" runat="server" OnClick="btnEntrar_Click1" Text="Entrar" />
                    </td>
                    <td class="auto-style27">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style24">Usuario</td>
                    <td class="auto-style25">Contraseña</td>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style27">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table class="auto-style15">
                <tr>
                    <td class="auto-style31">Articulo <asp:TextBox ID="txtNombreArticulo" runat="server"></asp:TextBox>
                    </td>
                    <td>Categorias
                        <asp:DropDownList ID="ddlCategorias" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>Precio 
                        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
&nbsp;
                        <asp:DropDownList ID="ddlPrecio" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem Value="=">Igual a</asp:ListItem>
                            <asp:ListItem Value="&gt;">Mayor a</asp:ListItem>
                            <asp:ListItem Value="&lt;">Menor a</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style31">&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                </table>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <link href="StyleSheet1.css" rel="stylesheet" />
            <br /><asp:ListView ID="lvArticulos" runat="server" DataKeyNames="ID" GroupItemCount="5">
               
                <EditItemTemplate>
                    <td runat="server" style="background-color: #999999;" class="auto-style28">
                        <asp:Image ID="Image1" runat="server" Height="103px" ImageUrl='<%# Bind("ImagenUrl") %>' Width="134px" />
                        <br />Descripcion:
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                        <br />Stock:
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                        <br />PrecioVenta:
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("PrecioVenta") %>'></asp:Label>
                        <br />
                        <br />
                        &nbsp;
                        <asp:Button ID="btnAgregar" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="eventoAgregar" OnCommand="btnAgregar_Command1" Text="Agregar" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No se han devuelto datos.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
<td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">Descripcion:
                        <asp:TextBox ID="DescripcionTextBox" runat="server" Text='<%# Bind("Descripcion") %>' />
                        <br />Stock:
                        <asp:TextBox ID="StockTextBox" runat="server" Text='<%# Bind("Stock") %>' />
                        <br />PrecioCompra:
                        <asp:TextBox ID="PrecioCompraTextBox" runat="server" Text='<%# Bind("PrecioCompra") %>' />
                        <br />PrecioVenta:
                        <asp:TextBox ID="PrecioVentaTextBox" runat="server" Text='<%# Bind("PrecioVenta") %>' />
                        <br />IdProveedor:
                        <asp:TextBox ID="IdProveedorTextBox" runat="server" Text='<%# Bind("IdProveedor") %>' />
                        <br />FechaVencimiento:
                        <asp:TextBox ID="FechaVencimientoTextBox" runat="server" Text='<%# Bind("FechaVencimiento") %>' />
                        <br />IdCategoria:
                        <asp:TextBox ID="IdCategoriaTextBox" runat="server" Text='<%# Bind("IdCategoria") %>' />
                        <br />ImagenUrl:
                        <asp:TextBox ID="ImagenUrlTextBox" runat="server" Text='<%# Bind("ImagenUrl") %>' />
                        <br />
                        <asp:CheckBox ID="EstadoCheckBox" runat="server" Checked='<%# Bind("Estado") %>' Text="Estado" />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: #E0FFFF;color: #333333;" class="auto-style28">
                        <asp:Image ID="Image1" runat="server" Height="103px" ImageUrl='<%# Bind("ImagenUrl") %>' Width="134px" />
                        <br />Descripcion:
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Descripcion") %>' />
                        <br />Stock:
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Stock") %>' />
                        <br />PrecioVenta:
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("PrecioVenta") %>' />
                        <br />
                        <br />&nbsp;
                        <asp:Button ID="btnAgregar" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="eventoAgregar" OnCommand="btnAgregar_Command1" Text="Agregar" />
                        <br /></td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">ID:
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                        <br />Descripcion:
                        <asp:Label ID="DescripcionLabel" runat="server" Text='<%# Eval("Descripcion") %>' />
                        <br />Stock:
                        <asp:Label ID="StockLabel" runat="server" Text='<%# Eval("Stock") %>' />
                        <br />PrecioCompra:
                        <asp:Label ID="PrecioCompraLabel" runat="server" Text='<%# Eval("PrecioCompra") %>' />
                        <br />PrecioVenta:
                        <asp:Label ID="PrecioVentaLabel" runat="server" Text='<%# Eval("PrecioVenta") %>' />
                        <br />IdProveedor:
                        <asp:Label ID="IdProveedorLabel" runat="server" Text='<%# Eval("IdProveedor") %>' />
                        <br />FechaVencimiento:
                        <asp:Label ID="FechaVencimientoLabel" runat="server" Text='<%# Eval("FechaVencimiento") %>' />
                        <br />IdCategoria:
                        <asp:Label ID="IdCategoriaLabel" runat="server" Text='<%# Eval("IdCategoria") %>' />
                        <br />ImagenUrl:
                        <asp:Label ID="ImagenUrlLabel" runat="server" Text='<%# Eval("ImagenUrl") %>' />
                        <br />
                        <asp:CheckBox ID="EstadoCheckBox" runat="server" Checked='<%# Eval("Estado") %>' Enabled="false" Text="Estado" />
                        <br /></td>
                </SelectedItemTemplate>
            </asp:ListView><br />
        </div>
    </form>
</body>
</html>
