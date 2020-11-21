﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PAginaPrincipalAdmin.aspx.cs" Inherits="PRESENTACION.PAginaPrincipalAdmin" %>

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

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="btn-group" role="group">
                <asp:Button ID="btnArticulos" Text="Articulos" runat="server" CssClass="btn btn-primary" OnClick="btnArticulos_Click" />
                <asp:Button ID="btnProveedores" Text="Proveedores" runat="server" CssClass="btn btn-primary" OnClick="btnProveedores_Click" />
                <asp:Button ID="btnCategorias" Text="Categorias" runat="server" CssClass="btn btn-primary" OnClick="btnCategorias_Click" />
                <asp:Button ID="btnUsuarios" Text="Usuarios" runat="server" CssClass="btn btn-primary" OnClick="btnUsuarios_Click" />
                <asp:Button ID="btnPerfil" Text="Ver Perfil" runat="server" CssClass="btn btn-primary" OnClick="btnPerfil_Click" />
                <asp:Button ID="btnSalir" Text="Salir" runat="server" CssClass="btn btn-danger" OnClick="btnSalir_Click" />
            </div>
        </div>

        <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-lg-12">
                    <table id="tblArticulos" class="table table-hover table-bordered" style="background-color: aliceblue;">
                        <thead>
                            <tr>
                                <th scope="col">Id</th>
                                <th scope="col">Descripción</th>
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
    </form>

    <footer class="footer-distributed">

        <div class="footer-left">
            <img src="IMAGENES/imagenes/logoComercioOceano.png">
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
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
    <script src="//cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>

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
    });

    $("#tblArticulos tbody tr").click(function () {
        var id = $('.id', this).html().trim();
        id = removeLabel(id, '>', '<');
        window.location = 'ABMArticulos.aspx?idArticulo=' + id;
    });

</script>
