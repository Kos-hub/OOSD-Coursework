using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class EventFacade
    {
        private CreateUser createUser = CreateUser.Instance;
        private DataLayer db = DataLayer.Instance;

        public EventFacade() { }

        public void AddNewUser(int tel_num)
        {
            User u = createUser.AddUser(tel_num);
            db.SaveUser(u);
        }

        public bool ValidateTel(string tel)
        {
            bool check = db.TelephoneValidation(tel);
            return check;
        }
        public void AddNewLocation(String str)
        {
            Location l = new Location(str);
            db.SaveLocation(l);
        }
        public void AddContact(User user_1, User user_2, string date)
        {
            Contact c = new Contact(user_1, user_2);
            c.dateAndTime = date;
            user_1.contacts.Add(c);
            user_2.contacts.Add(c);
            db.SaveUser(user_1);
            db.SaveUser(user_2);
        }

        public void AddVisit(User userVisit, Location locationVisit, string date)
        {
            Visit v = new Visit(userVisit, locationVisit);
            v.dateAndTime = date;
            locationVisit.visits.Add(v);
            db.SaveLocation(locationVisit);
        }

        public List<String> GetContacts(string id, string date)
        {
            List<String> list = new List<String>();
            return list = db.getContactsWith(id, date);
        }

        public List<String> GetVisits(string name, string beginDate, string endDate)
        {
            List<String> list = new List<String>();
            return list = db.getVisitsAt(name, beginDate, endDate);
        }

        public User LoadUserFromCSV(String str)
        {
            return db.LoadUser(str);
        }

        public Location LoadLocationFromCSV(String str)
        {
            return db.LoadLocation(str);
        }
    }
}
