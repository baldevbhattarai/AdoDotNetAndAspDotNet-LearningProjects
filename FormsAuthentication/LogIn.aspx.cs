using System;
using System.Web.Security;
namespace FormAuthentication
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
            {
                // Create the authentication cookie and redirect the user to welcome page
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
            }
            else
            {
                lblMessage.Text = "Invalid UserName and/or password";
            }

        }
    }
}