using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ApplicationPool1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Identity used = " +
                System.Security.Principal.WindowsIdentity.GetCurrent().Name + "<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {

                    DataSet ds = new DataSet();
                    ds.ReadXml("C:\\Data\\" + FileUpload1.PostedFile.FileName);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    Label1.Text = "";
                }
                catch (System.UnauthorizedAccessException)
                {
                    Label1.Text = "You do not have access to this file";
                }
                catch (Exception)
                {
                    Label1.Text = "An unexpected error has occured, please contact administrator";
                }
            }
            else
            {
                Label1.Text = "Please select a file first";
            }
        }

    }
}