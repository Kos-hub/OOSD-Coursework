using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class User
    {
        public int id;
        public int tel_num;
        public List<Contact> contacts = new List<Contact>();

        public User(int i, int t)
        {
            id = i;
            tel_num = t;
        }

        public List<Contact> Contacts
        {
            get;
            set;
        }
    }
}
