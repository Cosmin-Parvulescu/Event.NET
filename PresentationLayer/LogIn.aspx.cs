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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        protected void Login(object sender, EventArgs e)
        {
            User us;

            if ((username.Text != "") && (password.Text != ""))
            {
                us = new User();
                us.Username = username.Text;
                us.Password = password.Text;
                Controller.Instance.LogIn(us);
                
           
                HttpCookie cookie = new HttpCookie("eventnet");
                Response.Cookies.Add(cookie);
                cookie["eventnet-username"] = username.Text;
                cookie.Expires = DateTime.Now.AddMonths(1);

                Response.Redirect("Profile.aspx");
            }
        }
    }
}