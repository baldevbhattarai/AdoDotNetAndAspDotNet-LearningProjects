<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlCommandBuilderClass.aspx.cs" Inherits="AdoDemo.SqlCommandBuilderClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
            <table border="1">
                <tr>
                    <td>Student ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtStudentId" runat="Server"></asp:TextBox>
                        <asp:Button ID="btnGetStudent" runat="Server" Text="Load" OnClick="btnGetStudent_Click" />
                    </td>
                </tr>
                <tr>
                    <td>Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtStudentName" runat="Server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="Server">
                            <asp:ListItem Text="Select Gender" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="FeMale" Value="Female"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Total Marks
                    </td>
                    <td>
                        <asp:TextBox ID="ttlMarks" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnUpdata" Text="Update" runat="server" OnClick="btnUpdata_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <b>Insert</b>
                    </td>
                    <td>
                        <asp:Label ID="lblInsert" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Update</b>
                    </td>
                    <td>
                        <asp:Label ID="lblUpdate" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Delete</b>
                    </td>
                    <td>
                        <asp:Label ID="lblDelete" runat="server"></asp:Label>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
