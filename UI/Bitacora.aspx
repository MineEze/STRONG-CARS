<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #MainContent_CalendarFiltroFechaInicio {
            display: inline-block;
            margin-right: 15px;
        }

        #MainContent_CalendarFiltroFechaFin {
            display: inline-block;
        }

        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Bitácora"></asp:Label>
        <br />
        <div class="form-inline">
            <asp:Label ID="LabelFiltroBitacoraUsuario" CssClass="labelfor" runat="server" Style="margin-top: 5px; min-width: 210px" Text="Filtrar por nombre de usuario"></asp:Label>
            <asp:TextBox ID="TextBoxFiltroBitacoraUsuario" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonFiltroBitacoraUsuario" runat="server" Text="Filtrar por usuario" class="btn btn-primary" OnClick="ButtonFiltroBitacoraUsuario_Click" Style="margin-left: 10px;" />
        </div>
        <br />
        <br />
        <div class="form-group">
            <asp:Label ID="LabelFiltroBitacoraFecha" CssClass="labelfor" runat="server" Text="Filtrar por fecha"></asp:Label>
            <br />
            <br />
            <asp:Calendar ID="CalendarFiltroFechaInicio" runat="server"></asp:Calendar>
            <asp:Calendar ID="CalendarFiltroFechaFin" runat="server"></asp:Calendar>
            <asp:Button ID="ButtonFiltroBitacoraFecha" runat="server" Text="Filtrar por fecha" class="btn btn-primary" OnClick="ButtonFiltroBitacoraFecha_Click" Style="margin-bottom: 24px; margin-left: 11px;" />
            <br />
            <asp:Label ID="LabelValidacionFecha" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="Por favor seleccione ambas fechas"></asp:Label>
            <asp:Label ID="LabelValidacionFechaOrden" runat="server" CssClass="alert alert-danger alerta-personalizada escondido" Text="El rango de fechas es inválido"></asp:Label>
            <br />
            <asp:Button ID="ButtonReporteExcel" runat="server" Text="Descargar reporte Excel" class="btn btn-primary" OnClick="ButtonReporteExcel_Click" />
            <asp:Button ID="ButtonReportePDF" runat="server" Text="Descargar reporte PDF" class="btn btn-primary" OnClick="ButtonReportePDF_Click" />
        </div>
        <div class="form-group">
            <asp:GridView ID="GridViewBitacora" runat="server" AutoGenerateColumns="false" CssClass="table table-hover">
                <Columns>
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="FechaYHora" HeaderText="Fecha" />
                    <asp:BoundField DataField="Mensaje" HeaderText="Mensaje" />
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
