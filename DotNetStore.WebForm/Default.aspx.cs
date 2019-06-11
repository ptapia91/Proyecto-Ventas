using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStore.WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<h1>Usted es el usuario número: " + 
                Application["Visitas"].ToString() + "</h1>");
        }
    }
}