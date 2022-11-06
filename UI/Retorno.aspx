<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Retorno.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Retorno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .containerAgregar {
            background-color: #eee;
            border-radius: 10px;
            margin-top: 40px;
        }
    </style>
    <div class="container containerAgregar">
        <asp:Label ID="LabelTitulo" runat="server" CssClass="titulo-pagina" Text="Retorno"></asp:Label>
        <br />
        <asp:Label ID="LabelGrillaSinRegistros" runat="server" CssClass="labelfor" Text="No se encontraron registros."></asp:Label>
        <br />
        <asp:GridView ID="GridViewAlquileres" runat="server" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="SucursalOrigen" HeaderText="Sucursal" />
                <asp:BoundField DataField="Vehiculo" HeaderText="Vehículo" />
                <asp:BoundField DataField="FechaInicio" ApplyFormatInEditMode="true" DataFormatString="{0:d}" HeaderText="Inicio" />
                <asp:BoundField DataField="FechaFin" ApplyFormatInEditMode="true" DataFormatString="{0:d}" HeaderText="Fin" />
                <asp:TemplateField ShowHeader="False" HeaderText="Retornar vehículo">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonRetorno" CssClass="glyphicon glyphicon-repeat" class="linkGrilla" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="Retorno_Click" Text="Retorno" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
</asp:Content>
