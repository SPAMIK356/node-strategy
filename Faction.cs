using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    class Faction
    {

        List<int> armies;
        public int id { get; protected set; }

        public bool DeleteArmy(Army army)
        {
            return armies.Remove(army);
        }

    }
}
