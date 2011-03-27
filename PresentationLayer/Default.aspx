<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentationLayer.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Event.net</title>
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
    <div id="main">
        
    </div>
    <div id="debugMessage" runat="server">
    
    </div>
</form>
</body>
</html>
