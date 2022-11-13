<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Registrarse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/validaciones.js"></script>
    <style>
        .escondido {
            display: none;
        }

        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Registrarse"></asp:Label>
        <br />
        <asp:Label ID="LabelCreacionUsuarioExito" runat="server" CssClass="alert alert-success alerta-personalizada" Text="Usuario creado con éxito."></asp:Label>
        <br />
        <div class="form-group">
            <asp:Label ID="LabelNombre" runat="server" CssClass="labelfor" Text="Nombre"></asp:Label>
            <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionNombre" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El nombre debe tener al menos 2 caracteres"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelApellido" runat="server" CssClass="labelfor" Text="Apellido"></asp:Label>
            <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionApellido" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El apellido debe tener al menos 2 caracteres"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelDNI" runat="server" CssClass="labelfor" Text="DNI"></asp:Label>
            <asp:TextBox ID="TextBoxDNI" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionDNI" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El DNI debe tener como mínimo 6 caracteres"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelEmail" runat="server" CssClass="labelfor" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionEmail" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Por favor ingrese un email correcto"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelCalle" runat="server" CssClass="labelfor" Text="Calle"></asp:Label>
            <asp:TextBox ID="TextBoxCalle" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionCalle" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Debe ingresar una calle"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelAltura" runat="server" CssClass="labelfor" Text="Altura"></asp:Label>
            <asp:TextBox ID="TextBoxAltura" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionAltura" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Por favor ingrese la altura"></asp:Label>
            <asp:Label ID="LabelValidacionAlturaNumerica" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La altura debe ser numérica"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelUnidad" runat="server" CssClass="labelfor" Text="Unidad (opcional)"></asp:Label>
            <asp:TextBox ID="TextBoxUnidad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelCodigoPostal" runat="server" CssClass="labelfor" Text="Código postal"></asp:Label>
            <asp:TextBox ID="TextBoxCodigoPostal" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionCodigoPostal" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Debe ingresar un código postal válido"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelUsuario" runat="server" CssClass="labelfor" Text="Usuario"></asp:Label>
            <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionUsuario" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El nombre de usuario debe tener al menos 4 caracteres"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelPassword" runat="server" CssClass="labelfor" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionPassword" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La contraseña debe tener al menos 8 caracteres"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelRepitaPassword" runat="server" CssClass="labelfor" Text="Repetir contraseña"></asp:Label>
            <asp:TextBox ID="TextBoxPasswordRepetido" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionPasswordRepetido" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Las contraseñas no coinciden"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonCrearUsuario" runat="server" OnClientClick="return validarFormRegistrarse();" OnClick="ButtonCrearUsuario_Click" class="btn btn-primary" Text="Crear usuario" />
            <br />
            <asp:Label ID="LabelNombreDeUsuarioEnUso" runat="server" CssClass="alert alert-danger alerta-personalizada" Text="Nombre de usuario en uso."></asp:Label>
        </div>
    </div>
</asp:Content>
