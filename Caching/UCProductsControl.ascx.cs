using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caching
{
    public partial class UCProductsControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // shared= true within outCache directive helps to use same copy of cached UCProductControl for all webpages using this control.
            Label1.Text = DateTime.Now.ToString();

            string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spGetProducts", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            da.Fill(DS);

            GridView1.DataSource = DS;
            GridView1.DataBind();
        }
    }
}