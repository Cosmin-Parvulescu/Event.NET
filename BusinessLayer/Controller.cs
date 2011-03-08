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

        private Controller() { }

        public int RegisterUser(String username, String password)
        {
            return 0;
        }

        public int LogIn(String username, String password)
        {
            return 0;
        }

        public int CreateEvent(String username, String name, String location, String datetime)
        {
            return 0;
        }

        public String GetError(int code)
        {
            return "";
        }
    }
}
