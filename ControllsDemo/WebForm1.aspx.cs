using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (MaleRadioButton.Checked )
            {
                Response.Write("your Gender is " + MaleRadioButton.Text + "<br/>");
            }
           else if (FemaleRadioButton.Checked )
            {
                Response.Write("your Gender is " + FemaleRadioButton.Text + "<br/>");
            }
           else if (UnknownRadioButton.Checked)
            {
                Response.Write("your Gender is " + UnknownRadioButton.Text + "<br/>");
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("Male Radio Button selection Changed <br/>");
        }

        protected void FemaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}