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
    public partial class SqlInjectionPrevention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                // SqlCommand cmd = new SqlCommand("select * from tblemployee where Name like '" + TextBox1.Text + "%'", con);
                //above line cause sql injection "--i'; Delete from tblEmployee --" so either use paramaterized sql query or stored procedure

                //SqlCommand cmd = new SqlCommand("select * from tblemployee where Name like @ProductName" , con);
                //cmd.Parameters.AddWithValue("@ProductName", TextBox1.Text + "%");
                //con.Open();
                //GridView1.DataSource = cmd.ExecuteReader();
                //GridView1.DataBind();

                //using Stored Procedure
                SqlCommand cmd = new SqlCommand("spGetEmployeeByName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeName", TextBox1.Text);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
                
    }
}