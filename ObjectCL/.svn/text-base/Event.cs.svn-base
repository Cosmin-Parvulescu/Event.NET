using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectCL
{
    public class Event
    {
        private int id;
        private string name;
        private List<Location> locations;
        private List<DateTime> dates;
        private List<DateTime> times;
        private User admin;
        private bool visibility;

        public Event()
        {
        }

        public Event(int id, string name, List<Location> locations, List<DateTime> dates, List<DateTime> times, User admin, bool visibility)
        {
            this.id = id;
            this.name = name;
            this.locations = locations;
            this.dates = dates;
            this.times = times;
            this.admin = admin;
            this.visibility = visibility;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Location> Locations
        {
            get { return locations; }
            set { locations = value; }
        }

        public List<DateTime> Dates
        {
            get { return dates; }
            set { dates = value; }
        }

        public List<DateTime> Times
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
