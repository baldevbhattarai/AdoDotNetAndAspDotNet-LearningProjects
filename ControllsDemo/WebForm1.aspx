<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ControllsDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <legend><b>Gender</b></legend>
    <form id="form1" runat="server">
        <asp:RadioButton ID="MaleRadioButton" runat="server" GroupName="GenderGroup" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Male" ToolTip="check if gender is male" />
        <div>
            <asp:RadioButton ID="FemaleRadioButton" runat="server" GroupName="GenderGroup" OnCheckedChanged="FemaleRadioButton_CheckedChanged" Text="Female" />
            <br />
            <asp:RadioButton ID="UnknownRadioButton" runat="server" GroupName="GenderGroup" Text="Unknown" />
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
