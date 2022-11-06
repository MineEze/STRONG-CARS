<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Choferes.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Choferes" %>

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
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Choferes"></asp:Label>
        <br />
        <asp:Label ID="LabelGrillaSinRegistros" runat="server" CssClass="labelfor">No se encontraron registros.</asp:Label>
        <br />
        <div class="form-group">
            <asp:Button ID="ButtonReporteExcel" runat="server" Text="Descargar reporte Excel" class="btn btn-primary" OnClick="ButtonReporteExcel_Click" />
            <asp:Button ID="ButtonReportePDF" runat="server" Text="Descargar reporte PDF" class="btn btn-primary" OnClick="ButtonReportePDF_Click" />
        </div>
        <asp:GridView ID="GridViewChoferes" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEditar" CssClass="glyphicon glyphicon-pencil" class="linkGrilla" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Editar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="Borrar">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonBorrar" CssClass="glyphicon glyphicon-remove" class="linkGrilla" runat="server" CommandArgument='<%# Eval("Id") %>' OnClientClick="if(!confirmacion()) return false;" OnClick="Borrar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
