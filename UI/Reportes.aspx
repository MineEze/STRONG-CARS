<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Reportes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Reportes de daños"></asp:Label>
        <br />
        <asp:Label ID="LabelGrillaSinRegistros" runat="server" CssClass="labelfor" Text="No se encontraron registros."></asp:Label>
        <br />
        <div class="form-group">
            <asp:Button ID="ButtonReporteExcel" runat="server" Text="Descargar reporte Excel" class="btn btn-primary" OnClick="ButtonReporteExcel_Click" />
            <asp:Button ID="ButtonReportePDF" runat="server" Text="Descargar reporte PDF" class="btn btn-primary" OnClick="ButtonReportePDF_Click" />
        </div>
        <asp:GridView ID="GridViewReportes" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="Fecha" ApplyFormatInEditMode="true" DataFormatString="{0:d}" HeaderText="Fecha" />
                <asp:BoundField DataField="Vehiculo" HeaderText="Vehículo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción de daños" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
</asp:Content>