using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models
{
    internal class Employee
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Workshop Workshop;
        public Employee(string name) { Name = name; }
    }
}
