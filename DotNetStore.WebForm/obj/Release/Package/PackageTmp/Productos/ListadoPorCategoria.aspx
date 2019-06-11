<%@ Page Title="Listado de productos por categoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoPorCategoria.aspx.cs" Inherits="DotNetStore.WebForm.Productos.ListadoPorCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title + ": " + Request.QueryString["nombreCategoria"] %>.</h2>
    <asp:GridView ID="gvProductos" runat="server" DataKeyNames="ProductoID" GridLines="None" CssClass="table table-hover table-striped"
                AutoGenerateColumns="false">
                <Columns>                          
                    <asp:BoundField DataField="ProductoID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación" DataFormatString="{0:d}" />
                </Columns>
            </asp:GridView>
	<p>
        <asp:HyperLink ID="hylVolver" NavigateUrl="~/Categorias/Index.aspx" runat="server">Volver a lista de categorias</asp:HyperLink>
    </p>
</asp:Content>
