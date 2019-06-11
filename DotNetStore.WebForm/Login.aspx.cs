using DotNetStore.LogicaNegocio;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStore.WebForm
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioLN _logicaNegocio = new UsuarioLN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Default");
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var usuario = _logicaNegocio.Validar(txtEmail.Text, txtPassword.Text);
                if (usuario != null)
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = _logicaNegocio.CrearIdentidad(usuario);
                    authenticationManager.SignIn(
                        new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    litError.Text = "Usuario o contraseña invalido, intente nuevamente.";
                    MensajeError.Visible = true;
                }
            }

        }
    }
}