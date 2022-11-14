<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AgregarCliente.aspx.cs" Inherits="UI.AgregarCliente" %>

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
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Agregar cliente"></asp:Label>
        <br />
        <asp:Label ID="LabelCreacionClienteExito" runat="server" CssClass="alert alert-success alerta-personalizada" Text="Cliente creado con éxito."></asp:Label>
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
            <asp:Label ID="LabelLicencia" runat="server" CssClass="labelfor" Text="Licencia"></asp:Label>
            <asp:TextBox ID="TextBoxLicencia" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionLicencia" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La licencia de conducir debe tener al menos 6 dígitos"></asp:Label>
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
            <asp:Label ID="LabelTelefono" runat="server" CssClass="labelfor" Text="Teléfono"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelTelefonoCaracteristica" runat="server" CssClass="labelfor" Text="Característica"></asp:Label>
            <asp:TextBox ID="TextBoxTelefonoCaracteristica" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionTelefonoCaracteristica" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La característica debe tener al menos 2 dígitos"></asp:Label>
            <asp:Label ID="LabelValidacionTelefonoCaracteristicaNumerica" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La característica debe ser numérica"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelTelefonoNumero" runat="server" CssClass="labelfor" Text="Número"></asp:Label>
            <asp:TextBox ID="TextBoxTelefonoNumero" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionTelefonoNumero" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El número debe tener al menos 7 dígitos"></asp:Label>
            <asp:Label ID="LabelValidacionTelefonoNumeroNumerico" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El número debe ser numérico"></asp:Label>
        </div>
        <div class="form-group">
            <asp:RadioButtonList ID="RadioButtonListEmpresa" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListEmpresa_SelectedIndexChanged"></asp:RadioButtonList>
            <asp:Label ID="LabelValidacionEmpresa" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false"></asp:Label>
            <asp:Label ID="LabelValidacionEmpresaSeleccion" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false"></asp:Label>

            <br />            
            <asp:Label ID="LabelEmpresaNombre" runat="server" CssClass="labelfor" Visible="false" Text="Nombre de la empresa"></asp:Label>
            <asp:TextBox ID="TextBoxEmpresaNombre" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
            <asp:Label ID="LabelValidacionEmpresaNombre" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false"></asp:Label>
            <asp:Label ID="LabelEmpresa" runat="server" CssClass="labelfor" Visible="false" Text="Empresa"></asp:Label>            
            <br />
            <br />
            <asp:RadioButtonList ID="RadioButtonListEmpresasExistentes" runat="server" Visible="false"></asp:RadioButtonList>

        </div>
        <div class="form-group">
            <asp:Button ID="ButtonCrearCliente" runat="server" OnClientClick="return validarFormRegistrarCliente();" OnClick="ButtonCrearCliente_Click" class="btn btn-primary" Text="Crear" />
        </div>
    </div>
</asp:Content>
