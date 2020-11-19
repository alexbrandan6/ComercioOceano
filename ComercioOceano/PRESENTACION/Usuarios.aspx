<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PRESENTACION.PaginaAdmin.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../StyleSheet1.css" rel="stylesheet" />
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
        }
        .auto-style2 {
            width: 159px;
        }
    </style>
</head>
<link href="StyleSheet1.css" rel="stylesheet" />
<body>
    <form id="form1" runat="server">
        <table class="tablacabecera">
                <tr>
                    <td class="auto-style8">
                        <asp:LinkButton ID="lkbPaginaPrincipal" runat="server" OnClick="lkbPaginaPrincipal_Click">Pagina Principal</asp:LinkButton>
                    </td>
                    <td class="auto-style9">
                        <asp:LinkButton ID="lkbArticulos" runat="server" OnClick="lkbArticulos_Click">Articulos</asp:LinkButton>
                    </td>
                    <td class="auto-style9">
                        <asp:LinkButton ID="lkbProveedores" runat="server" OnClick="lkbProveedores_Click">Proveedores</asp:LinkButton>
                    </td>
                    <td class="auto-style9">
                    </td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9">
                        <asp:Label ID="lblAdmin" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        <div>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Apellido:</td>
                    <td>
                        <asp:TextBox ID="txtApellidoBuscar" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Nombre:</td>
                    <td>
                        <asp:TextBox ID="txtNombreBuscar" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Nombre de Usuario:</td>
                    <td>
                        <asp:TextBox ID="txtNombreUsuarioBuscar" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Ordenar alfabeticamente:</td>
                    <td>
                        <asp:CheckBox ID="chbAlfabetico" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="Button1" runat="server" Text="Buscar" Width="66px" OnClick="Button1_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="grid_Usuarios" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="grid_Usuarios_RowCancelingEdit" OnRowEditing="grid_Usuarios_RowEditing" OnRowUpdating="grid_Usuarios_RowUpdating" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombres">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Nombres" runat="server" Text='<%# Bind("Nombres") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nombres" runat="server" Text='<%# Bind("Nombres") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellidos">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Apellidos" runat="server" Text='<%# Bind("Apellidos") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Apellidos" runat="server" Text='<%# Bind("Apellidos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Nacimiento">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_FechaNacimiento" runat="server" CssClass="auto-style3" Text='<%# Bind("fechaNac") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_FechaNacimiento" runat="server" Text='<%# Bind("fechaNac") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Genero">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Genero" runat="server" SelectedValue='<%# Bind("Genero") %>'>
                                <asp:ListItem>F</asp:ListItem>
                                <asp:ListItem>M</asp:ListItem>
                                <asp:ListItem>O</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Genero" runat="server" Text='<%# Bind("Genero") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mail">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Mail" runat="server" CssClass="auto-style3" Text='<%# Bind("Mail") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Mail" runat="server" Text='<%# Bind("Mail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Usuario">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_NombreUsuario" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_NombreUsuario" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contraseña">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Contraseña" runat="server" Text='<%# Bind("Contrasenia") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Contraseña" runat="server" Text='<%# Bind("Contrasenia") %>'></asp:Label>
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
        </div>
    </form>
</body>
</html>
