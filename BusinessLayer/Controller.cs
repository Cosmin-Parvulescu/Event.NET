using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class Controller
    {

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        private UserControl userControl;
        private EventControl eventControl;

        private Controller()
        {
            userControl = new UserControl();
            eventControl = new EventControl();
        }

        /// <summary>
        /// Register a user in the database
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>1 - Registration Succesfull | 0 - Registration failed</returns>
        public int RegisterUser(String username, String password)
        {
            if (Verification.IsNotScript(username) && Verification.IsNotScript(password))
            {
                if (userControl.RegisterUser(username, password) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// Checks the provided user credentials
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>1 - The credentials passed | 0 - The credentials failed </returns>
        public int LogIn(String username, String password)
        {
            if (Verification.IsNotScript(username) && Verification.IsNotScript(password))
            {
                if (userControl.LogIn(username, password) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        public int CreateEvent(String username, String name, String location, String datetime)
        {
            if (Verification.IsNotScript(name) &&
                Verification.IsNotScript(location) &&
                Verification.IsNotScript(datetime))
            {
                if (eventControl.CreateEvent(username, name, location, datetime) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }

        }

        public String GetError(int code)
        {
            return "";
        }
    }
}
