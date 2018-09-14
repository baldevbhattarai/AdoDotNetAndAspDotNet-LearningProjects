<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpeningNewWindowUsingJavaScript.aspx.cs" Inherits="ControllsDemo.OpeningNewWindowUsingJavaScript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Training Demo</title>
    <script type="text/javascript">
        // Javascript function to open the new window
        function OpenNewWindow() {
            var Name = document.getElementById('txtName').value;
            var Email = document.getElementById('txtEmail').value;
            window.open('OpeningNewWindowUsingJavaScript2.aspx?Name=' + Name + '&Email=' + Email, '_blank', 'toolbar=no, location=no, resizable=yes,width= 500px, height = 500px', true);
        }
    </script>
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
                <input id="Button1" type="button" value="HTML Input Button - Window.Open" 
                    onclick="OpenNewWindow()" style="width: 300px"
                />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button2" runat="server" 
                    Text="ASP.NET Button - Window.Open()" onclick="Button2_Click" 
                    Width="300px" />
            </td>
        </tr>
        </table>
</div>
    </form>
</body>
</html>
