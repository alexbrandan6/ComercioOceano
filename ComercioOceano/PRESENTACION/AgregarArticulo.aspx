<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="PRESENTACION.PaginaAdmin.AgregarArticulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agregar Articulo</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link href="../css/header.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="btn-group" role="group" aria-label="Basic example">
                <asp:Button ID="btnPaginaPrincipal" Text="Pagina Principal" runat="server" CssClass="btn btn-primary" OnClick="btnPaginaPrincipal_Click" />
                <asp:Button ID="btnPaginaProveedores" Text="Proveedores" runat="server" CssClass="btn btn-primary" OnClick="btnPaginaProveedores_Click"/>
                <asp:Button ID="btnPaginaUsuarios" Text="Usuarios" runat="server" CssClass="btn btn-primary" OnClick="btnPaginaUsuarios_Click"/>

                <asp:Label ID="lblAdmin" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
        <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Descripción</label>
                    <asp:TextBox ID="txt_Descripcion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Stock</label>
                    <asp:TextBox ID="txt_Stock" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Precio de compra</label>
                    <asp:TextBox ID="txt_PrecioCompra" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Precio de venta</label>
                    <asp:TextBox ID="txt_PrecioVenta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Proveedor</label>
                    <asp:DropDownList ID="ddl_Proveedor" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Fecha de vencimiento</label>
                    <asp:TextBox ID="txt_Fecha" runat="server" MaxLength="10" placeholder="DD/MM/YYYY" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Categoria</label>
                    <asp:DropDownList ID="ddl_Categoria" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Url de la imagen</label>
                    <asp:TextBox ID="txt_ImagenUrl" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Estado</label>
                    <asp:DropDownList ID="ddl_Estado" runat="server" CssClass="form-control">
                        <asp:ListItem Value="True">Activo</asp:ListItem>
                        <asp:ListItem>Inactivo</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <br />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-outline-success pull-right"  />
                    &nbsp
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-outline-danger pull-right" />
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12 d-flex justify-content-center">
                    <br />
                    <asp:Label id="lbl_Mensaje" role="alert" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
