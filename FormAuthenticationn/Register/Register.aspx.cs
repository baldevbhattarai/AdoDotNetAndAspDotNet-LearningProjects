using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace FormAuthenticationn.Register
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
               
                string CS = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;


                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter username = new SqlParameter("@UserName", txtUserName.Text);

                    string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
                    SqlParameter password = new SqlParameter("@Password", encryptedPassword);
                    SqlParameter email = new SqlParameter("@Email", txtEmail.Text);

                    cmd.Parameters.Add(username);
                    cmd.Parameters.Add(password);
                    cmd.Parameters.Add(email);

                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteScalar();
                    if (ReturnCode == -1)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "User Name already in use, please choose another user name";
                    }
                    else
                    {
                        Response.Redirect("~/LogIn.aspx");
                    }
                }
            }

        }
    }
}