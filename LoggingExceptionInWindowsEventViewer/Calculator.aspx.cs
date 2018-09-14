using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoggingExceptionInWindowsEventViewer
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                int FirstNumber = Convert.ToInt32(txtFirstNumber.Text);
                int SecondNumber = Convert.ToInt32(txtSecondNumber.Text);

                lblMessage.ForeColor = System.Drawing.Color.Navy;
                int Result = FirstNumber / SecondNumber;
                lblMessage.Text = Result.ToString();
            }
            catch(DivideByZeroException ex)
            {
                Logger.Log(ex);
                lblMessage.Text = "Divide by Zero Error Occured";

            }
            catch(OverflowException ex)
            {
                Logger.Log(ex, EventLogEntryType.Information);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Numbers must be between " + Int32.MinValue.ToString() + " and " + Int32.MaxValue.ToString();

            }
            catch (FormatException ex)
            {
                Logger.Log(ex, EventLogEntryType.Information);
                 lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Only numbers are allowed";
            }
            catch(Exception ex)
            {
                Logger.Log(ex);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "An unknown problem has occured. Please try later";
            }
        }
    }
}