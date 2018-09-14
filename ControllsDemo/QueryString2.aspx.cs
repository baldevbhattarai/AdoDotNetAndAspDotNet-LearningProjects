using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class QueryString2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = Request.QueryString["Name"];
                lblEmail.Text = Request.QueryString["Email"];


                //lblName.Text = Request.QueryString[0];
                //lblEmail.Text = Request.QueryString[1];
            }

        }
    }
}