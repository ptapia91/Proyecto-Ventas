<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DotNetStore.WebForm.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title%>.</h2>
    <div class="row">         
         <div class="col-md-8">
             <section id="loginForm">
                  <div class="form-horizontal">
                    <h4>Use una cuenta del sistema para ingresar.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="MensajeError" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="litError" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                                CssClass="text-danger" ErrorMessage="El email es requerido." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="La contraseña es requerida." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" CssClass="btn btn-default" OnClick="btnIngresar_Click" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
