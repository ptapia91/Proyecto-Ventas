using System.Web.Caching;
using DotNetStore.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStore.WebForm.Categorias
{
    public partial class Index : System.Web.UI.Page
    {
        ProductoLN _logicaNegocio = new ProductoLN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            //Si no existe la variable Categorias en el objeto CACHE
            if (Cache["Categorias"] == null)
            {
                //traemos las categorias de la BD
                var categorias = _logicaNegocio.SeleccionarCategorias();
                //Creamos la variable Categorias en el objeto CACHE
                Cache.Insert(
                    "Categorias", 
                    categorias, 
                    null, 
                    DateTime.UtcNow.AddMinutes(1), 
                    Cache.NoSlidingExpiration);

                gvCategorias.DataSource = categorias;
                gvCategorias.DataBind();
            }
            else
            {
                gvCategorias.DataSource = Cache["Categorias"];
                gvCategorias.DataBind();
            }
        }
    }
}