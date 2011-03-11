﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLayer;

namespace TutorialTest
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        protected void Login(object sender, EventArgs e)
        {
            int error = 0;
            String errorMessage = "no error";

            if ((username.Text != "") && (password.Text != ""))
            {

                error = Controller.Instance.LogIn(username.Text, password.Text);
            }

            if (error != 0)
            {
                errorMessage = Controller.Instance.GetError(error);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("eventnet");
                Response.Cookies.Add(cookie);
                cookie["eventnet-username"] = username.Text;
                cookie.Expires = DateTime.Now.AddMonths(1);
            }
        }
    }
}