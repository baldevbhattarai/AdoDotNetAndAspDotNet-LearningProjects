<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDownListwithDB.aspx.cs" Inherits="ControllsDemo.DropDownListwithDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DropDownList ID="DropDownList1" DataTextField="Name" DataValueField ="ID" runat="server">
        </asp:DropDownList>
    </form>
</body>
</html>
