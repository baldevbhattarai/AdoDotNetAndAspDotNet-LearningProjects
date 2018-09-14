using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControllsDemo
{
    public partial class Calender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text =  Calendar1.SelectedDate.ToShortDateString();
            foreach (DateTime selectedDateTime in Calendar1.SelectedDates)      
            {
                Response.Write(selectedDateTime.ToShortDateString() + "<br/>");
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if(!e.Day.IsOtherMonth && e.Day.Date.Day % 2 == 0)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ForeColor = System.Drawing.Color.Wheat;
                e.Cell.Text = "x";
                e.Cell.ToolTip = "Booked";

            }
            else
            {
               
                e.Cell.ToolTip = "Available";

            }
        }

        private string GetMonthName(int MonthNumber)
        {
            switch (MonthNumber)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                case 12:
                    return "Dec";
                default:
                    return "Invalid Month";
            }
        }
        protected void Calendar2_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            string newMonth = GetMonthName(e.NewDate.Month);
            string oldMonth = GetMonthName(e.PreviousDate.Month);
            Response.Write("month changed from " + oldMonth + " to " + newMonth);
        }
    }
}