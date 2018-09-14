using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class CrossPagePosting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this program is not working correctly.
        }
        
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/CrossPagePosting2.aspx");
        }

        protected void btnCrossPagePostback_Click(object sender, EventArgs e)
        {

        }

        public string Name
        {
            get
            {
                return txtName.Text;
            }
        }
        //Email - read only property
        public string Email
        {
            get
            {
                return txtEmail.Text;
            }
        }
    }
}