<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PresentationLayer.Profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>

    <style type="text/css">
        .slideHeader{	/* Styling question */
	        cursor:pointer;
        }
        .slideContainer{	/* Parent box of slide down content */
	        visibility: hidden;
	        height:1px; 
	        overflow:hidden;
	        position:relative;
	        display:none;
        }
        .slideContent{	/* Content that is slided down */
	        padding:1px;
	        position:relative;
        }
    </style>

    <script src="javascript/Sliding.js" type="text/javascript" language="javascript"></script>
</head>
<body onload="showHideContent('slideHeader_myEvents');">
<form id="form1" runat="server">
    <div id="pageLinks" ... >
        <a href="Default.aspx">Default</a> | 
        <a href="RegisterUser.aspx">RegisterUser</a> | 
        <a href="LogIn.aspx">LogIn</a> |
        <a href="Profile.aspx">Profile</a> |
        <a href="EditProfile.aspx">EditProfile</a> |
        <a href="CreateEvent.aspx">CreateEvent</a> | 
        <asp:LinkButton ID="Logout" runat="server" onclick="Logout_Click">Logout</asp:LinkButton>
    </div>
    <div id="main" ...> 
        <h1>Hello <span runat="server" id="username">Username</span>!</h1>
        <hr />
        <a href="EditProfile.aspx">Edit details</a><br />
        <table>
            <tr>
                <td>First name: </td>
                <td runat="server" id="firstname">first name of user</td>
            </tr>
            <tr>
                <td>Last name: </td>
                <td runat="server" id="lastname">last name of user</td>
            </tr>
        </table>
        <hr />
        <div class="slideHeader" id="slideHeader_myEvents" onclick="showHideContent(this.id);">
            <h3>My events</h3>
        </div>
        <div class="slideContainer" id="slideContainer_myEvents">
            <div class="slideContent" id="slideContent_myEvents">
                <asp:BulletedList ID="OwnEvents" runat="server" DisplayMode="HyperLink">
                    <asp:ListItem>asdfsdf</asp:ListItem>
                </asp:BulletedList>
            </div>
        </div>
    </div>
    <div id="debugMessage" runat="server">
    
    </div>
</form>    
</body>
</html>
