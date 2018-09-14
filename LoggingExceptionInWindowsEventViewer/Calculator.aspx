<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="LoggingExceptionInWindowsEventViewer.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div style="font-family: Arial">
    <table style="border: 1px solid black">
        <tr>
            <td><b>First Number</b></td>
            <td>
                <asp:TextBox ID="txtFirstNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><b>Second Number</b></td>
            <td>
                <asp:TextBox ID="txtSecondNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnDivide" runat="server" Text="Divide" onclick="btnDivide_Click" 
                    />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
</div>

    </form>
</body>
</html>
