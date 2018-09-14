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
    public partial class SqlDataAdaptor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                // da.SelectCommand = new SqlCommand("select * from tblEmployeees", con);
                da.SelectCommand = new SqlCommand("spGetEmployeeById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@EmployeeId", TextBox1.Text);

                DataSet dataSet = new DataSet();
                da.Fill(dataSet);

                GridView1.DataSource = dataSet;
                GridView1.DataBind();

            }
        }
    }
}