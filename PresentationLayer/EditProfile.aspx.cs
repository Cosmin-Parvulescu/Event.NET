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
    public partial class EditProfil : AbstractPage
    {
        private User loggedInUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInUser = GetUserFromCookie();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.EMail.Text = loggedInUser.Email;
                this.FirstName.Text = loggedInUser.Firstname;
                this.LastName.Text = loggedInUser.Lastname;
            }
        }

        protected void UpdateDetails(object sender, EventArgs e)
        {
            if ((Password.Text != "") && (Password.Text == ConfirmPassword.Text))
            {
                loggedInUser.Firstname = FirstName.Text;
                loggedInUser.Lastname = LastName.Text;
                loggedInUser.Email = EMail.Text;
                loggedInUser.Password = Password.Text;
            }

            Controller.Instance.UpdateUser(loggedInUser);

            Response.Redirect("Profile.aspx");
        }

        protected void CancelUpdate(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}