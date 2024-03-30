using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models.Entities
{
    internal abstract class Entity
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public Entity(string name) { Name = name; }
    }
}
