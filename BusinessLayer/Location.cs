using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Location
    {
        public string name;
        public List<Visit> visits;

        public Location(string name)
        {
            this.name = name;
            visits = new List<Visit>();
        }
    }
}
