﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLayer;

namespace TutorialTest
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        String username = "";
        int error = 0;
        String errorMessage = "no error";

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["eventnet"];
            if (cookie == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                username = cookie["eventnet-username"].ToString();
            }
            //if(Response.Cookies["eventnet-username"] != null)
            //{
            //    username = Request.Cookies["eventnet-username"].Value;
            //    //Here we will check the username in the database - NO METHOD DEFINED.
            //    error = 0;
            //}
            //if (error != 0)
            //{
            //    Response.Redirect("LogIn.aspx");
            //}

            //Response.Cookies["eventnet-username"].Value = username;
        }

        protected void Create(object sender, EventArgs e)
        {
            int error = 0;
            String errorMessage = "no error";

            if ((eventName.Text != "") && (eventLocation.Text != "") && (eventTime.Text != ""))
            {
                message.InnerHtml = username + ", " + eventName.Text + ", " + eventLocation.Text + ", " + eventTime.Text;
                error = Controller.Instance.CreateEvent(username, eventName.Text, eventLocation.Text, eventTime.Text);
            }

            if (error != 0)
            {
                errorMessage = Controller.Instance.GetError(error);
            }
        }
    }
}