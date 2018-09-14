<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StronglyTypedDataSet.aspx.cs" Inherits="AdoDemo.StronglyTypedDataSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Get Data" OnClick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>
