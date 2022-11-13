<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.EditarUsuario" %>

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
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Modificar usuario"></asp:Label>
        <br />
        <asp:Label ID="LabelEditarUsuarioExito" runat="server" CssClass="alert alert-success alerta-personalizada" Text="Usuario editado con éxito."></asp:Label>
        <br />
        <div class="form-group">
            <asp:Label ID="LabelNombre" runat="server" CssClass="labelfor" Text="Nombre"></asp:Label>
            <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionNombre" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El nombre debe tener entre 2 y 100 caracteres"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelApellido" runat="server" CssClass="labelfor" Text="Apellido"></asp:Label>
            <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionApellido" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El apellido debe tener entre 2 y 100 caracteres"></asp:Label>
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
            <asp:Label ID="LabelValidacionCalle" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Debe ingresar una calle de hasta 100 caracteres"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelAltura" runat="server" CssClass="labelfor" Text="Altura"></asp:Label>
            <asp:TextBox ID="TextBoxAltura" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionAltura" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Por favor ingrese una altura correcta"></asp:Label>
            <asp:Label ID="LabelValidacionAlturaNumerica" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La altura debe ser numérica"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelUnidad" runat="server" CssClass="labelfor" Text="Unidad (opcional)"></asp:Label>
            <asp:TextBox ID="TextBoxUnidad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelCodigoPostal" runat="server" CssClass="labelfor" Text="Código postal"></asp:Label>
            <asp:TextBox ID="TextBoxCodigoPostal" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionCodigoPostal" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Debe ingresar un código postal correcto"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelUsuario" runat="server" CssClass="labelfor" Text="Usuario"></asp:Label>
            <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionUsuario" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El nombre de usuario debe tener al menos 4 caracteres"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelBloqueado" runat="server" CssClass="labelfor" Text="Usuario bloqueado"></asp:Label>
            <asp:CheckBox ID="CheckBoxBloqueado" runat="server" />
        </div>
        <div class="form-group">
            <asp:Label ID="LabelPermisos" runat="server" CssClass="labelfor" Text="Permisos"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxListPermisos" runat="server" OnDataBound="CheckBoxListPermisos_DataBound"></asp:CheckBoxList>
            <asp:Label ID="LabelValidacionPermisos" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Debe seleccionar al menos un permiso"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonEditarUsuario" runat="server" OnClientClick="return validarFormEditarUsuario();" OnClick="ButtonEditarUsuario_Click" class="btn btn-primary" Text="Editar" />
            <br />
            <asp:Label ID="LabelNombreDeUsuarioEnUso" runat="server" CssClass="alert alert-danger alerta-personalizada" Text="Nombre de usuario en uso."></asp:Label>
        </div>
    </div>
</asp:Content>
