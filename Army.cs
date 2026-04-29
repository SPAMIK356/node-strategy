using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public class Army
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Units { get; private set; }
        public float Exp { get; private set; }
        public float ExpCap { get; private set; }
        public int UnitCap { get; private set; }
        public int ControledBy { get; private set; }
        public MapElement СurrentPosition { get; private set; }
        public bool IsDead { get => Units <= 0; }
        public Army(int id, int units, float exp, float expCap,int unitCap, int controledBy, MapElement currentPosition, string name)
        {
            this.Id = id;
            this.Units = unitCap < units ? unitCap : units;
            this.Exp = exp;
            this.UnitCap = unitCap;
            this.ControledBy = controledBy;
            this.ExpCap = expCap;
            this.СurrentPosition = currentPosition;
            this.Name = name;
        }
        public void Damage(int damage)
        {
            Units -= damage;
            Units = Units < 0 ? 0 : Units;
        }
        public int AddUnits(int amount, float expLevel) 
        { 
            int unitsLeft = (Units+amount)-UnitCap;

            unitsLeft = unitsLeft < 0 ? 0 : unitsLeft;

            int unitsToAdd = amount - unitsLeft;

            Exp = (Units * Exp + unitsToAdd * expLevel) / Units + unitsToAdd;

            Units += unitsToAdd;

            return unitsLeft;
        }

        public void ChangePosition(MapElement newPosition)
        {
            СurrentPosition = newPosition;
        }
    }
}
