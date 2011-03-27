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
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create(object sender, EventArgs e)
        {
            if ((password.Text != "") && (password.Text == pconfirm.Text))
            {
                User u = new User();
                u.Username = username.Text;
                u.Password = password.Text;
                u.Firstname = firstname.Text;
                u.Lastname = lastname.Text;
                u.Email = email.Text;

                Controller.Instance.RegisterUser(u);
            }
            else
            {
                this.debugMessage.InnerHtml += "Password does not match. Please try again. <br />";
            }
        }
    }
}