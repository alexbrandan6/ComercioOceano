<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMUsuarios.aspx.cs" Inherits="PRESENTACION.ABMUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuarios</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link href="../css/header.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <!-- Imports Dialog alert -->
    <link rel="stylesheet" href="css/jquery-dialog-alerts.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="btn-group" role="group" aria-label="Basic example">
                <asp:Button ID="btnArticulos" Text="Articulos" runat="server" CssClass="btn btn-primary" OnClick="btnArticulos_Click" />
                <asp:Button ID="btnProveedores" Text="Proveedores" runat="server" CssClass="btn btn-primary" OnClick="btnProveedores_Click" />
                <asp:Button ID="btnCategorias" Text="Categorias" runat="server" CssClass="btn btn-primary" OnClick="btnCategorias_Click" />
                <asp:Button ID="btnUsuarios" Text="Usuarios" runat="server" CssClass="btn btn-primary" OnClick="btnUsuarios_Click" />
                
                <a ID="btnSalir" class="btn btn-danger"><i style="font-size:24px; padding-top: 10px;" class="fa">&#xf011;</i></a>
            </div>
        </div>
        <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Nombres</label>
                    <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Apellidos</label>
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Fecha de nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="10" placeholder="DD/MM/YYYY" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Genero</label>
                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
                        <asp:ListItem Value="True">Femenino</asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Otro</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Dirección</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <label class="control-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Nombre de usuario</label>
                    <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label class="control-label">Contraseña</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtContra" runat="server" CssClass="form-control" aria-describedby="btnSeePassword"></asp:TextBox>
                        <span id="btnSeePassword" class="input-group-text" role="button"><i class="fa fa-eye-slash"></i></span>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <label class="control-label">Estado</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Value="1">Activo</asp:ListItem>
                        <asp:ListItem Value="0">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <br />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-outline-success" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-outline-success" OnClick="btnActualizar_Click" />
                    <button id="btnVolver" type="button" class="btn btn-outline-secondary pull-right" onclick="Cancelar()">Volver</button>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click"/>
                </div>
            </div>
        </div>
    </form>

    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="js/scripts.js"></script>
    <script src="js/jquery-dialog-alerts.js"></script>
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>

    <div id="myConfirm"></div>
    <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label> 
</body>
</html>

<script>

    datepicker('txtFechaNacimiento');

    function Cancelar() {
        window.location = "PAginaPrincipalAdmin.aspx";
    }

    $('#btnSalir').click(function () {
        $('#myConfirm').simpleConfirm({
            message: '¿Esta seguro de querer salir?',
            success: function () {
                window.location = 'Login.aspx';
            },
            cancel: function () {

            }
        })
    })

    function SeePassword(btnSeePassword) {
        let txtPassword = document.querySelector('[id$=txtContra]');

        if (txtPassword.type === 'password') {
            txtPassword.type = 'text';
            btnSeePassword.classList.remove('fa-eye-slash');
            btnSeePassword.classList.add('fa-eye');
        }
        else {
            txtPassword.type = 'password';
            btnSeePassword.classList.add('fa-eye-slash');
            btnSeePassword.classList.remove('fa-eye');
        }
    }

    let btnSeePassword = document.querySelector('#btnSeePassword');
    btnSeePassword.addEventListener('click', () => SeePassword(btnSeePassword.children[0]));
    btnSeePassword.click();
</script>
