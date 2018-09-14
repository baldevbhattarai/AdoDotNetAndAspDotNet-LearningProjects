using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class CrossPagePosting2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrossPagePosting previousPage =  (CrossPagePosting) this.PreviousPage;
            if (previousPage != null && previousPage.IsCrossPagePostBack)
            {
                lblName.Text = previousPage.Name;
                lblEmail.Text = previousPage.Email;

                //lblName.Text = ((TextBox)previousPage.FindControl("txtName")).Text;
                //lblEmail.Text = ((TextBox)previousPage.FindControl("txtEmail")).Text;
            }
            else
            {
                lblStatus.Text = "Landed on this page using a technique other than cross page post back";
            }
        }
    }
}