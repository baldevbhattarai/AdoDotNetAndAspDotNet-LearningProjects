<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBoxListAndListBox.aspx.cs" Inherits="ControllsDemo.CheckBoxListAndListBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            <asp:ListItem Text="Deploma" Value="1"></asp:ListItem>
            <asp:ListItem Text="Graduate" Value="2"></asp:ListItem>
            <asp:ListItem Text="Post Graduate" Value="3"></asp:ListItem>
            <asp:ListItem Text="Doctrate" Value="4"></asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="103px" Width="89px" SelectionMode="Multiple"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <asp:BulletedList ID="BulletedList1" runat="server"
            BulletStyle="Numbered" DisplayMode="HyperLink">
            <asp:ListItem Text="Google" Value="http://google.com"></asp:ListItem>
            <asp:ListItem Text="Youtube" Value="http://Youtube.com"></asp:ListItem>
            <asp:ListItem Text="Blogger" Value="http://Blooger.com"></asp:ListItem>
            <asp:ListItem Text="Gmail" Value="http://Gmail.com"></asp:ListItem>
        </asp:BulletedList>

        <asp:BulletedList ID="CountriesBulletedList" runat="server"
            DisplayMode="LinkButton" OnClick="CountriesBulletedList_Click">
            <asp:ListItem Text="Google" Value="1"></asp:ListItem>
            <asp:ListItem Text="Microsoft" Value="2"></asp:ListItem>
            <asp:ListItem Text="Dell" Value="3"></asp:ListItem>
            <asp:ListItem Text="IBM" Value="4"></asp:ListItem>
        </asp:BulletedList>
    </form>
</body>
</html>
