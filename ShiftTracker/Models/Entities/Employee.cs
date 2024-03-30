using ShiftTracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models
{
    internal class Employee : Entity
    {
        private City _city;
        public City City { get { return _city; } set { _city = value; } }
        public Workshop Workshop;
        public Employee(string name) : base(name) { Name = name; }
    }
}
