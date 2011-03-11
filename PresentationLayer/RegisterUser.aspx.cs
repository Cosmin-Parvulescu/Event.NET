using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLayer;

namespace TutorialTest
{
    public partial class HelloWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create(object sender, EventArgs e)
        {
            int error = 0;
            String errorMessage = "no error";

            if ((password.Text != "") && (password.Text == pconfirm.Text))
            {
                error = Controller.Instance.RegisterUser(username.Text, password.Text);
            }
            else
            {
                this.message.InnerHtml += "Password does not match. Please try again. <br />";
            }

            if (error != 0)
            {
                errorMessage = Controller.Instance.GetError(error);
            }
        }
    }
}