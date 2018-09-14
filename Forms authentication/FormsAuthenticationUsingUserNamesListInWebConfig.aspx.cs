using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forms_authentication
{
    public partial class FormsAuthenticationUsingUserNamesListInWebConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
          //  if(FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
            if(Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid UserName and/or password";

            }

        }
    }
}