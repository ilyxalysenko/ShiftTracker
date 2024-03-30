using ShiftTracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models
{
    internal class City : Entity
    {
        public List<Workshop> Workshops;
        public City(string name) : base(name) { Name = name; }
    }
}
