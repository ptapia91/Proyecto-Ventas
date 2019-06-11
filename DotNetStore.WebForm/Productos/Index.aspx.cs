using DotNetStore.Entidades;
using DotNetStore.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStore.WebForm.Productos
{
    public partial class Index : System.Web.UI.Page
    {
        ProductoLN _logicaNegocio = new ProductoLN();

        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    Exception exc = Server.GetLastError();
        //    Response.Write("<h2>Error:</h2>\n");
        //    Response.Write("<b>Exepcion en Page_Error: </b>" + exc.Message.ToString() + "\n");
        //    Response.Write("Retorna al <a href='../Default.aspx'>Inicio</a>\n");
        //    Server.ClearError();
        //}

        void Buscar()
        {
            //gvProductos.DataSource = _logicaNegocio.SeleccionarTodos();
            //Se obtiene la categoria seleccionada
            int categoriaID = Int32.Parse(ddlFiltroCategoria.SelectedValue);
            //Se otbiene la fecha de inicio
            DateTime inicioFechaCreacion = new DateTime();
            DateTime finFechaCreacion = new DateTime();
            DateTime.TryParseExact(txtFiltroFechaInicioCreacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out inicioFechaCreacion);
            //Se obtiene la fecha fin
            DateTime.TryParseExact(txtFiltroFechaFinCreacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out finFechaCreacion);
            finFechaCreacion = finFechaCreacion.AddDays(1);
            //Se trae informacion desde la capa de negocio
            gvProductos.DataSource = _logicaNegocio.SeleccionarTodosPorFiltro(categoriaID,
                                                                      inicioFechaCreacion,
                                                                      finFechaCreacion);
            gvProductos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (IsPostBack)
                {
                    return;
                }

            Trace.Write("Este es el metodo Page_Load");
            //throw new Exception("EXCEPTION GENERADA");
            //object o1 = "a";
              //  int i2 = (int)o1;


                //Traemos las categorias desde la capa de negocio
                var categorias = _logicaNegocio.SeleccionarCategorias().ToList();
                //Al resultado de categorias, le agregamos en la posicion 0
                //la opcion TODOS
                categorias.Insert(0, new Categoria { CategoriaID = 0, Nombre = "TODOS" });
                //Lo asignamos al dropdownlist
                ddlFiltroCategoria.DataSource = categorias;
                ddlFiltroCategoria.DataBind();

                Buscar();
            //}
            //catch (InvalidCastException ex1)
            //{
            //    litError.Text = ex1.Message;
            //}
            //catch (Exception ex)
            //{
            //    litError.Text = ex.Message;
            //}
            //finally
            //{
            //    litError.Text += ". FINALLY";
            //}
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //try
            //{
                System.Threading.Thread.Sleep(3000);//Demora 3 segundos
                Buscar();
            //}
            //catch (Exception ex)
            //{
            //    litError.Text = ex.Message;
            //}
        }
    }
}