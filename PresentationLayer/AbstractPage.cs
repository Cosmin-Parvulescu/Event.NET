using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ObjectCL;
using BusinessLayer;

namespace PresentationLayer
{
    public abstract class AbstractPage : System.Web.UI.Page
    {
        protected void CheckCookie()
        {
            HttpCookie cookie = Request.Cookies["eventnet"];
            if (cookie == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected User GetUserFromCookie()
        {
            HttpCookie cookie = Request.Cookies["eventnet"];
            if (cookie == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                String uname = cookie["eventnet-username"];
                return Controller.Instance.GetUser(uname);
            }
            return null;
        }
    }
}