using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ShiftTracker.Models.Entities
{
    internal class Shift : Entity
    {
        public Shift (string name) : base(name) { Name = name; }
    }
}
