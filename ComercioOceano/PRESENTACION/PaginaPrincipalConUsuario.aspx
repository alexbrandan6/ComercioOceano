<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipalConUsuario.aspx.cs" Inherits="PRESENTACION.PaginaPrincipalConUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Comercio Oceano</title>
    <link href="plantilla.css" rel="stylesheet" />
   
    <style type="text/css">
        .auto-style1 {
            width: 251px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <img src="IMAGENES/imagenes/fondoPagina.jpg" id="fondoPagina"/>
<div class="wrapper">
    <div id="cabeza">
		<img src="IMAGENES/imagenes/barraBusqueda.png" id="logoBarraBusqueda" />
		<img src="IMAGENES/imagenes/logoCarrito.png" id="logoCarrito"/>
		<img src="IMAGENES/imagenes/logoUsuario.png" id="logoUsuario"/>
		<img src="IMAGENES/imagenes/logoComercioOceano.png" id="logoComercioOceano"/>
	</div>
     <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                      <asp:ListView ID="lvArticulos" runat="server" DataKeyNames="ID" GroupItemCount="5">
               
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
                        <asp:Button ID="btnAgregar" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="eventoAgregar" Text="Agregar" />
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
                        <asp:Button ID="btnAgregar" runat="server" CommandArgument='<%# Eval("ID")%>' CommandName="eventoAgregar"  Text="Agregar" />
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
            </asp:ListView>
            <div class="push"></div>
       </div>
       <div class="footer">
       <div id="pie">
        <img src="IMAGENES/imagenes/instagramLogo.png" id="instagramLogo"/>
		<img src="IMAGENES/imagenes/facebookLogo.png" id="facebookLogo"/>
		</div>
       </div>
    </form>
</body>
</html>
