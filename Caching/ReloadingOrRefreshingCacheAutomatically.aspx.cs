using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caching
{
    public partial class ReloadingOrRefreshingCacheAutomatically : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLoadCountriesAndCache_Click(object sender, EventArgs e)
        {
            // Load countries data from XML file into dataset
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));

            // Create an instance of CacheItemRemovedCallback delegate. Notice that this delegate
            // points to CacheItemRemovedCallbackMethod. When cache item is removed 
            // for any   reason
            // the delegate gets invoked, which in turn will invoke the method it is pointing to.
            CacheItemRemovedCallback onCacheItemRemoved =
               new CacheItemRemovedCallback(CacheItemRemovedCallbackMethod);

            // Cache countries dataset. Please note that we are passing the delegate instance as an
            // argument for CacheItemRemovedCallback delegate parameter of the insert() method.
            Cache.Insert("CountriesData", ds, new CacheDependency(Server.MapPath("~/Data/Countries.xml")), DateTime.Now.AddSeconds(60),
                System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, onCacheItemRemoved);

            // Set the dataset as the datasource for the gridview
            gvCountries.DataSource = ds;
            gvCountries.DataBind();
            lblMessage.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrieved from XML file.";
        }

        protected void btnGetCountriesFromCache_Click(object sender, EventArgs e)
        {
            // Check if countries dataset exists in cache
            if (Cache["CountriesData"] != null)
            {
                // If countries dataset is in cache, retrieve it
                DataSet ds = (DataSet)Cache["CountriesData"];
                // Set the dataset as the datasource
                gvCountries.DataSource = ds;
                gvCountries.DataBind();
                // Retrieve the total rows count
                lblMessage.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrieved from cache.";
            }
            else
            {
                lblMessage.Text = "Cache item with key CountriesData is not present in cache";
            }
        }

        protected void btnRemoveCachedItem_Click(object sender, EventArgs e)
        {
            // Remove cached item explicitly
            Cache.Remove("CountriesData");
        }

        // This method gets invoked automatically, whenever the cached item is removed from cache
        public void CacheItemRemovedCallbackMethod(string key, object value, CacheItemRemovedReason reason)
        {
            // Retrieve the key and reason for removal
            string dataToStore = "Cache item with key = \"" + key + "\" is no longer present. Reason = " + reason.ToString();
            // Cache the message
            Cache["CacheStatus"] = dataToStore;

            // ADO.NET code to store the message in database
            // string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            // SqlConnection con = new SqlConnection(cs);
            // SqlCommand cmd = new SqlCommand("insert into tblAuditLog values('" + dataToStore + "')", con);
            // con.Open();
            // cmd.ExecuteNonQuery();
            // con.Close();

            // Reload data into cache
            // DataSet ds = new DataSet();
            // ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));

            // CacheItemRemovedCallback onCacheItemRemoved = new CacheItemRemovedCallback(CacheItemRemovedCallbackMethod);
            // Cache.Insert("CountriesData", ds, new CacheDependency(Server.MapPath("~/Data/Countries.xml")), DateTime.Now.AddSeconds(60),
            //    System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, onCacheItemRemoved);
        }

        protected void btnGetCacheStatus_Click(object sender, EventArgs e)
        {
            if (Cache["CountriesData"] != null)
            {
                lblMessage.Text = "Cache item with key \"CountriesData\" is still present in cache";
            }
            else
            {
                if (Cache["CacheStatus"] != null)
                {
                    lblMessage.Text = Cache["CacheStatus"].ToString();
                }
            }
        }

    }
}