<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PAginaPrincipalAdmin.aspx.cs" Inherits="PRESENTACION.PAginaPrincipalAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina Principal</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link href="../css/header.css" rel="stylesheet" />
    <link href="../css/footer.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
    <!-- Imports Dialog alert -->
    <link rel="stylesheet" href="css/jquery-dialog-alerts.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="btn-group" role="group">
                <asp:Button ID="btnArticulos" Text="Articulos" runat="server" CssClass="btn btn-primary" OnClick="btnArticulos_Click" />
                <asp:Button ID="btnProveedores" Text="Proveedores" runat="server" CssClass="btn btn-primary" OnClick="btnProveedores_Click" />
                <asp:Button ID="btnCategorias" Text="Categorias" runat="server" CssClass="btn btn-primary" OnClick="btnCategorias_Click" />
                <asp:Button ID="btnUsuarios" Text="Usuarios" runat="server" CssClass="btn btn-primary" OnClick="btnUsuarios_Click" />
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalPerfil">Perfil</button>
                <a ID="btnSalir" class="btn btn-danger"><i style="font-size:24px; padding-top: 10px;" class="fa">&#xf011;</i></a>
            </div>
        </div>

        <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-lg-12 p-3">
                    <p>
                        <button class="btn btn-dark" type="button" data-toggle="collapse" data-target="#cllArticulos">
                            Articulos
                        </button>
                    </p>
                    <div class="collapse" id="cllArticulos">
                        <div class="card card-body">
                            <table id="tblArticulos" class="table table-hover table-bordered" style="background-color: aliceblue;">
                                <thead>
                                    <tr>
                                        <th scope="col">Id</th>
                                        <th scope="col">Descripción</th>
                                        <th scope="col">Estado</th>
                                    </tr>
                                </thead>
                                <tbody class="searchable" style="cursor: pointer">
                                    <asp:Repeater ID="rpArticulos" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="id">
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                </td>
                                                <td class="usr">
                                                    <asp:Label ID="ldlDescripcion" runat="server" Text='<%#Bind("Descripcion")%>'></asp:Label>
                                                </td>
                                                <td class="est">
                                                    <asp:Label ID="lblEstado" runat="server" Text='<%#Bind("Estado")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12 p-3">
                    <p>
                        <button class="btn btn-dark" type="button" data-toggle="collapse" data-target="#dllProveedores">
                            Proveedores
                        </button>
                    </p>
                    <div class="collapse" id="dllProveedores">
                        <div class="card card-body">
                            <table id="tblProveedores" class="table table-hover table-bordered" style="background-color: aliceblue;">
                                <thead>
                                    <tr>
                                        <th scope="col">Id</th>
                                        <th scope="col">Descripción</th>
                                        <th scope="col">Estado</th>
                                    </tr>
                                </thead>
                                <tbody class="searchable" style="cursor: pointer">
                                    <asp:Repeater ID="rpProveedores" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="id">
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                </td>
                                                <td class="usr">
                                                    <asp:Label ID="ldlDescripcion" runat="server" Text='<%#Bind("DescripcionP")%>'></asp:Label>
                                                </td>
                                                <td class="est">
                                                    <asp:Label ID="lblEstado" runat="server" Text='<%#Bind("Estado")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12 p-3">
                    <p>
                        <button class="btn btn-dark" type="button" data-toggle="collapse" data-target="#cllCategorias" aria-expanded="false" aria-controls="collapseExample">
                            Categorias
                        </button>
                    </p>
                    <div class="collapse" id="cllCategorias">
                        <div class="card card-body">
                            <table id="tblCategorias" class="table table-hover table-bordered" style="background-color: aliceblue;">
                                <thead>
                                    <tr>
                                        <th scope="col">Id</th>
                                        <th scope="col">Descripción</th>
                                        <th scope="col">Estado</th>
                                    </tr>
                                </thead>
                                <tbody class="searchable" style="cursor: pointer">
                                    <asp:Repeater ID="rpCategorias" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="id">
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                </td>
                                                <td class="usr">
                                                    <asp:Label ID="ldlDescripcion" runat="server" Text='<%#Bind("DescripcionC")%>'></asp:Label>
                                                </td>
                                                <td class="est">
                                                    <asp:Label ID="lblEstado" runat="server" Text='<%#Bind("Estado")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12 p-3">
                    <p>
                        <button class="btn btn-dark" type="button" data-toggle="collapse" data-target="#cllUsuarios" aria-expanded="false" aria-controls="collapseExample">
                            Usuarios
                        </button>
                    </p>
                    <div class="collapse" id="cllUsuarios">
                        <div class="card card-body">
                            <table id="tblUsuarios" class="table table-hover table-bordered" style="background-color: aliceblue;">
                                <thead>
                                    <tr>
                                        <th scope="col">Id</th>
                                        <th scope="col">Nombre de usuario</th>
                                        <th scope="col">Apellidos</th>
                                        <th scope="col">Nombres</th>
                                        <th scope="col">Estado</th>
                                    </tr>
                                </thead>
                                <tbody class="searchable" style="cursor: pointer">
                                    <asp:Repeater ID="rpUsuarios" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="id">
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                </td>
                                                <td class="usr">
                                                    <asp:Label ID="ldlDescripcion" runat="server" Text='<%#Bind("NombreUsuario")%>'></asp:Label>
                                                </td>
                                                <td class="ape">
                                                    <asp:Label ID="lblEstado" runat="server" Text='<%#Bind("Apellidos")%>'></asp:Label>
                                                </td>
                                                <td class="nom">
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("Nombres")%>'></asp:Label>
                                                </td>
                                                <td class="est">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Bind("Estado")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="modalPerfil" class="modal" tabindex="-1">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Perfil</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label class="control-label">Nombre de usuario</label>
                                    <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label class="control-label">Contraseña</label>
                                    <asp:TextBox ID="txtContra" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-success">Guardar</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div id="myConfirm"></div>
    <footer class="footer-distributed">

        <div class="footer-left">
            <p class="footer-company-name">© 2020 Alex Brandan</p>
        </div>

        <div class="footer-center">
            <div>
                <i class="fa fa-map-marker"></i>
                <p>
                    <span>Buenos Aires</span>
                    Argentina
                </p>
            </div>

            <div>
                <i class="fa fa-phone"></i>
                <p>+54 123456789</p>
            </div>
            <div>
                <i class="fa fa-envelope"></i>
                <p><a href="mailto:alexbrandan6@gmail.com">alexbrandan6@gmail.com</a></p>
            </div>
        </div>
        <div class="footer-right">
            <p class="footer-company-about">
                <span>Sobre mí</span>
                Aca escribo algo sobre mi.
            </p>
            <div class="footer-icons">
                <a href="https://www.instagram.com/alex_brandan6/">Instagram</a>
                <a href="https://www.linkedin.com/in/alexbrandan06/">LinkedIn</a>
            </div>
        </div>
    </footer>
    
    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="js/scripts.js"></script>
    <script src="js/jquery-dialog-alerts.js"></script>
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
    <script src="//cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>

