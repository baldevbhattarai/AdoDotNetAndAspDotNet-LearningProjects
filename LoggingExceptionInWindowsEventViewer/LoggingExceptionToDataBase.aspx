<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggingExceptionToDataBase.aspx.cs" Inherits="LoggingExceptionInWindowsEventViewer.LoggingExceptionToDataBase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border:4px">
            
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Label ID="lblMessagee" runat="server"></asp:Label>
        </div>
        

    </form>
</body>
</html>
