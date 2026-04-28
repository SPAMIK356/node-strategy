
using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public class EconomyComponent : Component
    {
        int goldPerTurn;

        public EconomyComponent(int goldPerTurn)
        {
            this.goldPerTurn = goldPerTurn;
        }
        public override string GetDescription()
        {
            return $"Дохід за хід:{goldPerTurn}\n";
        }

        public override void OnTurnEnd()
        {
            
            GameEvents.TriggerGoldGeneration(parent.controledBy, goldPerTurn);
        }
    }
}
