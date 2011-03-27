<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="PresentationLayer.CreateEvent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">table{ width:600px;}</style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="pageLinks">
        
    </div>

    <div id="main">

        <div id="divName">
            <table align="center">
                <tr><td colspan="3">CREATE EVENT</td></tr>
                <tr><td> &nbsp </td></tr>
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="eventName" runat="server" Width="300"></asp:TextBox></td>
                </tr>
            </table>
        </div>

        <div id="viewLoc" runat="server"> &nbsp </div>

        <div id="locationsDiv">
            <table align="center">                
                <tr>
                    <td>Location:</td>
                    <td><asp:TextBox ID="locationName" runat="server" Width="300"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Country:</td>
                    <td><asp:TextBox ID="country" runat="server" Width="300"></asp:TextBox> (optional)</td>
                </tr>

                <tr>
                    <td>City:</td>
                    <td><asp:TextBox ID="city" runat="server" Width="300"></asp:TextBox> (optional)</td>
                </tr>

                <tr>
                    <td>Address:</td>
                    <td><asp:TextBox ID="addressA" runat="server" Width="300"></asp:TextBox> (optional)</td>                
                </tr>

                <tr>
                    <td> &nbsp </td>
                    <td><asp:TextBox ID="addressB" runat="server" Width="300"></asp:TextBox></td>
                </tr>

                <tr>
                    <td> &nbsp </td>
                    <td><asp:Button ID="addLocation" runat="server" Text="Add Location" OnClick="AddLocation" /></td>               
                </tr>
                <tr><td> &nbsp </td></tr>
            </table>
        </div>

        <div id="viewD" runat="server"> &nbsp </div>

        <div>
            <table align="center">
                <tr>
                    <td>Date:</td>
                    <td><asp:TextBox ID="date" runat="server" Width="150"></asp:TextBox> <asp:Button ID="addDate" runat="server" Text="Add Another Date" OnClick="AddDate"/></td>
                </tr>
                <tr><td> &nbsp </td></tr>
            </table>
        </div>

        <div id="viewT" runat="server"> &nbsp </div>

        <div>
            <table align="center">
                <tr>
                    <td>Time:</td>
                    <td><asp:TextBox ID="time" runat="server" Width="150"></asp:TextBox> <asp:Button ID="addTime" runat="server" Text="Add Another Time" OnClick="AddTime" /></td>
                </tr>
            </table>
        </div>

        <div>
            <table align="center">
                <tr><td colspan="3"><div id="tip">*in order to take advantage of all the features we suggest to fill in the optional fields also.</div></td></tr>
                <tr><td colspan="3" align = "right"><asp:Button ID="CreateEventButton" runat="server" Text="Create Event" OnClick="Create" /></td></tr>
            </table>
        </div>
    </div>

    <div id="debugMessage" runat="server"> <b>Debug:</b><br />
    </div>
    </form>
</body>
</html>
