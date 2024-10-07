using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Coordinates { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TimeOfReport { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; } = false;

        public Report() 
        {
            Address = "";
            Coordinates = "";
            Email = "";
            PhoneNumber = "";
            TimeOfReport = DateTime.Now.ToString();
            Description = "";
            Completed = false;
        }
    
        public string DisplayAddress()
        {
            return "Location: " + Address;
        }

        public string DisplayCoords()
        {
            string[] coords = Coordinates.Split(",");
            return coords[0] + ", " + coords[1];
        }

        public string DisplayContactInfo()
        {
            string contactInfo = "";
            if(Email != "")
            {
                contactInfo += Email;
            }

            if(Email != "" && PhoneNumber != "")
            {
                contactInfo += ", ";
            }

            if(PhoneNumber != "")
            {
                contactInfo += PhoneNumber;
            }

            return contactInfo;
        }

        public bool HasContactInfo()
        {
            return Email != "" || PhoneNumber != "";
        }
        public string DisplayReportTime()
        {
            return "Report Time: " + TimeOfReport;
        }
        public string DisplayTime()
        {
            return "Coordinates: " + Coordinates;
        }
        public string DisplayDescription()
        {
            return Description;
        }

        public void DeletePersonalInfo()
        {
            Email = "";
            PhoneNumber = "";
        }

        public void MarkComplete()
        {
            Completed = true;
            //Send completed message to reportee if left contact info
            DeletePersonalInfo();
        }
    }
}
