using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    abstract class Component
    {
        MapElement parent;
        

        public abstract void OnTurnEnd();
    }
}
