using System;
using System.Web.Security;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace FormAuthenticationn
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*  private bool AuthenticateUser(string userName, string password)
          {
              string CS = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
              using(SqlConnection con = new SqlConnection(CS))
              {
                  SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                  cmd.CommandType = CommandType.StoredProcedure;
                  string EncrtptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
                  SqlParameter username = new SqlParameter("@UserName", txtUserName.Text);
                  SqlParameter Password = new SqlParameter("@Password", EncrtptedPassword);

                  cmd.Parameters.Add(username);
                  cmd.Parameters.Add(Password);
                  con.Open();
                  int ReturnCode = (int)cmd.ExecuteScalar();

                  return ReturnCode == 1;

              }

          }*/
        private void AuthenticateUser(string username, string password)
        {
            // ConfigurationManager class is in System.Configuration namespace
            string CS = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            // SqlConnection is in System.Data.SqlClient namespace
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //Formsauthentication is in system.web.security
                string encryptedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                //sqlparameter is in System.Data namespace
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", encryptedpassword);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int RetryAttempts = Convert.ToInt32(rdr["RetryAttempts"]);
                    if (Convert.ToBoolean(rdr["AccountLocked"]))
                    {
                        lblMessage.Text = "Account locked. Please contact administrator";
                    }
                    else if (RetryAttempts > 0)
                    {
                        int AttemptsLeft = (4 - RetryAttempts);
                        lblMessage.Text = "Invalid user name and/or password. " +
                            AttemptsLeft.ToString() + "attempt(s) left";
                    }
                    else if (Convert.ToBoolean(rdr["Authenticated"]))
                    {
                        FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, CheckBox1.Checked);
                    }
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // if (FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
            /*  if (AuthenticateUser(txtUserName.Text, txtPassword.Text))
              {
                  FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, CheckBox1.Checked);

              }
              else
              {
                  lblMessage.Text = "User Name and/or Password Incorrect";
              }
              */
            AuthenticateUser(txtUserName.Text, txtPassword.Text);
        }
    }
}