<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarVehiculo.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.ModificarVehiculo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/validaciones.js"></script>
    <style>
        .flotar-derecha {
            float: right;
        }

        .dropdownlist {
            height: 27px;
            width: 178px;
        }

        .escondido {
            display: none;
        }

        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <br />
    <br />
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Modificar vehículo"></asp:Label>
        <br />
        <asp:Label ID="LabelModificarVehiculoExito" runat="server" CssClass="alert alert-success alerta-personalizada" Text="Vehículo modificado con éxito"></asp:Label>
        <br />
        <div class="form-group">
            <asp:Label ID="LabelMarca" runat="server" CssClass="labelfor" Text="Marca"></asp:Label>
            <asp:DropDownList ID="DropDownListMarca" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownListMarca_SelectedIndexChanged" OnDataBound="DropDownListMarca_DataBound" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelModelo" runat="server" CssClass="labelfor" Text="Modelo"></asp:Label>
            <asp:DropDownList ID="DropDownListModelo" runat="server" CssClass="form-control" OnDataBound="DropDownListModelo_DataBound"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelNivelBlindaje" runat="server" CssClass="labelfor" Text="Nivel de blindaje"></asp:Label>
            <asp:DropDownList ID="DropDownListNivelBlindaje" runat="server" CssClass="form-control" OnDataBound="DropDownListNivelBlindaje_DataBound"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelPatente" runat="server" CssClass="labelfor" Text="Patente"></asp:Label>
            <asp:TextBox ID="TextBoxPatente" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionPatente" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="La patente debe tener al menos 6 dígitos"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelKilometraje" runat="server" CssClass="labelfor" Text="Kilometraje"></asp:Label>
            <asp:TextBox ID="TextBoxKilometraje" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionKilometraje" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Por favor ingrese kilometraje"></asp:Label>
            <asp:Label ID="LabelValidacionKilometrajeNumerico" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El kilometraje debe ser numérico"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelPrecioDiarioBase" runat="server" CssClass="labelfor" Text="Precio diario base"></asp:Label>
            <asp:TextBox ID="TextBoxPrecioDiarioBase" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionPrecioDiarioBase" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Por favor ingrese precio diario base"></asp:Label>
            <asp:Label ID="LabelValidacionPrecioDiarioBaseNumerico" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El precio diario debe ser un valor numérico"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelPrecioPorKm" runat="server" CssClass="labelfor" Text="Precio por kilómetro"></asp:Label>
            <asp:TextBox ID="TextBoxPrecioPorKm" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="LabelValidacionPrecioPorKm" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Por favor ingrese precio por kilómetro"></asp:Label>
            <asp:Label ID="LabelValidacionPrecioPorKmNumerico" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El precio por kilómetro debe ser un valor numérico"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelFechaInicio" runat="server" CssClass="labelfor" Text="Fecha de inicio"></asp:Label>
            <asp:Calendar ID="CalendarFechaInicio" runat="server"></asp:Calendar>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelSucursal" runat="server" CssClass="labelfor" Text="Sucursal"></asp:Label>
            <asp:DropDownList ID="DropDownListSucursales" runat="server" CssClass="form-control" OnDataBound="DropDownListSucursales_DataBound"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonModificarVehiculo" runat="server" OnClientClick="return validarFormRegistrarVehiculo();" OnClick="ButtonModificarVehiculo_Click" class="btn btn-primary" Text="Modificar vehículo" />
        </div>
    </div>
</asp:Content>
