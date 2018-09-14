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
    public partial class sqlDataReader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from tblEmployee; select * from tblEmployeees",con);

                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("E ID");
                    table.Columns.Add("E Name");
                    table.Columns.Add("E Salary");
                    table.Columns.Add("E Increased Salary");

                    //SqlDatareader.Read() is used to move to next row within the reselt set--used to loop through rows in reseltset

                    while (rdr.Read())
                    {
                       DataRow dataRow =  table.NewRow();

                        int OriginalSalary = Convert.ToInt32( rdr["Salary"]);
                        double IncreasedSalary = OriginalSalary * 1.5;

                        dataRow["E ID"] = rdr["ID"];
                        dataRow["E Name"] = rdr["Name"];
                        dataRow["E Salary"] = OriginalSalary;
                        dataRow["E Increased Salary"] = IncreasedSalary;

                        table.Rows.Add(dataRow);

                    }
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                    //SqlDatareader.NextResult() is used to move to next result set
                    while (rdr.NextResult())
                    {
                        GridView2.DataSource = rdr;
                        GridView2.DataBind();
                    }
                }
            }

        }
    }
}