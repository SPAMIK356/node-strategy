using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NodeStrategy
{
    class Edge : MapElement
    {

        public List<Army> armies = new List<Army>();

        public Node a, b;

        public int infrastructureLevel;
        public float traverseCost;

        public bool isContested
        {
            get
            {
                return a.controledBy != b.controledBy;
            }
        }



        public override bool TryAcceptArmy(Army army)
        {
            armies.Add(army);
            return true;
        }

    }
}
