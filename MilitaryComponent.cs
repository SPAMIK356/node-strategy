using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    class MilitaryComponent : Component
    {
        List<Army> defenders;
        List<Army> attackers;
        int armyCap;
        public void ResolveCombat()
        {
            if(defenders.Count == 0 || attackers.Count == 0)
            {
                return;
            }



        }

        public override void OnTurnEnd()
        {
            throw new NotImplementedException();
        }
        
    }
}
