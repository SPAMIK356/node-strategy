using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public class Faction
    {

        public int id { get; init; }

        private int gold = 0;
        public int Gold { get => gold; protected set => gold = value; }

        public bool InDebt { get => Gold < 0; }
        public Faction(int id)
        {
            this.id = id;
        }

        public void ModifyGold(int gold)
        {
            Gold += gold;
        }
    }
}
