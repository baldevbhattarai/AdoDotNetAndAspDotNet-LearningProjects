<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadingControlsDynamically.aspx.cs" Inherits="UserControl.LoadingControlsDynamically" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem Text="Please Select" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Select City" Value="DDL"></asp:ListItem>
                <asp:ListItem Text="Enter Post Code" Value="TB"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
