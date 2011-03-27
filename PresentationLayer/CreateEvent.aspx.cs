using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using ObjectCL;

namespace PresentationLayer
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String username;
            HttpCookie cookie = Request.Cookies["eventnet"];
            User u = new User();
            if (cookie == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                username = cookie["eventnet-username"].ToString();               
                u.Username = username;
                if(!Controller.Instance.UserExists(u))Response.Redirect("LogIn.aspx");
            }
        }
        
        protected void AddLocation(object sender, EventArgs e)
        {
            List<Location> locations = new List<Location>();           

            if (Session["Locations"] != null)
            {
                locations = (List<Location>)(Session["Locations"]);                
            }

            locations.Add(new Location(locationName.Text, country.Text, city.Text, addressA.Text + " " + addressB.Text));
            Session["Locations"] = locations;

            viewLocations();
        }

        protected void AddDate(object sender, EventArgs e)
        {
            List<String> dates = new List<String>();
            if (Session["Dates"] != null)
            {
                dates = (List<String>)(Session["Dates"]);
            }
            dates.Add(date.Text);
            Session["Dates"] = dates;

            viewDates();
        }

        protected void AddTime(object sender, EventArgs e)
        {
            List<String> times = new List<String>();
            if (Session["Times"] != null)
            {
                times = (List<String>)(Session["Times"]);
            }
            times.Add(time.Text);
            Session["Times"] = times;

            viewTimes();
        }

        private void viewLocations()
        {
            if (Session["Locations"] != null)
            {
                List<Location> locations = (List<Location>)(Session["Locations"]);
                int i = 0;

                viewLoc.InnerHtml = "<table align='center'><tr><td> &nbsp </td>";

                foreach (Location l in locations)
                {
                    viewLoc.InnerHtml += "<td width='200px' bgcolor='#EEEEEE'><b>" + l.LocationPlace + "</b><br />" + l.Country + "<br />" + l.City + "<br />" + l.Address + "</td>";
                    i++;
                    if (i % 3 == 0) viewLoc.InnerHtml += "</tr><tr><td> &nbsp </td>";
                }

                viewLoc.InnerHtml += "</tr></table>";
            }
        }

        private void viewDates()
        {
            if (Session["Dates"] != null)
            {
                List<String> dates = (List<String>)(Session["Dates"]);
                int i = 0;

                viewD.InnerHtml = "<table align='center'><tr>";

                foreach (String l in dates)
                {
                    viewD.InnerHtml += "<td width='50px' bgcolor='#EEEEEE'>" + l.ToString() + "</td>";
                    i++;
                    if (i % 6 == 0) viewD.InnerHtml += "</tr><tr>";
                }

                viewD.InnerHtml += "</tr></table>";
            }
        }

        private void viewTimes()
        {
            if (Session["Times"] != null)
            {
                List<String> times = (List<String>)(Session["Times"]);
                int i = 0;

                viewT.InnerHtml = "<table align='center'><tr>";

                foreach (String l in times)
                {
                    viewT.InnerHtml += "<td width='50px' bgcolor='#EEEEEE'>" + l.ToString() + "</td>";
                    i++;
                    if (i % 6 == 0) viewT.InnerHtml += "</tr><tr>";
                }

                viewT.InnerHtml += "</tr></table>";
            }
        }
        protected void Create(object sender, EventArgs e)
        {
            String username;
            HttpCookie cookie = Request.Cookies["eventnet"];
            User u = new User();
            Event eve = new Event();

            username = cookie["eventnet-username"].ToString();               
            u.Username = username;

            eve.Locations = (List<Location>)(Session["Locations"]);
            eve.Dates = (List<String>)(Session["Dates"]);
            eve.Times = (List<String>)(Session["Times"]);
            eve.Admin = u;

            Controller.Instance.CreateEvent(eve);

            Session.Clear();
        }
    }
}