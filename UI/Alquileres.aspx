<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alquileres.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Alquileres" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <script>
        function confirmacion() {
            return confirm("¿Está seguro?");
        }
    </script>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Alquileres"></asp:Label>
        <br />
        <asp:Label ID="LabelGrillaSinRegistros" runat="server" CssClass="labelfor" Text="No se encontraron registros."></asp:Label>
        <br />
        <div class="form-group">
            <asp:Button ID="ButtonReporteExcel" runat="server" Text="Descargar reporte Excel" class="btn btn-primary" OnClick="ButtonReporteExcel_Click" />
            <asp:Button ID="ButtonReportePDF" runat="server" Text="Descargar reporte PDF" class="btn btn-primary" OnClick="ButtonReportePDF_Click" />
        </div>
        <asp:GridView ID="GridViewAlquileres" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="SucursalOrigen" HeaderText="Sucursal" />
                <asp:BoundField DataField="Vehiculo" HeaderText="Vehículo" />
                <asp:BoundField DataField="FechaInicio" ApplyFormatInEditMode="true" DataFormatString="{0:d}" HeaderText="Inicio" />
                <asp:BoundField DataField="FechaFin" ApplyFormatInEditMode="true" DataFormatString="{0:d}" HeaderText="Fin" />
                <asp:TemplateField ShowHeader="False" HeaderText="Cancelar">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonBorrar" CssClass="glyphicon glyphicon-remove" class="linkGrilla" runat="server" CommandArgument='<%# Eval("Id") %>' OnClientClick="if(!confirmacion()) return false;" OnClick="Borrar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
</asp:Content>
