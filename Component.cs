using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    abstract class Component
    {
        public MapElement parent { get; private set; }
        

        public abstract void OnTurnEnd();
    }
}
