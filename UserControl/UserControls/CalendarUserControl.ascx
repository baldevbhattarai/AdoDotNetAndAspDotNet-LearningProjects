<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarUserControl.ascx.cs" Inherits="UserControl.CalendarUserControl" %>
<asp:TextBox ID="txtDate" runat="server" Width="115px"></asp:TextBox>
<asp:ImageButton ID="ImgBtn" runat="server" 
    ImageUrl="~/Images/Calendar.jpg" onclick="ImgBtn_Click" Height="18px" style="margin-top: 0px" Width="26px" />
<asp:Calendar ID="Calendar1" runat="server" onselectionchanged="Calendar1_SelectionChanged">
</asp:Calendar>
