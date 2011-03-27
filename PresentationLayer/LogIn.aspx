<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="PresentationLayer.LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr align="right"><td>Log In</td></tr>
    <tr><td> &nbsp </td></tr>
    <tr align="right"><td>Username: <asp:TextBox ID="username" runat="server"></asp:TextBox></td></tr>
    <tr align="right"><td>Password: <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox></td></tr>
    <tr align="right"><td><asp:Button ID="logIn" runat="server" Text="Login" OnClick="Login" Witdh="100" /></td></tr>
    <tr align="right"><td><br /><br /><div runat="server" ID="message"> &nbsp </div></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
