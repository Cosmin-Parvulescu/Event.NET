<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="PresentationLayer.EditProfil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Profile</title>

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

    <div id="main" >
        <h1>Edit details</h1>
        <h3>Account</h3>
        <table>
            <tr>
                <td>E-Mail: </td>
                <td><asp:TextBox runat="server" ID="EMail" TextMode="SingleLine" validation="email" onblur="validate(this);">asdfdasf</asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>Password: </td>
                <td><asp:TextBox runat="server" ID="Password" TextMode="Password" validation="password" onblur="validate(this);">sadfasdf</asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>Confirm password: </td>
                <td><asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" validation="passwordConfirm" onblur="validate(this);"></asp:TextBox></td>
                <td></td>
            </tr>
        </table>

        <h3>Profile</h3>
        <table>
            <tr>
                <td>First name: </td>
                <td><asp:TextBox runat="server" ID="FirstName" TextMode="SingleLine" validation="lettersOnly" onblur="validate(this);"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>Last name: </td>
                <td><asp:TextBox runat="server" ID="LastName" TextMode="SingleLine" validation="lettersOnly" onblur="validate(this);"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>About me: </td>
                <td><asp:TextBox runat="server" ID="AboutMe" TextMode="MultiLine" Rows="5"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>Features: </td>
                <td>
                    <asp:CheckBox ID="FullNameCB" runat="server" Text="Show full name" /><br />
                    <asp:CheckBox ID="EmailCB" runat="server" Text="Show e-mail" /><br />
                    <asp:CheckBox ID="MyEventsCB" runat="server" Text="Show my events" /><br />
                    <asp:CheckBox ID="AttendingEventsCB" runat="server" Text="Show events I attend" /><br />
                </td>
                <td></td>
            </tr>
        </table>
        <br />
        <asp:Button runat="server" ID="Update" Text="Save" onclick="UpdateDetails" 
            Width="100px" /> &nbsp;&nbsp;
        <asp:Button runat="server" ID="Cancel" Text="Cancel" onclick="CancelUpdate" 
            Width="100px" />      
    </div>

    <div id="debugMessage" runat="server">

    </div>
</form>
</body>
</html>
