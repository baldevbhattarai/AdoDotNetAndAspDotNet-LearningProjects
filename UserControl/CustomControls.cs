﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControls
{
    // Specifies the default tag to generate for our CustomCalendar control 
    // when it is dragged from visual studio toolbox on to the webform 
    [ToolboxData("<{0}:CustomCalendar runat=server></{0}:CustomCalendar>")]
    // All composite custom controls inheirt from the base CompositeControl class 
    // that contains all the common functionality needed by all composite controls.
    public class CustomCalendar : CompositeControl
    {
        // Child controls required by the CustomCalendar control
        TextBox textBox;
        ImageButton imageButton;
        Calendar calendar;

        // All child controls are required to be created by overriding 
        // CreateChildControls method inherited from the base Control class
        // CompositeControl inherits from WebControl and WebControl class
        // inherits from Control class
        protected override void CreateChildControls()
        {
            Controls.Clear();

            textBox = new TextBox();
            textBox.ID = "dateTextBox";
            textBox.Width = Unit.Pixel(80);

            imageButton = new ImageButton();
            imageButton.ID = "calendarImageButton";

            calendar = new Calendar();
            calendar.ID = "calendarControl";

            // Add Child controls to CustomCalendar control
            this.Controls.Add(textBox);
            this.Controls.Add(imageButton);
            this.Controls.Add(calendar);
        }

        // Render the child controls using HtmlTextWriter object
        protected override void Render(HtmlTextWriter writer)
        {
            textBox.RenderControl(writer);
            imageButton.RenderControl(writer);
            calendar.RenderControl(writer);
        }
    }
}