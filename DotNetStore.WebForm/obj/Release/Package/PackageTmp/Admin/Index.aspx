<%@ Page Title="Listado de usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNetStore.WebForm.Admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title%>.</h2>
    <p>
        <asp:HyperLink ID="hylNuevo" NavigateUrl="~/Admin/Detalle.aspx" runat="server">Nuevo</asp:HyperLink>
    </p>
    <asp:GridView ID="gvUsuarios" runat="server" DataKeyNames="Id" GridLines="None" CssClass="table table-hover table-striped"
        AutoGenerateColumns="false" OnRowCommand="gvUsuarios_RowCommand">
        <Columns>
            <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Imagenes/edit.png" Text="Editar" />            
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                  <asp:ImageButton ID="imgEliminar" runat="server" CommandName="Eliminar" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/Imagenes/delete.png" 
                      OnClientClick="return confirm('¿Seguro que desea eliminar este usuario?');" ToolTip="Eliminar usuario" />
               </ItemTemplate>
            </asp:TemplateField>            
            <asp:BoundField DataField="Nombre" HeaderText="Usuario" />
            <asp:BoundField DataField="Rol.Nombre" HeaderText="Rol" />
        </Columns>
    </asp:GridView>
</asp:Content>
