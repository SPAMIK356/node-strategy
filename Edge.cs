using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NodeStrategy
{
    public class Edge : MapElement
    {

        public List<Army> armies = new List<Army>();

        public Node a, b;
        public float terrainDifficulty;
        public int infrastructureLevel;
        public const float infrastructureEfficiency = 0.5f;
        public const float baseStep = 1;
        public float traverseCost
        {
            get => (baseStep * (1 + (infrastructureLevel * infrastructureEfficiency))) / terrainDifficulty;
        }
        public Edge(string name, int id, Node a, Node b,  float terrainDifficulty, int infrastructureLevel) : base(name,id)
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

        public override string GetDescription()
        {
            var description = $"ID: {id}\n";

            var controled = isContested ? $"Поділене між фракцією {a.controledBy} та {b.controledBy}" : $"Контролюється фракцією {a.controledBy}";

            description += $"Дорога\n" +
                $"З'єднує міста {a.Name} та {b.Name}\n" +
                $"{controled}\n" +
                $"Складність ландшафту: {terrainDifficulty}\n" +
                $"Рівень інфраструктури: {infrastructureLevel}";

            return description;
        }
    }
}
