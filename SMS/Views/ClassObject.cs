using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Views
{
    public class ClassObject
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public ClassObject(string _Name, string _Location)
        {
            Name = _Name;
            Location = _Location;
        }
    }
}
