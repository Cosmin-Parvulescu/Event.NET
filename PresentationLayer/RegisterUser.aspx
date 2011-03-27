<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="PresentationLayer.RegisterUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register User</title>

    <script src="javascript/Validation.js" type="text/javascript" language="javascript"></script>
</head>
<body>
<form id="form1" runat="server">
    <div id="pageLinks" ... >
        <a href="Default.aspx">Default</a> | 
        <a href="RegisterUser.aspx">RegisterUser</a> | 
        <a href="LogIn.aspx">LogIn</a> |
        <a href="Profile.aspx">Profile</a> |
        <a href="EditProfile.aspx">EditProfile</a> |
        <a href="CreateEvent.aspx">CreateEvent</a>
    </div>
    <div id="main" ...>  
        <table>
        <tr align="right"><td>Register New User</td></tr>
        <tr><td> &nbsp </td></tr>
        <tr align="right">
            <td>Username: <asp:TextBox runat="server" ID="username" TextMode="SingleLine" validation="username" onblur="validate(this);"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr align="right"><td>Password: <asp:TextBox runat="server" ID="password" TextMode="Password" validation="password" onblur="validate(this);"></asp:TextBox></td><td></td></tr>
        <tr align="right"><td>Confirm Password: <asp:TextBox runat="server" ID="pconfirm" TextMode="Password" validation="passwordConfirm" onblur="validate(this);"></asp:TextBox></td><td></td></tr>
        <tr align="right"><td>First name: <asp:TextBox runat="server" ID="firstname" TextMode="SingleLine" validation="lettersOnly" onblur="validate(this);"></asp:TextBox></td><td></td></tr>
        <tr align="right"><td>Last name: <asp:TextBox runat="server" ID="lastname" TextMode="SingleLine" validation="lettersOnly" onblur="validate(this);"></asp:TextBox></td><td></td></tr>
        <tr align="right"><td>E-Mail: <asp:TextBox runat="server" ID="email" TextMode="SingleLine" validation="email" onblur="validate(this);"></asp:TextBox></td><td></td></tr>
        <tr align="right"><td><br /><asp:Button runat="server" ID="Register" Text="Register" width="100" onclick="Create" /></td></tr>
        </table>
    </div>
    <div id="debugMessage"  runat="server">
    
    </div>
</form>
</body>
</html>
