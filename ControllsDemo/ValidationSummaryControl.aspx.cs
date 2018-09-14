using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class ValidationSummaryControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Data Saved.";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;

                lblStatus.Text = "Data is not Saved.";

            }

        }
    }
}