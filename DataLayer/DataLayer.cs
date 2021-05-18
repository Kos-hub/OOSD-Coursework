using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class DataLayer
    {
        private static DataLayer instance = new DataLayer();

        private DataLayer() { }

        public static DataLayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataLayer();
                }
                return instance;
            }
        }

        public void SaveUser(User user)
        {
            var filepath = @"C:\Users\Gianmarco\source\repos\Coursework\log.csv";
            using (StreamWriter writer = new StreamWriter(filepath, append: true))
            {
                writer.WriteLine(user.id + "," + user.tel_num);
                foreach (Contact c in user.contacts)
                {
                    writer.WriteLine("," + "," + c.dateAndTime + "," + c.user_1.tel_num + "," + c.user_2.tel_num);
                }

                writer.WriteLine(" ");
            }


        }
        public bool TelephoneValidation(string tel)
        {
            var filepath = @"C:\Users\Gianmarco\source\repos\Coursework\log.csv";
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().ToString();
                    string[] values = line.Split(',');

                    if(values.Length == 1)
                    {
                        return true;
                    }

                    if(values[1] == tel)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public void SaveLocation(Location location)
        {
            var filepath = @"C:\Users\Gianmarco\source\repos\Coursework\log.csv";
            using (StreamWriter writer = new StreamWriter(filepath, append: true))
            {
                writer.WriteLine(location.name + ",");
                foreach (Visit v in location.visits)
                {
                    writer.WriteLine("," + "," + v.dateAndTime + "," + v.user_1.tel_num);
                }

                writer.WriteLine(" ");
            }
        }

        public User LoadUser(String str)
        {
            var filepath = @"C:\Users\Gianmarco\source\repos\Coursework\log.csv";
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().ToString();
                    string[] values = line.Split(',');

                    if (values[0] == str)
                    {
                        User u = new User(Int32.Parse(values[0]), Int32.Parse(values[1]));
                        return u;
                    }
                }
            }
            return null;
        }

        public Location LoadLocation(String str)
        {
            var filepath = @"C:\Users\Gianmarco\source\repos\Coursework\log.csv";
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().ToString();
                    string[] values = line.Split(',');

                    if (values[0] == str)
                    {
                        Location l = new Location(str);
                        return l;
                    }
                }
            }

            return null;
        }


        public List<String> getContactsWith(String id, String requestDate)
        {
            List<String> contacts = new List<String>();

            var filepath = @"C:\Users\Gianmarco\source\repos\Coursework\log.csv";
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().ToString();
                    string[] values = line.Split(',');
                    bool flag = true;

                    if (values[0] == id)
                    {
                        while (flag)
                        {
                            line = reader.ReadLine().ToString();
                            values = line.Split(',');
                            if (values[0] != "")
                            {
                                flag = false;
                                break;
                            }

                            DateTime dateTime = DateTime.Parse(values[2]);
                            DateTime checking = DateTime.Parse(requestDate);

                            if (!(dateTime > checking))
                            {
                                continue;
                            }

                            string contact = "User tel: " + values[3] + " came in contact with User tel: " + values[4] + " On this date and time: " + dateTime;
                            contacts.Add(contact);

                        }
                    }
                }
            }

            List<String> uniqueContacts = contacts.Distinct().ToList();
            return uniqueContacts;
        }

        public List<String> getVisitsAt(String location, String startDate, String endDate)
        {
            List<String> visits = new List<String>();
            var filepath = @"C:\Users\Gianmarco\source\repos\Coursework\log.csv";
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().ToString();
                    string[] values = line.Split(',');
                    bool flag = true;

                    if (values[0] == location)
                    {
                        while (flag)
                        {
                            line = reader.ReadLine().ToString();
                            values = line.Split(',');
                            if (values[0] != "")
                            {
                                flag = false;
                                break;
                            }

                            DateTime dateAndTime = DateTime.Parse(values[2]);
                            DateTime start = DateTime.Parse(startDate);
                            DateTime end = DateTime.Parse(endDate);

                            if (!(dateAndTime > start && dateAndTime < end))
                            {
                                continue;
                            }

                            string visit = "User tel: " + values[3] + " visited location: " + location + " on this date and time: " + dateAndTime;
                            visits.Add(visit);
                        }
                    }
                }
            }

            List<String> uniqueVisits = new List<String>();
            uniqueVisits = visits.Distinct().ToList();
            return uniqueVisits;
        }
    }
}
