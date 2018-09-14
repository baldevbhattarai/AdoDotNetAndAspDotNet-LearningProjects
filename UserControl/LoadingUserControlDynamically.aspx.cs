using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class LoadingUserControlDynamically : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarUserControl CUC = (CalendarUserControl) LoadControl("~/UserControls/CalendarUserControl.ascx");
            CUC.ID = "CU1";
            CUC.DateSelectedEvent += new DateSelectedEventHandler( CUC_DateSelectedEvent);
            CUC.CalendarVisibilityChanged += new CalenderVisiablilityChangedEventHandler( CUC_CalendarVisibilityChanged);
            PlaceHolder1.Controls.Add(CUC);
        }

        protected void CUC_CalendarVisibilityChanged(object sender, CalendarVisibilityChangedEventArgs e)
        {
            Response.Write("Calende Visible = " + e.IsCalendarVisible.ToString()+"<br/>");
        }

        protected void CUC_DateSelectedEvent(object sender, DateSelectedEventArgs e)
        {
            Response.Write(e.SelectedDate.ToShortDateString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(((CalendarUserControl)PlaceHolder1.FindControl("CU1")).SelectedDate);
        }
    }

   
}