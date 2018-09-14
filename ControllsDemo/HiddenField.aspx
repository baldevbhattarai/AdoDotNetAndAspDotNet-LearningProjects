<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiddenField.aspx.cs" Inherits="ControllsDemo.HiddenField" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script  type="text/javascript">
  // <[CDATA
        function GetHiddenFieldValue() 
        {
            alert(document.getElementById('HiddenField1').value);
        }
      function button3_click()
        {
        GetHiddenFieldValue();

        }

  //      ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <table>
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender:</td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Department:</td>
                <td>
                    <asp:TextBox ID="txtDept" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Update Employee"
            OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click"
            Text="Load Employee" />
        
        <input id="Button3" type="button" value="button" onclick="button3_click"/></form>
</body>
</html>
