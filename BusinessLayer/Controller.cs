using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectCL;

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

               
        public bool RegisterUser(User us)
        {
           return userControl.RegisterUser(us);                
        }

        public bool LogIn(User us)
        {
            return userControl.LogIn(us);
        }

        public bool UpdateUser(User user)
        {
            return userControl.Update(user);
        }

        public User GetUser(String username)
        {
            return userControl.GetUser(username);
        }

        public User GetUser(User us)
        {
            return userControl.GetUser(us.Username);
        }

        public List<User> GetUsers(Event ev, Byte b)
        {
            return userControl.GetUsers(ev, b);
        }

        
        public bool UserExists(User us) 
        {
            return userControl.UserExists(us);
        }



        public bool CreateEvent(Event ev)
        {
            return eventControl.CreateEvent(ev);
         }


        public bool UpdateEvent(Event ev)
        {
            return eventControl.UpdateEvent(ev);   
            
        }

        public bool DeleteEvent(Event ev)
        {
            return eventControl.DeleteEvent(ev);

        }


        public Event GetEvent(int id)
        {
            return eventControl.GetEvent(id);
        }

        public Event GetEvent(Event ev)
        {
            return eventControl.GetEvent(ev.Id);
        }

        public List<Event> GetEvents(User us, Byte b)
        {
            return  eventControl.GetEvents(us,b);
        }


        public bool EventExists(Event ev)
        {
            return eventControl.EventExists(ev);
        }

        public bool LocationVoted(User us, Event ev) {
            return eventControl.LocationVoted(us,ev);
        
        }
        public bool DateVoted(User us, Event ev)
        {
            return eventControl.DateVoted(us, ev);

        }
        public bool TimeVoted(User us, Event ev)
        {
            return eventControl.TimeVoted(us, ev);

        }
        public bool VoteLocation(User us, Event ev)
        {
            return eventControl.VoteLocation(us, ev);

        } 




        public String GetError(int code)
        {
            return "";
        }
    }
}
