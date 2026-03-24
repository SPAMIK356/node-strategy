using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    abstract class MapElement
    {

        public List<Component> components;
        public int id;

        public abstract bool AcceptArmy(Army army);
        public abstract bool CanAcceptArmy();
    }
}
