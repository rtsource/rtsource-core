using System;
using System.Collections.Generic;
using System.Text;

namespace Rts.Core.Model
{
    public abstract class NamedEntity : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
