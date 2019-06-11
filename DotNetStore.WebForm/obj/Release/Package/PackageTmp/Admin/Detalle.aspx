<%@ Page Title="Administrar cuenta de usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="DotNetStore.WebForm.Admin.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title%>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="litError"></asp:Literal>
    </p>
    <div class="form-horizontal">
        <h4>Administrar cuenta</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="text-danger"
                    ErrorMessage="El email es requerido"></asp:RequiredFieldValidator>
            </div>            
        </div>
        <div class="form-group" id="divPassword" runat="server">
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger"
                    ErrorMessage="El password es requerido"></asp:RequiredFieldValidator>
            </div>
            
        </div>
        <div class="form-group" id="divConfirmarPassword" runat="server">
            <asp:Label runat="server" AssociatedControlID="txtConfirmarPassword" CssClass="col-md-2 control-label">
                Confirmar password
            </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtConfirmarPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmarPassword" CssClass="text-danger"
                    Display="Dynamic" ErrorMessage="La confirmación de password es requerido"></asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmarPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="El password y la confirmación de password son distintas"></asp:CompareValidator>
            </div>            
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlRoles" CssClass="col-md-2 control-label">Rol</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlRoles" CssClass="form-control"></asp:DropDownList>
            </div>            
        </div>
        <div class="form-group">            
            <div class="col-md-offset-2 col-md-10">                
                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-default" OnClick="btnGuardar_Click" />
            </div>            
        </div>
    </div>
</asp:Content>
