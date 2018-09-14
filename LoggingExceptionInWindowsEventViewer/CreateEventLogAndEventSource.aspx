<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEventLogAndEventSource.aspx.cs" Inherits="LoggingExceptionInWindowsEventViewer.CreateEventLogAndEventSource" %>

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
                    <td colspan="2">
                        <b>Creating Evnet Log and Event Source</b>

                    </td>
                </tr>
            
                <tr>
                    <td>
                        <b>Event Log Name</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEventLogName" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Event Log Source</b>

                    </td>
                    <td>
                        <asp:TextBox ID="txtEventLogSource" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnCreateEventNameAndSource" runat="server" Text="Create Event Name And Source" OnClick="btnCreateEventNameAndSource_Click" />

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>

            <asp:LinkButton ID="lbtnGoToCalculator" runat="server" Enabled="False" OnClick="lbtnGoToCalculator_Click">Go To Calculator</asp:LinkButton>
        </div>
    </form>
</body>
</html>
