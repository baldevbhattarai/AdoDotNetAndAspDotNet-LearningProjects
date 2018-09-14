using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from tblemployee", con);

                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();

                SqlCommand cmd1 = new SqlCommand("Select Count(ID) from tblEmployee", con);
                con.Open();
                int TotalRows =(int) cmd1.ExecuteScalar();
                Response.Write("total no of rows : " + TotalRows.ToString()+"<br/>");
                con.Close();

                SqlCommand cmd2 = new SqlCommand("Insert into tblEmployee Values( 30, 'Karan', 'Male, 5000, 2", con);
                con.Open();
                int TotalRowsAffected = cmd1.ExecuteNonQuery();
                Response.Write("total no of rows Inserted  : " + TotalRowsAffected.ToString() + "<br/>");

                cmd2.CommandText = "Update tblEmployee set Salary = 5000 where ID = 3";
                int TotalRowsUpdated = cmd1.ExecuteNonQuery();
                Response.Write("total no of rows Updated  : " + TotalRowsUpdated.ToString() + "<br/>");

                cmd2.CommandText = "Delete from tblEmployee where ID = 1";
                TotalRowsUpdated = cmd1.ExecuteNonQuery();
                Response.Write("total no of rows Updated  : " + TotalRowsUpdated.ToString() + "<br/>");

            }
        }
    }
}