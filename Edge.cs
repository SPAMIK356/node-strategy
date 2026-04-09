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
        public float terrainDifficulty;
        public int infrastructureLevel;
        public float traverseCost
        {
            get => 1 - (terrainDifficulty * infrastructureLevel);
        }
        public Edge(Node a, Node b,  float terrainDifficulty, int infrastructureLevel)
        {
            this.a = a;
            this.b = b;
            this.terrainDifficulty = terrainDifficulty;
            this.infrastructureLevel = infrastructureLevel;
        }
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
        }

        public override bool TryRemoveArmy(Army army)
        {
            return armies.Remove(army);
        }
    }
}
