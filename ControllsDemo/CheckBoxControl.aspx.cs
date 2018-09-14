using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace ControllsDemo
{
    public partial class CheckBoxControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Write("Page loaded");
            if (!IsPostBack)
            {
                CheckBox3.Focus();
                CheckBox1.Checked = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sbUserChoice = new StringBuilder();
            if (CheckBox1.Checked)
            {
                sbUserChoice.Append(", " +CheckBox1.Text);
            }
            if (CheckBox2.Checked)
            {
                sbUserChoice.Append(", " + CheckBox2.Text);
            }
            if (CheckBox3.Checked)
            {
                sbUserChoice.Append(", " + CheckBox3.Text);

            }
            Response.Write("your selection:" + sbUserChoice.ToString());
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}