<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBoxControl.aspx.cs" Inherits="ControllsDemo.CheckBoxControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <legend>Education<br /></legend>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Deploma" OnCheckedChanged="CheckBox1_CheckedChanged" />
        <asp:CheckBox ID="CheckBox2" runat="server" Text="Bachelor" />
        <asp:CheckBox ID="CheckBox3" runat="server" Text="Masters" />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
