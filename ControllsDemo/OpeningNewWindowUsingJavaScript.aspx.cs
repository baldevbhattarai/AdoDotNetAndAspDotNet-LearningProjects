using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class OpeningNewWindowUsingJavaScript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          
                string strJavascript = "<script type='text/javascript'>window.open('OpeningNewWindowUsingJavaScript2.aspx?Name=";
                strJavascript += txtName.Text + "&Email=" + txtEmail.Text + "','_blank');</script>";
                Response.Write(strJavascript);
         

        }
    }
}