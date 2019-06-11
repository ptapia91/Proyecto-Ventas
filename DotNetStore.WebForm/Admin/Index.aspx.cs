using DotNetStore.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStore.WebForm.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        UsuarioLN _logicaNegocio = new UsuarioLN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            gvUsuarios.DataSource = _logicaNegocio.SeleccionarTodos();
            gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gvUsuarios.SelectedIndex = Convert.ToInt32(e.CommandArgument);
            var id = gvUsuarios.SelectedDataKey[0].ToString();
            switch (e.CommandName)
            {
                case "Editar":
                    Response.Redirect("~/Admin/Detalle.aspx?id=" + id);
                    break;
                case "Eliminar":
                    _logicaNegocio.Eliminar(id);
                    Response.Redirect("~/Admin/Index.aspx");
                    break;
            }
        }
    }
}