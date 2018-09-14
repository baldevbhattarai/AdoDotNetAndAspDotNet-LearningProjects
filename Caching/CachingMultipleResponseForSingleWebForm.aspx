<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CachingMultipleResponseForSingleWebForm.aspx.cs" Inherits="Caching.CachingMultipleResponseForSingleWebForm" %>
<%@ OutputCache Duration="60" varyByParam="DropDownList1"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Caching multiple Response in single webform</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
            Select Product: 
    <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Text="All" Value="All"></asp:ListItem>
        <asp:ListItem Text="Laptops" Value="Laptops"></asp:ListItem>
        <asp:ListItem Text="iPhone" Value="iPhone"></asp:ListItem>
        <asp:ListItem Text="LCD TV" Value="LCD TV"></asp:ListItem>
        <asp:ListItem Text="Desktop" Value="Desktop"></asp:ListItem>
    </asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            Server Time: 
    <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            Client Time:
    <script type="text/javascript">
        document.write(Date());
    </script>
        </div>

    </form>
</body>
</html>
