using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectCL;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class ViewEvent : AbstractPage
    {
        private Event ev = new Event();
        private User us = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            //In order to access to the events, we use the id specified on the last segment of the url: ViewEvent/"id"
            int id;
           
            string[] aux = (Request.Url.AbsolutePath).Split('/');
            try
            {
                id = Convert.ToInt32(aux[aux.Length - 1]);
                ev = Controller.Instance.GetEvent(id);
                us= GetUserFromCookie();
            }
            catch (FormatException ex)
            {
                errorMessage.InnerHtml = "Wrong URL";
            }
            catch (Exception ex)
            {
                errorMessage.InnerHtml = ex.Message;
            }
            Location loc = new Location("placetext", "coutrytext", "citytext", "addtext");
            List<Location> locations  = new List<Location>();
            locations.Add(loc);
            locations.Add(loc);
            

            locationsView.InnerHtml = "<table border='1'>";
            
            foreach (Location l in locations)
            {
                locationsView.InnerHtml += "<tr><td width='200px'><b>Location: " + l.LocationPlace + "</b><br />"; 
                if (l.Country != "") { locationsView.InnerHtml +="Country: " +  l.Country + "<br />"; }
                if (l.City != "") { locationsView.InnerHtml +="City: "+ l.City + "<br />"; }
                if (l.Address != "") { locationsView.InnerHtml +="Address: "+ l.Address + "<br />"; }
                //GetEvent not implemented so throw and exceotion and dont inicializate de User and Event
                ev.Id = 1;
                us.Id = 1;
                
                if (Controller.Instance.LocationVoted(us, ev))
                {
                    locationsView.InnerHtml += "</td><td aling='center'>ALREADY VOTED</td>";
                }
                else
                {
                    locationsView.InnerHtml += "</td><td aling='center'> <input type='submit' onclick="+"alert('voted')"+" Value='Vote This' /></td>";
                }

                locationsView.InnerHtml += "</tr><tr><br/></tr>";
            }


            locationsView.InnerHtml += "</table>";


        }

        protected void VoteLocation(object sender, EventArgs e)
        {
            Controller.Instance.VoteLocation(us, ev);
            errorMessage.InnerHtml = "voted";
            throw new Exception("bum");
        }
    }
}