<%@ Page Title="Listado de productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNetStore.WebForm.Productos.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title%>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="litError"></asp:Literal>
    </p>
    <asp:UpdateProgress ID="UpdateProgress1" runat="Server" 
        AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
        <ProgressTemplate >
            <div class="update">
            </div>       
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <p>
                Categoria:<asp:DropDownList ID="ddlFiltroCategoria" runat="server" DataTextField="Nombre" DataValueField="CategoriaID"></asp:DropDownList>
                Fecha Inicio: <asp:TextBox ID="txtFiltroFechaInicioCreacion" runat="server"></asp:TextBox>
                Fecha Fin: <asp:TextBox ID="txtFiltroFechaFinCreacion" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" OnClick="btnBuscar_Click" />                    
                <ajaxToolkit:CalendarExtender ID="txtFiltroFechaInicioCreacion_E" runat="server" Enabled="true" 
                        TargetControlID="txtFiltroFechaInicioCreacion"/>
                <ajaxToolkit:CalendarExtender ID="txtFiltroFechaFinCreacion_E" runat="server" Enabled="true" 
                        TargetControlID="txtFiltroFechaFinCreacion" />
            </p>
            <asp:GridView ID="gvProductos" runat="server" DataKeyNames="ProductoID" GridLines="None" CssClass="table table-hover table-striped"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ProductoID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Categoria.Nombre" HeaderText="Categoria" />
                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación" DataFormatString="{0:d}" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
