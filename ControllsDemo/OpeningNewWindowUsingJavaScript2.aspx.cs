using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class OpeningNewWindowUsingJavaScript2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = Request.QueryString["Name"];
            lblEmail.Text = Request.QueryString["Email"];
        }
    }
}