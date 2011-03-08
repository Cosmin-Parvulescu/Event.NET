﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    class UserControl
    {
        private Regex userRegex = new Regex("");
        private Regex passwordRegex = new Regex("");

        public int RegisterUser(String username, String password)
        {
            // Need DAL here
            if(Validate(username, password) == 1)
            {
                return 1;
            }
            return 0;
        }

        public int LogIn(String username, String password)
        {
            // Need DAL here
            if (Validate(username, password) == 1)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Checks for proper username and password input
        /// </summary>
        /// <param name="username">Allows dashes, underscore, lowercase letters, uppercase letters and numbers [must start with letter]</param>
        /// <param name="password">Allows same as username but with additional characters</param>
        /// <returns>1 - pass | 0 - fail</returns>
        private int Validate(String username, String password)
        {
            if (userRegex.IsMatch(username) && passwordRegex.IsMatch(password))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
