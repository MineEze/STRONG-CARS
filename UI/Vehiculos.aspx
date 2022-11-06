<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Vehiculos" %>

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
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Vehículos"></asp:Label>
        <br />
        <div class="form-group">
            <asp:Label ID="LabelGrillaSinRegistros" runat="server" CssClass="labelfor" Text="No se encontraron registros"></asp:Label>
            <br />
            <div class="form-group">
                <asp:Button ID="ButtonReporteExcel" runat="server" Text="Descargar reporte Excel" class="btn btn-primary" OnClick="ButtonReporteExcel_Click" />
                <asp:Button ID="ButtonReportePDF" runat="server" Text="Descargar reporte PDF" class="btn btn-primary" OnClick="ButtonReportePDF_Click" />
            </div>
            <asp:GridView ID="GridViewVehiculos" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
                <Columns>
                    <asp:BoundField DataField="MarcaNombre" HeaderText="Marca" />
                    <asp:BoundField DataField="ModeloNombre" HeaderText="Modelo" />
                    <asp:BoundField DataField="Patente" HeaderText="Patente" />
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
    </div>
</asp:Content>
