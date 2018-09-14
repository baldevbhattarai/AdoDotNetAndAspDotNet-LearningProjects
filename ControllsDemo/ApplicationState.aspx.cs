using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class ApplicationState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendData_Click(object sender, EventArgs e)
        {
            Application["Name"] = txtName.Text;
            Application["Email"] = txtEmail.Text;
            Response.Redirect("~/ApplicationState2.aspx");
        }
    }
}