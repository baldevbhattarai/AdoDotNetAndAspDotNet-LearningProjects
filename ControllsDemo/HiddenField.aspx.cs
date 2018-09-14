using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
    

namespace ControllsDemo
{
    public partial class HiddenField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployee();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string sqlQuery = "Update Employees set Name=@Name, Gender=@Gender, DepartmentId=@DeptId where ID=@Id";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                cmd.Parameters.AddWithValue("@DeptId", txtDept.Text);
                cmd.Parameters.AddWithValue("@Id", HiddenField1.Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                txtName.Text = "";
                txtDept.Text = "";
                txtGender.Text = "";
            }
        }
        private void LoadEmployee()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string sqlQuery = "Select ID, Name, Gender, DepartmentId from Employees where ID=2";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        txtName.Text = rdr["Name"].ToString();
                        txtGender.Text = rdr["Gender"].ToString();
                        txtDept.Text = rdr["DepartmentId"].ToString();
                        HiddenField1.Value = rdr["ID"].ToString();
                    }
                }
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            LoadEmployee();

        }
    }
}