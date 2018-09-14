using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarUserControl1.DateSelectedEvent += new DateSelectedEventHandler(CalendarUserControl1_DateSelectedEvent);


        }

        private void CalendarUserControl1_DateSelectedEvent(object sender, DateSelectedEventArgs e)
        {
            Response.Write("Selected Date:" + e.SelectedDate.ToShortDateString());
        }
    }
}