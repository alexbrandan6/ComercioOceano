<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMProveedores.aspx.cs" Inherits="PRESENTACION.ABMProveedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proveedores</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link href="../css/header.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="btn-group" role="group" aria-label="Basic example">
                <asp:Button ID="btnArticulos" Text="Articulos" runat="server" CssClass="btn btn-primary" OnClick="btnArticulos_Click" />
                <asp:Button ID="btnProveedores" Text="Proveedores" runat="server" CssClass="btn btn-primary" OnClick="btnProveedores_Click" />
                <asp:Button ID="btnCategorias" Text="Categorias" runat="server" CssClass="btn btn-primary" OnClick="btnCategorias_Click" />
                <asp:Button ID="btnUsuarios" Text="Usuarios" runat="server" CssClass="btn btn-primary" OnClick="btnUsuarios_Click" />
                <asp:Button ID="btnPerfil" Text="Ver Perfil" runat="server" CssClass="btn btn-primary" OnClick="btnPerfil_Click" />
                <asp:Button ID="btnSalir" Text="Salir" runat="server" CssClass="btn btn-danger"/>
            </div>
        </div>
    <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Dirección</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="allownumericwithoutdecimal form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Mail</label>
                    <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Estado</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Value="True">Activo</asp:ListItem>
                        <asp:ListItem>Inactivo</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <br />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-outline-success pull-right" OnCLick="btnAgregar_Click" />
                    &nbsp
                    <button id="btnVolver" type="button" class="btn btn-outline-secondary" onclick="Cancelar()">Volver</button>
                    &nbsp
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger pull-right" OnClick="btnEliminar_Click"/>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12 d-flex justify-content-center">
                    <br />
                    <asp:Label id="lblMensaje" role="alert" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>

    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="js/scripts.js"></script>
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
</body>
</html>

<script>
    function Cancelar() {
        window.location = "PAginaPrincipalAdmin.aspx";
    }
</script>
