<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrossPagePosting.aspx.cs" Inherits="ControllsDemo.CrossPagePosting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div style="font-family: Arial">
    <table>
        <tr>
            <td colspan="2">
                <h1>
                    This is WebForm1</h1>
            </td>
        </tr>
        <tr>
            <td>
                <b>Name</b>
            </td>
            <td>
                :<asp:TextBox ID="txtName" runat="server">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <b>Email</b>
            </td>
            <td>
                :<asp:TextBox ID="txtEmail" runat="server">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnCrossPagePostback" runat="server" 
                Text="Cross Page Postback - WebForm2" 
                Width="250px" PostBackUrl="~/CrossPagePosting2.aspx" OnClick="btnCrossPagePostback_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Server.Transfer - WebForm2" Width="250px" />
            </td>
        </tr>
        </table>
</div>

    </form>
</body>
</html>
