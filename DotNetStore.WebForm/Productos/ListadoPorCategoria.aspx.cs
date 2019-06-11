using DotNetStore.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStore.WebForm.Productos
{
    public partial class ListadoPorCategoria : System.Web.UI.Page
    {
        ProductoLN _logicaNegocio = new ProductoLN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (Request.QueryString["idCategoria"] != null)
            {
                int idCategoria = 0;
                int.TryParse(Request.QueryString["idCategoria"], out idCategoria);

                gvProductos.DataSource = _logicaNegocio.SeleccionarTodosPorCategoria(idCategoria);
                gvProductos.DataBind();
            }
        }
    }
}