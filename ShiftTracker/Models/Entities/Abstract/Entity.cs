using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models.Entities
{
    internal abstract class Entity
    {
        private StringBuilder _name;
        public StringBuilder Name { get { return _name; } set { _name = value; } }
        public Entity(StringBuilder name) { Name = name; }
    }
}
