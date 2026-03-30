using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;

namespace NodeStrategy
{

    class MilitaryComponent : Component
    {
        protected enum ArmyState
        {
            Defending,
            Attacking
        }
        protected struct ArmyStats
        {
            public int unitAmount;
            public float exp;
            public ArmyState state;
            public int damage 
            { 
                get 
                {
                    return Convert.ToInt32((float)unitAmount * exp * CombatRules.combatLethality*(1+CombatRules.expWeight));
                } 
            }
            public ArmyStats(int unitAmount, float exp, ArmyState state)
            {
                this.unitAmount = unitAmount;
                this.exp = exp;
                this.state = state;
            }
        }
        List<Army> defenders;
        List<Army> attackers;

        public bool DefendersFull { get => defenders.Count >= armyCap; }
        public bool AttackersFull { get => attackers.Count >= armyCap; }

        public int armyCap { get; private set; }

        float defenceFactor;

        public void ResolveCombat()
        {
            if(defenders.Count == 0 || attackers.Count == 0)
            {
                return;
            }

            ArmyStats attackersStats = new ArmyStats(GetTotalUnits(attackers), GetAverageXP(attackers), ArmyState.Attacking);
            ArmyStats defendersStats = new ArmyStats(GetTotalUnits(defenders), GetAverageXP(defenders), ArmyState.Defending);
            
            
            

        }
        protected int CalculateDamage(ArmyStats army, float factor)
        {
            return Convert.ToInt32((float)army.damage * factor);
        }
        protected int GetTotalUnits(List<Army> armies)
        {
            return armies.Sum(x => x.units);
        }

        protected float GetAverageXP(List<Army> armies)
        {
            return armies.Sum(x => x.units*x.exp)/GetTotalUnits(armies);
        }
        protected float GetAverageXP(List<Army> armies, int totalUnits)
        {
            return armies.Sum(x => x.units * x.exp) / totalUnits;
        }
        public bool TryAddArmy(Army army)
        {
            if(army.controledBy == parent.controledBy)
            {
                if(!DefendersFull)
                {
                    defenders.Add(army);
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else if (!AttackersFull)
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
