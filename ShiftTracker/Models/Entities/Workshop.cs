using ShiftTracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models
{
    internal class Workshop : Entity
    {
        private City _city;
        public City City { get { return _city; } set { _city = value; } }
        public List<Employee> Employees { get; set; }
        public Workshop(string name) :base(name)
        {
            Name = name; Employees = new List<Employee>();
        }
    }
}
