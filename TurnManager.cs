using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NodeStrategy
{
    public partial class TurnManager
    {
        public List<int> turnOrder = new List<int>();
        public Dictionary<int, Faction> factions = new Dictionary<int, Faction>();
        public Dictionary<int, MapElement> mapElements = new Dictionary<int, MapElement>();
        public Faction CurrentFaction { get => factions[turnOrder[currentTurnIndex]]; }
        private int currentTurnIndex = 0;
        public int CurrentTurn { get; private set; } = 1;
        public Action TurnEnd;
        public Action<Faction> GameWon;

        public List<Command> plannedCommands = new List<Command>();

        public List<Command> activeCommands = new List<Command>();
        
       
    }
}
