using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace DotNetStore.WebForm
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["Visitas"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application["Visitas"] = 
                Int32.Parse(Application["Visitas"].ToString()) + 1;
        }

        //void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exc = Server.GetLastError().GetBaseException();
        //    Response.Write("<h2>Error:</h2>\n");
        //    Response.Write("<b>Exepcion en Application_Error: </b>" + exc.Message.ToString() + "\n");
        //    Response.Write("Retorna al <a href='../Default.aspx'>Inicio</a>\n");
        //    Server.ClearError();
        //}
    }
}