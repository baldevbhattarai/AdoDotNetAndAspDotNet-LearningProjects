using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class CalendarUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
            }
        }
        public string SelectedDate
        {
            get
            {
                return txtDate.Text;
            }
            set
            {
                txtDate.Text = value;
            }
        }
        protected void ImgBtn_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
                CalendarVisibilityChangedEventArgs CalendarVisibilityChangedEventData = new CalendarVisibilityChangedEventArgs(false);
                OnCalendarVisibilityChanged(CalendarVisibilityChangedEventData);
            }
            else
            {
                Calendar1.Visible = true;
                CalendarVisibilityChangedEventArgs CalendarVisibilityChangedEventData = new CalendarVisibilityChangedEventArgs(true);
                OnCalendarVisibilityChanged(CalendarVisibilityChangedEventData);
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
            CalendarVisibilityChangedEventArgs CalendarVisibilityChangedEventData = new CalendarVisibilityChangedEventArgs(false);
            OnCalendarVisibilityChanged(CalendarVisibilityChangedEventData);

            DateSelectedEventArgs dateSelectedEventData = new DateSelectedEventArgs(Calendar1.SelectedDate);
            onDateSelected(dateSelectedEventData);
        }
        public event CalenderVisiablilityChangedEventHandler CalendarVisibilityChanged;
        public event DateSelectedEventHandler DateSelectedEvent;

        protected virtual void OnCalendarVisibilityChanged(CalendarVisibilityChangedEventArgs e)
        {
            if (CalendarVisibilityChanged != null)
            {
                CalendarVisibilityChanged(this, e);
            }
        }
        protected virtual void onDateSelected(DateSelectedEventArgs e)
        {
            if (DateSelectedEvent != null)
            {
                DateSelectedEvent(this, e);
            }
        }
    }
    public class CalendarVisibilityChangedEventArgs : EventArgs
    {
        private bool _isCalendarVisible;

        // Constructor to initialize event data
        public CalendarVisibilityChangedEventArgs(bool isCalendarVisible)
        {
            this._isCalendarVisible = isCalendarVisible;
        }

        // Returns true if the calendar is visible otherwise false
        public bool IsCalendarVisible
        {
            get
            {
                return this._isCalendarVisible;
            }
        }
    }
    public class DateSelectedEventArgs : EventArgs
    {
        private DateTime _selectedDate;

        public DateSelectedEventArgs(DateTime selectedDate)
        {
            this._selectedDate = selectedDate;
        }

        public DateTime SelectedDate
        {
            get
            {
                return this._selectedDate;
            }
        }
    }
    public delegate void DateSelectedEventHandler(object sender, DateSelectedEventArgs e);
    public delegate void CalenderVisiablilityChangedEventHandler(object sender, CalendarVisibilityChangedEventArgs e);
}