</body>
</html>

<script>
    $(document).ready(function () {
        $('#tblArticulos').dataTable({
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
            columnDefs: [{
                orderable: false,
                className: 'select-checkbox',
                targets: 0
            }],
            select: {
                style: 'multi',
                selector: 'td:first-child'
            }
        });

        $('#tblCategorias').dataTable({
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
            columnDefs: [{
                orderable: false,
                className: 'select-checkbox',
                targets: 0
            }],
            select: {
                style: 'multi',
                selector: 'td:first-child'
            }
        });

        $('#tblProveedores').dataTable({
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
            columnDefs: [{
                orderable: false,
                className: 'select-checkbox',
                targets: 0
            }],
            select: {
                style: 'multi',
                selector: 'td:first-child'
            }
        });

        $('#tblUsuarios').dataTable({
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
            columnDefs: [{
                orderable: false,
                className: 'select-checkbox',
                targets: 0
            }],
            select: {
                style: 'multi',
                selector: 'td:first-child'
            }
        });

        $('#cllArticulos').collapse('show');
    });

    $("#tblArticulos tbody tr").click(function () {
        var id = $('.id', this).html().trim();
        id = removeLabel(id, '>', '<');
        window.location = 'ABMArticulos.aspx?idArticulo=' + id;
    });

    $("#tblCategorias tbody tr").click(function () {
        var id = $('.id', this).html().trim();
        id = removeLabel(id, '>', '<');
        window.location = 'ABMCategorias.aspx?idCategoria=' + id;
    });

    $("#tblProveedores tbody tr").click(function () {
        var id = $('.id', this).html().trim();
        id = removeLabel(id, '>', '<');
        window.location = 'ABMProveedores.aspx?idProveedor=' + id;
    });

    $("#tblUsuarios tbody tr").click(function () {
        var id = $('.id', this).html().trim();
        id = removeLabel(id, '>', '<');
        window.location = 'ABMUsuarios.aspx?idUsuario=' + id;
    });

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
</script>
