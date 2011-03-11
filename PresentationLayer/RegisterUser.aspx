<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="TutorialTest.HelloWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>        
        <table>
        <tr align="right"><td>Register New User</td></tr>
        <tr><td> &nbsp </td></tr>
        <tr align="right"><td>Username: <asp:TextBox runat="server" ID="username" TextMode="SingleLine"></asp:TextBox></td></tr>
        <tr align="right"><td>Password: <asp:TextBox runat="server" ID="password" TextMode="Password"></asp:TextBox></td></tr>
        <tr align="right"><td>Confirm Password: <asp:TextBox runat="server" ID="pconfirm" TextMode="Password"></asp:TextBox></td></tr>
        <tr align="right"><td><br /><asp:Button runat="server" ID="Register" Text="Register" 
                width="100" onclick="Create" /></td></tr>
        <tr><td><br /><br /><div runat="server" ID="message"> &nbsp </div></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
