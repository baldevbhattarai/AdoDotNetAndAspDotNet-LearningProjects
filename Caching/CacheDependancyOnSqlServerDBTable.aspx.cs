using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caching
{
    public partial class CacheDependancyOnSqlServerDBTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGetData_Click(object sender, EventArgs e)
        {
            // Check if the DataSet is present in cache
            if (Cache["ProductsData"] != null)
            {
                // If data available in cache, retrieve and bind it to gridview control
                gvProducts.DataSource = Cache["ProductsData"];
                gvProducts.DataBind();

                lblStatus.Text = "Data retrieved from cache @ " + DateTime.Now.ToString();
            }
            else
            {
                // Read connection string from web.config file
                string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

                // Enable change notifications on the database, 
                // so that when the data changes the cached item will be removed
                System.Web.Caching.SqlCacheDependencyAdmin.EnableNotifications(CS);
                // Enable change notifications on the database table, 
                // so that when the data changes the cached item will be removed
                System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(CS, "tblProducts");

                SqlConnection con = new SqlConnection(CS);
                SqlDataAdapter da = new SqlDataAdapter("select * from tblProducts", con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Build SqlCacheDependency object using the database and table names
                SqlCacheDependency sqlDependency = new SqlCacheDependency("Sample1", "tblProducts");

                // Pass SqlCacheDependency object, when caching data
                Cache.Insert("ProductsData", ds, sqlDependency);

                gvProducts.DataSource = ds;
                gvProducts.DataBind();
                lblStatus.Text = "Data retrieved from database @ " + DateTime.Now.ToString();
            }
        }
    }
}