<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryString2.aspx.cs" Inherits="ControllsDemo.QueryString2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Query String2</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                 <tr>
                    <td >
                       <b> Retrieving Employee Info</b>
                    </td>
                   
                </tr>
               


                <tr>
                    <td >
                       <b> Name: </b>
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server" ></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                       <b>Email:</b> 
                    </td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
