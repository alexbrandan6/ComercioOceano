<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PRESENTACION.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css"/>

    <!-- Imports css login -->
    <link rel="stylesheet" href="css/login.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="container">
                <div class="row">
                    <div class="col-12 d-flex justify-content-center">
                        <img class="usr" src="IMAGENES/imagenes/logoComercioOceano.png" alt="" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-6 p-2">
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                    </div>
                    <div class="col-6 p-2">
                        <asp:TextBox ID="txtContra" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12 p-2  d-flex justify-content-center">
                        <asp:Button ID="btnEntrar" runat="server" CssClass="btn btn-primary" Text="Entrar" OnClick="btnEntrar_Click" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-12 p-2  d-flex justify-content-center">
                        <button type="button" class="btn btn-primary" data-toggle="modal" >Crear Usuario</button>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12 p-2">
                        <div id="alertMensaje" role="alert" runat="server">
                            <strong>Atención!</strong> <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                              <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                  <span aria-hidden="true">&times;</span>
                              </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- jQuery and Bootstrap Bundle (includes Popper) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
