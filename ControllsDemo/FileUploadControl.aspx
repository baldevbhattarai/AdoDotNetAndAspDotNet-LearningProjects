<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadControl.aspx.cs" Inherits="ControllsDemo.FileUploadControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;<asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click" />
            <br />
        </div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </form>
</body>
</html>
