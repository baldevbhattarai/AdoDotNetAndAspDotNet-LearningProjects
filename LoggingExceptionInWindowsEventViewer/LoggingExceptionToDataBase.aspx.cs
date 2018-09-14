using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LoggingExceptionInWindowsEventViewer
{
    public partial class LoggingExceptionToDataBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                DataSet ds = new DataSet();
               ds.ReadXml(Server.MapPath("~/Data.xml"));
               GridView1.DataSource = ds;
               GridView1.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    Logger.Log(ex);
            //    lblMessagee.Text = "Data.xml file is not found.";
            //}
        }
        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();
        //    if (ex != null)
        //    {
        //        //Logger.Log(ex);
        //        Server.ClearError();
        //        Server.Transfer("~/Error.aspx");
        //    }
        //}

    }
}