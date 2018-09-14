using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace AdoDemo
{
    public partial class DisconnectedDataAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetDataFromDB()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string SQL_QUERY = "select * from tblStudents";
            SqlDataAdapter da = new SqlDataAdapter(SQL_QUERY, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Students");

            ds.Tables["Students"].PrimaryKey = new DataColumn[] { ds.Tables["Students"].Columns["ID"] } ;

            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

            gvStudents.DataSource = ds;
            gvStudents.DataBind();

            lblMessage.Text = "Data Loaded From DataBase";
        }

        private void GetDataFromCache()
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                gvStudents.DataSource = ds;
                gvStudents.DataBind();
                lblMessage.Text = "Data Loaded From Cache";
            }
        }

        protected void btnGetDataFromDB_Click(object sender, EventArgs e)
        {
            GetDataFromDB();
        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudents.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }

        protected void gvStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
                dr["Name"] = e.NewValues["Name"];
                dr["Gender"] = e.NewValues["Gender"];
                dr["TotalMarks"] = e.NewValues["TotalMarks"];

                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                gvStudents.EditIndex = -1;
                GetDataFromCache();
            }
        }

        protected void gvStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudents.EditIndex = -1;
            GetDataFromCache();
        }

        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);

                dr.Delete();
                
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                gvStudents.EditIndex = -1;
                GetDataFromCache();
            }
        }

        protected void btnUpdateDB_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string SQL_QUERY = "select * from tblStudents";
            SqlDataAdapter da = new SqlDataAdapter(SQL_QUERY, con);

            DataSet ds = (DataSet)Cache["DATASET"];

            string strUpdateCommand = "Update tblStudents set Name = @Name, Gender = @Gender, TotalMarks = @TotalMarks where ID = @Id";
        
            SqlCommand updateCommand = new SqlCommand(strUpdateCommand, con);
            updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            updateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 50, "Gender");
            updateCommand.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
            updateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "ID");

            da.UpdateCommand = updateCommand;


            string strDeleteCommand = "Delete from tblStudents  where ID = @Id";
        
            SqlCommand deleteCommand = new SqlCommand(strDeleteCommand, con);
            deleteCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "ID");
            da.DeleteCommand = deleteCommand;

            da.Update(ds, "Students");

            lblMessage.Text = "DataBase Table has been Updated";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dataRow = ds.Tables["Students"].NewRow();
            dataRow["ID"] = "101";
          //  ds.Tables["Students"].Rows.Add(dataRow);

            foreach (DataRow dr in ds.Tables["Students"].Rows)
            {
                if(dr.RowState == DataRowState.Deleted)
                {
                    Response.Write(dr["ID", DataRowVersion.Original].ToString() +  "," + dr.RowState.ToString()+"<br/>");
                }
                else
                {
                    Response.Write(dr["ID"].ToString() + "," + dr.RowState.ToString()+ "<br/>");

                }
            

            }
            Response.Write(dataRow.RowState.ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            if (ds.HasChanges())
            {
                ds.RejectChanges();
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GetDataFromCache();
                lblMessage.Text = " Changes Undone";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {

                lblMessage.Text = " No Data to Undo";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //revise one more time, Acceptchanges is hard to grasp
            //what is the proper use of acceptchange??
            DataSet ds = (DataSet)Cache["DATASET"];
            ds.AcceptChanges();
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            GetDataFromCache();
        }
    }
}