<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryString.aspx.cs" Inherits="ControllsDemo.QueryString" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Query String</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="2">Employee Detail</td>
                </tr>
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

                    </td>
                </tr>
                 <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

                    </td>
                </tr>
            </table>
            <br />

            <asp:Button ID="Button1" runat="server" Text="Send Data- Query String" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
