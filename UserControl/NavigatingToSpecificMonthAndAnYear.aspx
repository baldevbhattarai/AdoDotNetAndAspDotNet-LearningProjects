<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NavigatingToSpecificMonthAndAnYear.aspx.cs" Inherits="UserControl.NavigatingToSpecificMonthAndAnYear" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
            Year :
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>&nbsp;
    Month:
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True"
        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>
            <br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
                Text="Get Selected Date" />
        </div>
    </form>
</body>
</html>
