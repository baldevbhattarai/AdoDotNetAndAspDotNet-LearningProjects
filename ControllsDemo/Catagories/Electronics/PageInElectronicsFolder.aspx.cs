using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace ControllsDemo.Catagories.Electronics
{
    public partial class PageInElectronicsFolder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write(". returns " + Server.MapPath(".") + "<br/>");
                Response.Write(".. returns " + Server.MapPath("..") + "<br/>");
                Response.Write("~ returns " + Server.MapPath("~") + "<br/>");


                DataSet DS = new DataSet();
                string strPhysicalPath = Server.MapPath("~/Countries.xml");
                DS.ReadXml(strPhysicalPath);
                DropDownList1.DataTextField = "CountryName";
                DropDownList1.DataValueField = "CountryId";
                DropDownList1.DataSource = DS;
                DropDownList1.DataBind();

                ListItem li = new ListItem("Select", "-1");
                DropDownList1.Items.Insert(0, li);

                //DropDownList1.SelectedValue = "103";
                //or
                DropDownList1.SelectedIndex = 1;


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue =="-1")
            {
                Response.Write("Select the country");
            }
            else
            {
                Response.Write(DropDownList1.SelectedItem.Text + "<br/>");
                Response.Write(DropDownList1.SelectedItem.Value + "<br/>");
                Response.Write(DropDownList1.SelectedIndex+ "<br/>");


            }
        }
    }
}