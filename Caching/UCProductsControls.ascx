<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductsControls.ascx.cs" Inherits="Caching.UCProductsControls" %>
<%--<%@ OutputCache Duration="60" VaryByControl="DropDownList1" %>--%>
<table style="border: 1px solid black">
    <tr>
        <td style="background-color: Gray; font-size: 12pt">
            Products User Control
        </td>
    </tr>
    <tr>
        <td>
            Select Product:
            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                <asp:ListItem Text="Laptops" Value="Laptops"></asp:ListItem>
                <asp:ListItem Text="iPhone" Value="iPhone"></asp:ListItem>
                <asp:ListItem Text="LCD TV" Value="LCD TV"></asp:ListItem>
                <asp:ListItem Text="Desktop" Value="Desktop"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <b>User Control Server Time:
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </b>
        </td>
    </tr>
    <tr>
        <td>
            <b>User Control Client Time:
                <script type="text/javascript">
                    document.write(Date());
                </script>
            </b>
        </td>
    </tr>
</table>