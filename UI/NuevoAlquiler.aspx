<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoAlquiler.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.NuevoAlquiler" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #MainContent_CalendarAlquilerFechaInicio {
            display: inline-block;
            margin-right: 15px;
        }

        #MainContent_CalendarAlquilerFechaFin {
            display: inline-block;
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
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina"></asp:Label>
        <br />
        <div class="form-inline">
            <asp:Label ID="LabelSucursal" runat="server" CssClass="labelfor"></asp:Label>
            <asp:DropDownList ID="DropDownListSucursalesOrigen" runat="server" CssClass="ddl form-control" OnSelectedIndexChanged="DropDownListSucursalesOrigen_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <br />
        <br />
        <div class="form-group">
            <asp:Label ID="LabelAlquilerFecha" CssClass="labelfor" runat="server" Text="Seleccione el inicio y fin del alquiler"></asp:Label>
            <br />
            <br />
            <asp:Calendar ID="CalendarAlquilerFechaInicio" runat="server" OnSelectionChanged="CalendarAlquilerFechaInicio_SelectionChanged"></asp:Calendar>
            <asp:Calendar ID="CalendarAlquilerFechaFin" runat="server" OnSelectionChanged="CalendarAlquilerFechaFin_SelectionChanged"></asp:Calendar>
            <br />
            <asp:Label ID="LabelValidacionFechas" runat="server" CssClass="alert alert-danger alerta-personalizada" Visible="false"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelNivelBlindaje" runat="server" CssClass="labelfor"></asp:Label>
            <asp:DropDownList ID="DropDownListNivelBlindaje" runat="server" CssClass="ddl form-control" OnSelectedIndexChanged="DropDownListNivelBlindaje_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonCargarVehiculos" runat="server" class="btn btn-primary" OnClick="ButtonCargarVehiculos_Click" Text="Ver vehículos disponibles" />
        </div>
        <div class="form-group">
            <asp:Label ID="LabelMenuVehiculos" runat="server" CssClass="labelfor"></asp:Label>
            <asp:DropDownList ID="DropDownListVehiculosDisponibles" runat="server" CssClass="ddl form-control" OnSelectedIndexChanged="DropDownListVehiculosDisponibles_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelSucursalDestino" runat="server" CssClass="labelfor"></asp:Label>
            <asp:DropDownList ID="DropDownListSucursalesDestino" runat="server" CssClass="ddl form-control" OnSelectedIndexChanged="DropDownListSucursalesDestino_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group checkChofer">
            <asp:CheckBox ID="CheckBoxChofer" runat="server" OnCheckedChanged="CheckBoxChofer_CheckedChanged" CssClass="labelfor" AutoPostBack="true" Text="¿Contrata chofer?" />
            <asp:DropDownList ID="DropDownListChoferes" runat="server" CssClass="ddl form-control" Enabled="false" OnSelectedIndexChanged="DropDownListChoferes_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonPresupuestar" runat="server" class="btn btn-primary" OnClick="ButtonPresupuestar_Click" Text="Presupuestar" />
            <br />
            <asp:Label ID="LabelChoferValidacion" CssClass="alert alert-danger alerta-personalizada" runat="server" Visible="false"></asp:Label>
            <br />
        </div>
        <div class="form-group alert alert-success" runat="server" id="HtmlPresupuesto" style="max-width: 500px;" visible="false">
            <asp:Label ID="LabelPresupuestoDias" runat="server" Style="font-weight: bold;" Text="Días: "></asp:Label>
            <asp:Label ID="LabelPresupuestoDiasValor" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelPresupuestoVehiculo" runat="server" Style="font-weight: bold;" Text="Costo por vehículo: "></asp:Label>
            $<asp:Label ID="LabelPresupuestoVehiculoValor" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelPresupuestoVehiculoKm" runat="server" Style="font-weight: bold;" Text="Costo por kilómetro: "></asp:Label>
            $<asp:Label ID="LabelPresupuestoVehiculoKmValor" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelPresupuestoChofer" runat="server" Style="font-weight: bold;" Text="Costo chofer: "></asp:Label>
            $<asp:Label ID="LabelPresupuestoChoferValor" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelPresupuestoRecargo" runat="server" Style="font-weight: bold;" Text="Recargo por sucursal: "></asp:Label>
            $<asp:Label ID="LabelPresupuestoRecargoValor" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelTotal" runat="server" Style="font-weight: bold;" Text="Total: "></asp:Label>
            $<asp:Label ID="LabelTotalValor" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonConfirmarAlquiler" runat="server" class="btn btn-success" Visible="false" OnClick="ButtonConfirmarAlquiler_Click" Text="Confirmar Alquiler" />
        </div>
    </div>
</asp:Content>
