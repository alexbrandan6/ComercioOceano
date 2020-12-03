<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="PRESENTACION.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina Principal</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link href="../css/header.css" rel="stylesheet" />
    <link href="../css/footer.css" rel="stylesheet" />
    <link href="../css/table.css" rel="stylesheet" />
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
                <asp:Button ID="btnLogin" Text="Loguearse" runat="server" CssClass="btn btn-primary" OnClick="btnLogin_Click"/>
                <button class="btn btn-primary">Carrito <i class="fa fa-shopping-cart"></i></button>
                <button type="button" class="btn btn-primary" style="display: none;" data-toggle="modal" data-target="#modalPerfil">Perfil</button>
                <a ID="btnSalir" class="btn btn-danger" style="display: none;"><i style="font-size:24px; padding-top: 10px;" class="fa">&#xf011;</i></a>
            </div>
        </div>

        <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-sm-12">
                    <table id="tblArticulos" class="table table-hover">
                        <tbody class="searchable">
                            <asp:Repeater ID="rpArticulos" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="usr">
                                            <asp:Label ID="ldlDescripcion" runat="server" Text='<%#Bind("Descripcion")%>'></asp:Label>
                                            <br />
                                            $
                                            <asp:Label ID="lblPrecioVenta" runat="server" Text='<%#Bind("PrecioVenta")%>'></asp:Label>
                                        </td>
                                        <td class="img">
                                            <asp:Image ImageUrl='<%# Eval("ImagenUrl") %>' runat="server" style="float: left;
                                                width:  200px;
                                                height: 200px;
                                                object-fit: cover;"/>
                                        </td>
                                        <td>
                                            <asp:Button CssClass="btn btn-success" Text="Al Carrito" runat="server" style="position: relative; top: 70px;" />
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
</body>
</html>