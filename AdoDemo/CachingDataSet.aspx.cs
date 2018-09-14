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
    public partial class CachingDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Check if the DataSet is present in the cache
            if (Cache["Data"] != null)
            {
                // Remove the DataSet from the Cache
                Cache.Remove("Data");
                lblMessage.Text = "DataSet removed from the cache";
            }
            // If the DataSet is not in the Cache
            else
            {
                lblMessage.Text = "There is nothing in the cache to remove";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {
                // If the dataset is not in the cache load data from the database into the DataSet
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(CS))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from tblEmployeees", connection);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);

                    gvEmployeees.DataSource = dataset;
                    gvEmployeees.DataBind();

                    // Store the DataSet in the Cache
                    Cache["Data"] = dataset;
                    lblMessage.Text = "Data loaded from the Database";
                }
            }
            else
            {
                // Retrieve the DataSet from the Cache and type cast to DataSet
                gvEmployeees.DataSource = (DataSet)Cache["Data"];
                gvEmployeees.DataBind();
                lblMessage.Text = "Data loaded from the Cache";
            }
        }
    }
}