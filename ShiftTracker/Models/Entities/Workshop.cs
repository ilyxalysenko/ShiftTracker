using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models
{
    internal class Workshop
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        private City _city;
        public City City { get { return _city; } set { _city = value; } }
        public List<Employee> Employees { get; set; }
        public Workshop(string name) 
        {
            Name = name; Employees = new List<Employee>();
        }
    }
}
