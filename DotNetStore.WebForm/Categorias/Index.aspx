<%@ Page Title="Listado de categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNetStore.WebForm.Categorias.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title%>.</h2>
    <asp:GridView ID="gvCategorias" runat="server" DataKeyNames="CategoriaID" GridLines="None" CssClass="table table-hover table-striped"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="CategoriaID" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:HyperLinkField Text="Ver Productos" 
                DataNavigateUrlFields="CategoriaID,Nombre" 
                DataNavigateUrlFormatString="~/Productos/ListadoPorCategoria.aspx?idCategoria={0}&nombreCategoria={1}" />                       
        </Columns>
    </asp:GridView>
</asp:Content>
