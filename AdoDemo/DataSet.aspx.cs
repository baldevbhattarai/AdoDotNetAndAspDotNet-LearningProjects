using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using System.Data.SqlClient;
using System.Data;

namespace AdoDemo
{
    public partial class DataSett : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter();
               
                da.SelectCommand = new SqlCommand("spGetBothEmployeeTables", con);

                DataSet ds = new DataSet();
                da.Fill(ds);
                ds.Tables[0].TableName = "EmployeesA";
                ds.Tables[1].TableName = "EmployeesB";



                GridView1.DataSource = ds.Tables["EmployeesA"];
                GridView1.DataBind();


                GridView2.DataSource = ds.Tables["EmployeesB"];
                GridView2.DataBind();
            }
        }

        
    }
}