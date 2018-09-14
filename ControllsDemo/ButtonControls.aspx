<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonControls.aspx.cs" Inherits="ControllsDemo.ButtonControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" OnClientClick="confirm('Are you sure you want to delete the page?')">LinkButton</asp:LinkButton>
        <br />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="42px" ImageUrl="~/Images/submit-button-png-9.png" OnClick="ImageButton1_Click" OnClientClick="alert(&quot;you are about to submit the page&quot;)" Width="129px" />
    </form>
</body>
</html>
