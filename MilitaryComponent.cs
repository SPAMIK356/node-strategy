using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;

namespace NodeStrategy
{
    class MilitaryComponent : Component
    {
        List<Army> defenders;
        List<Army> attackers;
        public int armyCap { get; private set; }
        public void ResolveCombat()
        {
            if(defenders.Count == 0 || attackers.Count == 0)
            {
                return;
            }



        }



        public bool TryAddArmy(Army army)
        {
            if(army.controledBy == parent.controledBy)
            {
                if(defenders.Count < armyCap)
                {
                    defenders.Add(army);
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else if (attackers.Count < armyCap)
            {
                if(attackers.Count == 0 || attackers[0].controledBy == army.controledBy)
                {
                    attackers.Add(army);
                    return true;
                }
                return false;
            }
            return false;
        }

        public override void OnTurnEnd()
        {
            throw new NotImplementedException();
        }
        
    }
}
