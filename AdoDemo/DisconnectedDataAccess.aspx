<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisconnectedDataAccess.aspx.cs" Inherits="AdoDemo.DisconnectedDataAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data From DataBase Table" OnClick="btnGetDataFromDB_Click" />
             <asp:Button ID="Button1" runat="server" Text="View State" />
             <asp:Button ID="Button2" runat="server" Text="Undo" OnClick="Button2_Click" />
             <asp:Button ID="Button3" runat="server" Text="AcceptChanges" OnClick="Button3_Click" />


            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" OnRowCancelingEdit="gvStudents_RowCancelingEdit" OnRowDeleting="gvStudents_RowDeleting" OnRowEditing="gvStudents_RowEditing" OnRowUpdating="gvStudents_RowUpdating">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" SortExpression="TotalMarks" />
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
            <br />
           
            <asp:Button ID="btnUpdateDB" runat="server" Text="Update DataBase Table" OnClick="btnUpdateDB_Click" />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>

        </div>

    </form>
</body>
</html>
