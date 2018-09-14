using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class SessionState2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Name"] != null)
            {
                lblName.Text = Session["Name"].ToString();
            }
            if (Session["Email"] != null)
            {
                lblEmail.Text = Session["Email"].ToString();
            }
        }
    }
}