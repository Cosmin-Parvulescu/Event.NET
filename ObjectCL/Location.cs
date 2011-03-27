using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectCL
{
    public class Location
    {
        private String locationPlace;
        private String country;
        private String city;
        private String address;

        public Location()
        {
        }

        public Location(String locationPlace, String country, String city, String address)
        {
            this.locationPlace = locationPlace;
            this.country = country;
            this.city = city;
            this.address = address;
        }

        public override String ToString()
        {
            return base.ToString();
        }

        public String LocationPlace
        {
            get { return locationPlace; }
            set { locationPlace = value; }
        }

        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
