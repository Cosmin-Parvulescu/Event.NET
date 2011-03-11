<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="TutorialTest.CreateEvent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr align="right"><td>Create New Event</td></tr>
    <tr><td> &nbsp </td></tr>
    <tr align="right"><td>Name: <asp:TextBox ID="eventName" runat="server"></asp:TextBox></td></tr>
    <tr align="right"><td>Location: <asp:TextBox ID="eventLocation" runat="server"></asp:TextBox></td></tr>
    <tr align="right"><td>Date & Time: <asp:TextBox ID="eventTime" runat="server"></asp:TextBox></td></tr>
    <tr align="right"><td><br /><asp:Button ID="createEvent" runat="server" Text="Create Event" Width="100" OnClick="Create"/></td></tr>
    <tr><td><br /><br /><div runat="server" ID="message"> &nbsp </div></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
