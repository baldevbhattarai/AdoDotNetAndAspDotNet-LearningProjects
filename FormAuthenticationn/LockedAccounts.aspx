<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LockedAccounts.aspx.cs" Inherits="FormAuthenticationn.LockedAccounts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <asp:GridView ID="gvLockedAccounts" runat="server" AutoGenerateColumns="False" style="margin-top: 17px" OnRowCommand="gvLockedAccounts_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="LockedDateTime" HeaderText="Locked Time" />
                    <asp:BoundField DataField="HoursElapsed" HeaderText="Hours Elapsed" />
                    <asp:TemplateField HeaderText="Enable">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server"  commandArgument='<%#Eval("UserName") %>'
                                Enabled='<%#Convert.ToInt32(Eval("HoursElapsed")) > 24%>' Text="Enable"/> 

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
