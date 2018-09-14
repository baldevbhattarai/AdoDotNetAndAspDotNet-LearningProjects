using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormAuthenticationn
{
    public partial class LockedAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.Name.ToLower() == "baldev")
            {
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            else
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
        }
        private void GetData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllLocakedUserAccounts", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                gvLockedAccounts.DataSource = cmd.ExecuteReader();
                gvLockedAccounts.DataBind();
            }
        }

        private void EnableUserAccounts(string UserName)
        {
            string CS = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spEnableUserAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUserName = new SqlParameter()
                {
                    ParameterName = "@UserName",
                    Value = UserName
                };
                cmd.Parameters.Add(parameterUserName);
                con.Open();
                cmd.ExecuteNonQuery();
               
            }
        }
        protected void gvLockedAccounts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EnableUserAccounts(e.CommandArgument.ToString());
            GetData();


        }
    }
}