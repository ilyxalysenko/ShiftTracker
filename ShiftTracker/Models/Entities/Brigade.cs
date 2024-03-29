using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models
{
    internal class Brigade
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Brigade(string name) { Name = name; }
    }
}
