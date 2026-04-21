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
        List<Army> defenders = new();
        List<Army> attackers = new();

        public bool DefendersFull { get => defenders.Count >= armyCap; }
        public bool AttackersFull { get => attackers.Count >= armyCap; }

        public int armyCap { get; private set; }

        float defenceFactor;
        public MilitaryComponent(int armyCap, float defenceFactor)
        {
            this.armyCap = armyCap;
            this.defenceFactor = defenceFactor;
        }
        public void ResolveCombat()
        {
            if(defenders.Count == 0 || attackers.Count == 0)
            {
                return;
            }

            ArmyStats attackersStats = new ArmyStats(GetTotalUnits(attackers), GetAverageXP(attackers), ArmyState.Attacking);
            ArmyStats defendersStats = new ArmyStats(GetTotalUnits(defenders), GetAverageXP(defenders), ArmyState.Defending);

            int attackerDamage = (int)(attackersStats.damage / defenceFactor);
            int defenderDamage = defendersStats.damage;

            DamageArmyGroup(defenders, defendersStats, attackerDamage);
            DamageArmyGroup(attackers, attackersStats, defenderDamage);

            ClearDefeatedArmies();
            if(defenders.Count == 0 && attackers.Count > 0 && parent is Node node)
            {
                node.SetControl(attackers[0].controledBy);
                defenders.AddRange(attackers);
                attackers.Clear();
            }
        }
        protected void DamageArmyGroup(List<Army> armies, ArmyStats defStats, int damage)
        {
            armies.ForEach(x => x.Damage(damage / armies.Count));
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
        public bool CanAcceptArmy(Army army)
        {
            if(army.controledBy == parent.controledBy)
            {
                if(defenders.Count >= armyCap)
                    return false;
            }
            else
            {
                if (attackers.Count >= armyCap)
                    return false;
            }
            return true;
        }
        public override void OnTurnEnd()
        {
            ResolveCombat();
        }

        public bool TryRemoveArmy(Army army)
        {
            return defenders.Remove(army) || attackers.Remove(army);
        }
        public void ClearDefeatedArmies()
        {
            defenders.RemoveAll(x => x.isDead);
            attackers.RemoveAll(x => x.isDead);
        }
        
    }
}
