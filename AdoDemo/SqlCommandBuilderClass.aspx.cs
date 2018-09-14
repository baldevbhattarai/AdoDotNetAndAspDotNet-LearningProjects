using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AdoDemo
{
    public partial class SqlCommandBuilderClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //sqlcommandbuilder class basically gererates insert, update and delete sql statement based on select statement for single table.
        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string SqlQuery = "select * from tblStudents where ID = " + txtStudentId.Text;
                SqlDataAdapter da = new SqlDataAdapter(SqlQuery, con);
                DataSet ds = new DataSet();

                da.Fill(ds, "Students");

                ViewState["Data"] = ds;
                ViewState["SqlQuery"] = SqlQuery;
                if (ds.Tables["Students"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["Students"].Rows[0];
                    txtStudentName.Text = dr["Name"].ToString();
                    ttlMarks.Text = dr["TotalMarks"].ToString();
                    ddlGender.SelectedValue = dr["Gender"].ToString();

                }
                else
                {
                    lblMessage.Text = "No Records with Student ID = " + txtStudentId.Text + " Found";
                }
            }
        }

        protected void btnUpdata_Click(object sender, EventArgs e)
        {
            string SqlQuery = "select * from tblStudents where ID = " + txtStudentId.Text;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SqlQuery"], con);

            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            DataSet ds = (DataSet)ViewState["Data"];


            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["Students"].Rows[0];
                dr["Name"] = txtStudentName.Text.ToString();
                dr["Gender"] = ddlGender.SelectedValue.ToString();
                dr["TotalMarks"] = ttlMarks.Text.ToString();
            }
            int rowsUpdated = da.Update(ds, "Students");

            if (rowsUpdated > 0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = rowsUpdated + " row(s) updated.";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "No row updated.";


            }
            lblInsert.Text = builder.GetInsertCommand().CommandText;
            lblUpdate.Text = builder.GetUpdateCommand().CommandText;
            lblDelete.Text = builder.GetDeleteCommand().CommandText;


        }
    }
}