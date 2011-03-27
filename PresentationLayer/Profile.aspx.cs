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
    public partial class Profile : AbstractPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User loggedInUser = GetUserFromCookie();

            if (loggedInUser != null)
            {
                ShowUserProfile(loggedInUser);
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = new HttpCookie("eventnet");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);

            Response.Redirect("Default.aspx");
        }

        private void ShowUserProfile(User user)
        {
            this.username.InnerText = user.Username;
            this.firstname.InnerText = user.Firstname;
            this.lastname.InnerText = user.Lastname;

            List<Event> events = Controller.Instance.GetEvents(user, (byte)1);
            this.OwnEvents.Items.Clear();
            foreach (Event ev in events)
            {
                ListItem li = new ListItem(ev.Name, "WebForm1.aspx?Event=" + ev.Id);
                this.OwnEvents.Items.Add(li);
            }
        }
    }
}