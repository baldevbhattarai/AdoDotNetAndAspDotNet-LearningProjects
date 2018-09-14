using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarUserControl1.CalendarVisibilityChanged += new CalenderVisiablilityChangedEventHandler(CalendarUserControl1_CalendarVisibilityChanged);

        }

        private void Button1_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CalendarUserControl1_CalendarVisibilityChanged(object sender, CalendarVisibilityChangedEventArgs e)
        {
            Response.Write("Calendar Visible = " + e.IsCalendarVisible.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(CalendarUserControl1.SelectedDate);
        }
      
    }
}