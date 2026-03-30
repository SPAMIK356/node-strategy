using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace NodeStrategy
{
    class Army
    {
        public int units { get; private set; }
        public float exp { get; private set; }
        public float expCap { get; private set; }
        public int unitCap { get; private set; }
        public float traverseProgress { get; private set; }
        public int controledBy { get; private set; }
        public MapElement currentPosition { get; private set; }
        public bool alive { get => units > 0; }
        public Army(int units, float exp, float expCap,int unitCap, int controledBy, MapElement currentPosition)
        {
            this.units = unitCap < units ? unitCap : units;
            this.exp = exp;
            this.unitCap = unitCap;
            this.controledBy = controledBy;
            this.expCap = expCap;
            this.currentPosition = currentPosition;
        }
        public void Damage(int damage)
        {
            units -= damage;
            units = units < 0 ? 0 : units;
        }
        public int AddUnits(int amount, float expLevel) 
        { 
            int unitsLeft = (units+amount)-unitCap;

            unitsLeft = unitsLeft < 0 ? 0 : unitsLeft;

            int unitsToAdd = amount - unitsLeft;

            exp = (units * exp + unitsToAdd * expLevel) / units + unitsToAdd;

            units += unitsToAdd;

            return unitsLeft;
        }

        public void AddTraverseProgress(float amount)
        {
            traverseProgress += amount;
        }

        public void ResetTraverseProgress()
        {
            traverseProgress = 0;
        }

        public void ChangePosition(MapElement newPosition)
        {
            currentPosition = newPosition;
        }
    }
}
