using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ControllsDemo
{
    public partial class DropDownListwithDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select ID, Name, Salary from tblEmployee", con);
                con.Open();
                DropDownList1.DataSource = cmd.ExecuteReader();
                //specifying DataTextField and DataValueField can be done for html section as well

                //DropDownList1.DataTextField = "Name";
                //DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();

            }

        }
    }
}