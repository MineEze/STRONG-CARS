<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MenuPrincipal.aspx.cs" Inherits="UI.MenuPrincipal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container theme-showcase" role="main">
        <div class="jumbotron">
            <h2>
                <asp:Label ID="LabelBienvenido" runat="server" Text="Bienvenido"></asp:Label>
                <asp:Label ID="LabelUsuarioNombre" runat="server" Text='<%# Session["UsuarioNombre"].ToString() %>'></asp:Label>
            </h2>
            <h4>
                <asp:Label ID="LabelQueDeseasHacer" runat="server" Text="¿Que deseas hacer?"></asp:Label>
            </h4>
        </div>
    </div>

    <div class="container marketing">
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlRegistrarUsuario">
                <img class="img-circle" src="Content/images/newuser.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonRegistrarUsuario" runat="server" class="btn btn-primary" OnClick="ButtonRegistrarUsuario_Click" Text="Crear usuario" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlListarUsuarios">
                <img class="img-circle" src="Content/images/user.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonUsuarios" runat="server" class="btn btn-primary" OnClick="ButtonUsuarios_Click" Text="Usuarios existentes" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlPermisos">
                <img class="img-circle" src="Content/images/permiso.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonAgregarPermiso" runat="server" class="btn btn-primary" OnClick="ButtonAgregarPermiso_Click" Text="Permisos" />
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlAgregarSucursales">
                <img class="img-circle" src="Content/images/newsucursal.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonAgregarSucursal" runat="server" class="btn btn-primary" OnClick="ButtonAgregarSucursal_Click" Text="Agregar sucursal" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlListarSucursales">
                <img class="img-circle" src="Content/images/sucursal.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonListarSucursales" runat="server" class="btn btn-primary" OnClick="ButtonListarSucursales_Click" Text="Ver sucursales" />
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlAgregarVehiculo">
                <img class="img-circle" src="Content/images/newcar.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonAgregarVehiculo" runat="server" class="btn btn-primary" OnClick="ButtonAgregarVehiculo_Click" Text="Agregar vehículo" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlListarVehiculos">
                <img class="img-circle" src="Content/images/vehiculos.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonVerVehiculos" runat="server" class="btn btn-primary" OnClick="ButtonVerVehiculos_Click" Text="Ver vehículos" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlAgregarChofer">
                <img class="img-circle" src="Content/images/chofer.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonAgregarChofer" runat="server" class="btn btn-primary" OnClick="ButtonAgregarChofer_Click" Text="Agregar chofer" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlListarChoferes">
                <img class="img-circle" src="Content/images/verchofer.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonVerChoferes" runat="server" class="btn btn-primary" OnClick="ButtonVerChoferes_Click" Text="Ver choferes" />
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlClienteAgregarCliente">
                <img class="img-circle" src="Content/images/newcliente.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonAltaCliente" runat="server" class="btn btn-primary" OnClick="ButtonAltaCliente_Click" Text="Agregar cliente" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlListarCliente">
                <img class="img-circle" src="Content/images/cliente.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonVerClientes" runat="server" class="btn btn-primary" OnClick="ButtonVerClientes_Click" Text="Ver clientes" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlAlquiler">
                <img class="img-circle" src="Content/images/nuevoalquiler.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonNuevoAlquiler" runat="server" class="btn btn-primary" OnClick="ButtonNuevoAlquiler_Click" Text="Nuevo alquiler" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlListarAlquileres">
                <img class="img-circle" src="Content/images/alquileres.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonVerAlquileres" runat="server" class="btn btn-primary" OnClick="ButtonVerAlquileres_Click" Text="Ver alquileres" />
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlRetorno">
                <img class="img-circle" src="Content/images/retorno.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonRetorno" runat="server" class="btn btn-primary" OnClick="ButtonRetorno_Click" Text="Retorno" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlReportes">
                <img class="img-circle" src="Content/images/reportes.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonReportes" runat="server" class="btn btn-primary" OnClick="ButtonReportes_Click" Text="Ver reportes de daños" />
                </p>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" runat="server" id="HtmlBitacora">
                <img class="img-circle" src="Content/images/bitacora.png" alt="Generic placeholder image" width="140" height="140">
                <p></p>
                <p>
                    <asp:Button ID="ButtonBitacora" runat="server" class="btn btn-primary" OnClick="ButtonBitacora_Click" Text="Bitácora" />
                </p>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
