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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["eventnet"];
            if (cookie == null)
            {
                debugMessage.InnerText = "cookie doesn't exist";
            }
            else
            {
                debugMessage.InnerText = "cookie exists";
            }
            User us = new User(); us.Id = 1; Event ev = new Event(); ev.Id = 1;
           if(Controller.Instance.LocationVoted(us,ev)){ debugMessage.InnerText = "voted";}
           else{ debugMessage.InnerText = "notvoted";}
        }
    }
}