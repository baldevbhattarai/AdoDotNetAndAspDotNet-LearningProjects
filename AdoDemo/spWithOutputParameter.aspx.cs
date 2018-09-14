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
    public partial class spWithOutputParameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);

                SqlParameter outParameter = new SqlParameter();
                outParameter.ParameterName = "@EmployeeId";
                outParameter.SqlDbType = System.Data.SqlDbType.Int;
                outParameter.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(outParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                string EmpId = outParameter.Value.ToString();

                lblMessage.Text = "Employee Id= " + EmpId;


            }
        }
    }
}