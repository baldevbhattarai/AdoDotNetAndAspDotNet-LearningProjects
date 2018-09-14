<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ApplicationPool2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <div>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" 
    Text="Load Data" onclick="Button1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server">
    </asp:Label>
</div>
    </form>
</body>
</html>
