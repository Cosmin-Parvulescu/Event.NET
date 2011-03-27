using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectCL;

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
        public bool CreateEvent(Event ev)
        {
           return DataAccess.Instance.AddEvent(ev);
            
        }

        public bool UpdateEvent(Event ev)
        {
            return DataAccess.Instance.UpdateEvent(ev);
         
        }

        public bool  DeleteEvent(Event ev) {
           return DataAccess.Instance.DeleteEvent(ev);
          
        }
        
        public Event GetEvent(int id) {

            return  DataAccess.Instance.GetEvent(id);
         
        }
        
        public List<Event> GetEvents(User us, Byte b) {
            return  DataAccess.Instance.GetEvents(us,b);
                 
        }

        public bool EventExists(Event ev) 
        {
            return  DataAccess.Instance.EventExists(ev);
        }

        public bool LocationVoted(User us, Event ev)
        {
            return DataAccess.Instance.LocationVoted(us, ev);

        }
        public bool DateVoted(User us, Event ev)
        {
            return DataAccess.Instance.DateVoted(us, ev);

        }
        public bool TimeVoted(User us, Event ev)
        {
            return DataAccess.Instance.TimeVoted(us, ev);

        }

        public bool VoteLocation(User us, Event ev) {
            return DataAccess.Instance.VoteLocation(us, ev);
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
