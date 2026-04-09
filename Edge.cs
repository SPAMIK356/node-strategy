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
        public bool Conected(Node with)
        {
            return a == with || b == with;
        }
        public override bool AcceptArmy(Army army)
        {
            armies.Add(army);

            return true;
        }

        public override bool CanAcceptArmy(Army army)
        {
            return true;
        }

        public override void OnTurnEnd()
        {
            throw new NotImplementedException();
        }

        public override bool TryRemoveArmy(Army army)
        {
            throw new NotImplementedException();
        }
    }
}
