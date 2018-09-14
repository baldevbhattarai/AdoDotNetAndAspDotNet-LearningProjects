using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class CheckBoxListAndListBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckBoxList1.SelectedIndex = -1;
                lblMessage.ForeColor = System.Drawing.Color.Red;

                lblMessage.Text = ListBox1.Items.Count + " Item(s) Selected.";

            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected)
                {
                    ListBox1.Items.Add(li.Text);
                }
                
            }

            if (CheckBoxList1.SelectedIndex == -1)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ListBox1.Items.Count + " Item(s) Selected.";

            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;

                lblMessage.Text = ListBox1.Items.Count + " Item(s) Selected.";

            }
        }

        protected void CountriesBulletedList_Click(object sender, BulletedListEventArgs e)
        {
            ListItem li = CountriesBulletedList.Items[e.Index];
            Response.Write("Text = " + li.Text + "<br/>");
            Response.Write("Value = " + li.Value + "<br/>");
            Response.Write("Index = " + e.Index.ToString());
        }
    }
}