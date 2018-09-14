using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class QueryString : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        //    string query = "~/QueryString2.aspx?Name="+txtName.Text+"&Email="+txtEmail.Text;
        //    Response.Redirect(query);

            //--------------------------------------------------------------------------------
            //Using Server.UrlEncode to encode &(ampersand)
            Response.Redirect("QueryString2.aspx?Name=" + Server.UrlEncode(txtName.Text) + 
              "&Email=" + Server.UrlEncode(txtEmail.Text));

            //Using String.Replace() function to replace &(ampersand) with %26 
            //Response.Redirect("QueryString2.aspx?UserName=" + txtName.Text.Replace("&", "%26") +
            //    "&UserEmail=" + txtEmail.Text.Replace("&", "%26"));

        }
    }
}