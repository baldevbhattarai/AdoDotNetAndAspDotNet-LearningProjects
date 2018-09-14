using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace LoggingExceptionInWindowsEventViewer
{
    public partial class CreateEventLogAndEventSource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateEventNameAndSource_Click(object sender, EventArgs e)
        {
            if (txtEventLogName.Text != string.Empty && txtEventLogSource.Text != string.Empty)
            {
                if (!EventLog.SourceExists(txtEventLogSource.Text))
                { 
                EventLog.CreateEventSource(txtEventLogSource.Text, txtEventLogName.Text);
                    Session["EventSource"] = txtEventLogSource.Text;
                    Session["EventName"] = txtEventLogName.Text;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Event Log and Event Source created successfully.";
                }

                lbtnGoToCalculator.Enabled = true;
               
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Please Enter Both Event Name and Event Source.";
            
            }
        }

        protected void lbtnGoToCalculator_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Calculator.aspx");
        }
    }
}