using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    class Faction
    {

        List<Army> armies;


        public bool DeleteArmy(Army army)
        {
            return armies.Remove(army);
        }

    }
}
