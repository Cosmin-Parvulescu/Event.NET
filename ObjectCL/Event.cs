using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectCL
{
    public class Event
    {
        private Int32 id;
        private String name;
        private List<Location> locations;

        // yyyy-mm-dd
        private List<String> dates;
        // hh:mm
        private List<String> times;
        private User admin;
        private bool visibility;

        public Event()
        {
        }

        public Event(Int32 id, String name, List<Location> locations, List<String> dates, List<String> times, User admin, bool visibility)
        {
            this.id = id;
            this.name = name;
            this.locations = locations;
            this.dates = dates;
            this.times = times;
            this.admin = admin;
            this.visibility = visibility;
        }

        public override String ToString()
        {
            return base.ToString();
        }

        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Location> Locations
        {
            get { return locations; }
            set { locations = value; }
        }

        public List<String> Dates
        {
            get { return dates; }
            set { dates = value; }
        }

        public List<String> Times
        {
            get { return times; }
            set { times = value; }
        }

        public User Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public bool Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }
    }
}
