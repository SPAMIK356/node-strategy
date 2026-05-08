using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public abstract class Component
    {
        public MapElement parent { get; set; }
        public abstract string GetDescription();
        public abstract void OnTurnEnd();
    }
}
