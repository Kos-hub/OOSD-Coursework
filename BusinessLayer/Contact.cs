using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Contact : Event
    {
        public User user_1;
        public User user_2;

        public Contact(User user_1, User user_2)
        {
            this.user_1 = user_1;
            this.user_2 = user_2;
        }

        public override void print()
        {
            Console.WriteLine("Contact between: " + user_1.id + " and " + user_2.id + ". At date and time: " + base.dateAndTime);
        }
    }
}
