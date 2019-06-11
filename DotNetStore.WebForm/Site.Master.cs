using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetStore.WebForm
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (Session["BackgroundColor"] != null)
            {
                ColorSelector.SelectedValue = Session["BackgroundColor"].ToString();
                BodyTag.Style["background-color"] = ColorSelector.SelectedValue;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void ColorSelector_IndexChanged(object sender, EventArgs e)
        {
            BodyTag.Style["background-color"] = ColorSelector.SelectedValue;
            Session["BackgroundColor"] = ColorSelector.SelectedValue;
        }
    }
}