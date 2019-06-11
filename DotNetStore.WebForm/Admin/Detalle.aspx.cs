using DotNetStore.Entidades;
using DotNetStore.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStore.WebForm.Admin
{
    public partial class Detalle : System.Web.UI.Page
    {
        UsuarioLN _logicaNegocio = new UsuarioLN();
        string idUsuario = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //~/Admin/Detalle.aspx?id
            idUsuario = Request.QueryString["id"];


            if (Page.IsPostBack)
                return;

            ddlRoles.DataSource = _logicaNegocio.SeleccionarRoles();
            ddlRoles.DataValueField = "Id";
            ddlRoles.DataTextField = "Nombre";
            ddlRoles.DataBind();

            //Validamos que estamos editando un usuario
            if (!string.IsNullOrEmpty(idUsuario))
            {
                divPassword.Visible = false;
                divConfirmarPassword.Visible = false;

                var usuario = _logicaNegocio.Seleccionar(idUsuario);
                txtEmail.Text = usuario.Email;
                if (usuario.Rol != null)
                {
                    ddlRoles.SelectedValue = usuario.Rol.Id;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //Creacion de usuario
                    if (string.IsNullOrEmpty(idUsuario))
                    {
                        if (_logicaNegocio.Insertar(txtEmail.Text, txtPassword.Text, ddlRoles.SelectedValue))
                            Response.Redirect("~/Admin/Index.aspx");
                        else
                            litError.Text = "Ocurrió un error al crear el usuario";
                    }
                    //Modificacion de usuario
                    else
                    {
                        var usuario = _logicaNegocio.Seleccionar(idUsuario);
                        usuario.Nombre = txtEmail.Text;
                        usuario.Email = txtEmail.Text;
                        var rol = new Rol {
                            Id = ddlRoles.SelectedValue,
                            Nombre = ddlRoles.SelectedItem.Text };
                        usuario.Rol = rol;
                        if (_logicaNegocio.Actualizar(usuario))
                            Response.Redirect("~/Admin/Index.aspx");
                        else
                            litError.Text = "Ocurrió un error al actualizar el usuario";
                    }
                }
                else
                    litError.Text = "Algunas validaciones son requeridas. Ingrese la información por favor.";
            }
            catch (Exception ex)
            {
                litError.Text = "Ocurrio un error: " + ex.Message;
            }
        }
    }
}