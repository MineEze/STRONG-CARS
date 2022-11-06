<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetornoDetalle.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.RetornoDetalle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .flotar-derecha {
            float: right;
        }

        .descripcion-reporte {
            width: 300px;
            height: 100px;
        }

        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Retorno"></asp:Label>
        <br />
        <asp:Label ID="LabelRetornarExito" runat="server" CssClass="alert alert-success alerta-personalizada" Visible="false" Text="Vehículo retornado con éxito"></asp:Label>
        <br />
        <div class="form-group">
            <asp:Label ID="LabelCliente" CssClass="labelfor" runat="server" Text="Cliente"></asp:Label>
            <asp:Label ID="LabelClienteValor" runat="server" Text="Vehículo"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelVehiculo" CssClass="labelfor" runat="server"></asp:Label>
            <asp:Label ID="LabelVehiculoValor" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelKilometrajeAnterior" CssClass="labelfor" runat="server" Text="Kilometraje anterior"></asp:Label>
            <asp:Label ID="LabelKilometrajeAnteriorValor" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelSucursalOrigen" CssClass="labelfor" runat="server" Text="Sucursal"></asp:Label>
            <asp:Label ID="LabelSucursalOrigenValor" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelFechaInicio" CssClass="labelfor" runat="server" Text="Inicio"></asp:Label>
            <asp:Label ID="LabelFechaInicioValor" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelFechaFin" CssClass="labelfor" runat="server" Text="Fin"></asp:Label>
            <asp:Label ID="LabelFechaFinValor" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelNuevoKilometraje" CssClass="labelfor" runat="server" Text="Nuevo kilometraje"></asp:Label>
            <asp:TextBox ID="TextBoxNuevoKilometraje" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelValidacionKilometrajeNumerico" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false" Text="El kilometraje debe ser numérico"></asp:Label>
            <asp:Label ID="LabelValidacionNuevoKilometraje" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false" Text="El kilometraje no puede ser menor al anterior"></asp:Label>
        </div>
        <div class="form-group checkDanios">
            <asp:CheckBox ID="CheckBoxDanios" runat="server" OnCheckedChanged="CheckBoxDanios_CheckedChanged" AutoPostBack="true" Text="¿Presenta daños?" />
        </div>
        <div class="form-group">
             <asp:Label ID="LabelDanios" CssClass="labelfor" runat="server" Visible="false" Text="Reporte de daños:"></asp:Label>
             <asp:TextBox ID="TextBoxDanios" runat="server" CssClass="descripcion-reporte form-control" TextMode="MultiLine" MaxLength="199" Enabled="false"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonRetornar" runat="server" OnClick="ButtonRetornar_Click" class="btn btn-primary" Text="Retornar vehículo" />
            <br />
            <asp:Label ID="LabelValidacionDanios" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false" Text="Por favor ingrese los daños encontrados"></asp:Label>
        </div>
    </div>
</asp:Content>
