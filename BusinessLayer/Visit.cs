using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Visit : Event
    {
        public User user_1;
        public Location location;

        public Visit(User user_1, Location location)
        {
            this.user_1 = user_1;
            this.location = location;
        }

        public override void print()
        {
            Console.WriteLine("The user " + user_1.id + " visited: " + location.name + " At date and time: " + base.dateAndTime);
        }
    }
}
