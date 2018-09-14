<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CascadingDropDown.aspx.cs" Inherits="ControllsDemo.CascadingDropDown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DropDownList ID="ddlContinents" runat="server" OnSelectedIndexChanged="ddlContinents_SelectedIndexChanged"
            DataTextField="ContinentName" DataValueField ="ContinentId" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <br />
        <asp:DropDownList ID="ddlCountries" runat="server" DataTextField="CountryName" DataValueField ="CountryId" AutoPostBack="true" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:DropDownList ID="ddlCities" runat="server" DataTextField="CityName" DataValueField ="CityId" >
          
        </asp:DropDownList>
    </form>
</body>
</html>
