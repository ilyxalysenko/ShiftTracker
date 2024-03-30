using ShiftTracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models
{
    internal class Brigade : Entity
    {
        public Brigade(string name) :base(name) { Name = name; }
    }
}
