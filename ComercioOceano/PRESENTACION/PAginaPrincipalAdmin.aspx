<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PAginaPrincipalAdmin.aspx.cs" Inherits="PRESENTACION.PAginaPrincipalAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <link href="PaginaAdmin/StyleSheet1.css" rel="stylesheet" />
            <link href="StyleSheet1.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
    <style type="text/css">
        #MenuPrincipal{
            width: 100%;
            height: 50px;
            color: black;
        }
        #MenuPrincipal table tr td{
            text-align: center;
        }
        #MenuPrincipal table tr td a{
            text-decoration: none;
        }
        .style-tablaenblanco {
            width: 137px;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 24px;
        }
        .auto-style3 {
            height: 25px;
        }
        .auto-style19 {
            height: 24px;
            width: 187px;
        }
        .auto-style15 {
            width: 100%;
        }
        .auto-style23 {
            width: 309px;
            height: 75px;
        }
        .auto-style25 {
            width: 100%;
            height: 25px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
            <table class="auto-style25">
                <tr>
                    <td class="auto-style23">
                        <asp:LinkButton ID="lkbArticulos" runat="server" OnClick="lkbArticulos_Click">Articulos</asp:LinkButton>
                    </td>
                    <td class="style-tablaenblanco">
                        <asp:LinkButton ID="lkbProveedores" runat="server" OnClick="lkbProveedores_Click1">Proveedores</asp:LinkButton>
                    </td>
                    <td class="style-tablaenblanco">
                        <asp:LinkButton ID="lkbCategorias" runat="server" OnClick="lkbCategorias_Click1">Categorias</asp:LinkButton>
                    </td>
                    <td class="style-tablaenblanco">
                        <asp:LinkButton ID="lkbUsuarios" runat="server" OnClick="lkbUsuarios_Click1">Usuarios</asp:LinkButton>
                    </td>
                    <td class="style-tablaenblanco">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Ver perfil</asp:LinkButton>
                    </td>
                    <td class="style-tablaenblanco">
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Salir</asp:LinkButton>
                    </td>
                </tr>
            </table>
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3" colspan="2">
                        <table class="auto-style1">
                            <tr>
                                <td>
                                    <asp:Label ID="lblAdmin" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <asp:LinkButton ID="LinkButton2" runat="server">Ver perfil</asp:LinkButton>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
            <table class="auto-style15">
                <tr>
                    <td>Articulo <asp:TextBox ID="txtNombreArticulo" runat="server"></asp:TextBox>
                    </td>
                    <td>Categorias
                        <asp:DropDownList ID="ddlCategorias" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>Precio <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                
            </table>
            <link href="StyleSheet1.css" rel="stylesheet" />
            <br />            
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="grid_Articulos" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowEditing="grid_Articulos_RowEditing" OnRowCancelingEdit="grid_Articulos_RowCancelingEdit" OnRowDeleting="grid_Articulos_RowDeleting" OnRowUpdating="grid_Articulos_RowUpdating" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                            <Columns>
                                <asp:TemplateField HeaderText="Id">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbl_eit_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripcion">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Descripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Descripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Stock">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Stock" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Stock" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio Compra">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_PrecioCompra" runat="server" Text='<%# Bind("PrecioCompra") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_PrecioCompra" runat="server" Text='<%# Bind("PrecioCompra") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio Venta">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_PrecioVenta" runat="server" Text='<%# Bind("PrecioVenta") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_PrecioVenta" runat="server" Text='<%# Bind("PrecioVenta") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Proveedor">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_eit_Proveedor" runat="server" DataSourceID="dsProveedores" DataTextField="DescripcionP" DataValueField="Id">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="dsProveedores" runat="server" ConnectionString="<%$ ConnectionStrings:ComercioOceanoConnectionString2 %>" SelectCommand="SELECT [Id], [DescripcionP] FROM [Proveedores]"></asp:SqlDataSource>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Proveedor" runat="server" Text='<%# Bind("Proveedor") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Vencimiento">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_FechaVencimiento" runat="server" Text='<%# Bind("FechaVencimiento") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_FechaVencimiento" runat="server" Text='<%# Bind("FechaVencimiento") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Categoria">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_eit_Categoria" runat="server" DataSourceID="TablaCategorias" DataTextField="DescripcionC" DataValueField="ID">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="TablaCategorias" runat="server" ConnectionString="<%$ ConnectionStrings:ComercioOceanoConnectionString %>" SelectCommand="SELECT [DescripcionC], [ID] FROM [Categorias]"></asp:SqlDataSource>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Categoria" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Imagen Url">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_ImagenUrl" runat="server" Text='<%# Bind("ImagenUrl") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_ImagenUrl" runat="server" Text='<%# Bind("ImagenUrl") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Estado" runat="server" Text='<%# Bind("Estado") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Estado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
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
        </div>
    </form>
</body>
</html>
