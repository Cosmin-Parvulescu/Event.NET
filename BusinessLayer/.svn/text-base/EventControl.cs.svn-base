using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccessLayer;

namespace BusinessLayer
{
    class EventControl
    {
        /// <summary>
        /// Creates an event and stores it in the database
        /// </summary>
        /// <param name="username">Username of event creator</param>
        /// <param name="name">Name of event</param>
        /// <param name="location">Location of event</param>
        /// <param name="datetime">Date & time of event (must be in format 'yyyy-MM-dd HH:mm')</param>
        /// <returns>0 - Successfull creation | 1 - Errors occured</returns>
        public int CreateEvent(String username, String name, String location, String datetime)
        {
            if (this.Validate(username, name, location, datetime) == 0)
            {
                if (DataAccess.Instance.AddEvent(name, location, datetime, username) == 0)
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
        /// Checks if datetime string has correct date & time format
        /// </summary>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="datetime">Contains the date & time of event as a string</param>
        /// <returns>0 - No errors found | 1 - Errors found</returns>
        private int Validate(String username, String name, String location, String datetime)
        {
            if (Verification.IsDateTime(datetime) != false)
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
