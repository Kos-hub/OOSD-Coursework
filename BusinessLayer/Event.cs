using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    abstract class Event
    {
        public string dateAndTime;

        public string DateAndTime
        {
            get;
            set;
        }

        public abstract void print();
    }
}
