using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace AnonymousAuthenticationAnd_Asp.netImpersonation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Application code executed using ");
            Response.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name + "<br/>");

            Response.Write("Is User Authenticated: ");
            Response.Write(User.Identity.IsAuthenticated.ToString() + "<br/>");

            Response.Write("Authentication Type, if Authenticated: ");
            Response.Write(User.Identity.AuthenticationType + "<br/>");

            Response.Write("User Name, if Authenticated: ");
            Response.Write(User.Identity.Name + "<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("C:\\Data\\Countries.xml");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}