using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public class TurnManager
    {
        public List<int> turnOrder = new List<int>();
        public Dictionary<int, Faction> factions = new Dictionary<int, Faction>();
        public Dictionary<int, MapElement> mapElements = new Dictionary<int, MapElement>();
        public Faction CurrentFaction { get => factions[turnOrder[currentTurnIndex]]; }
        private int currentTurnIndex = 0;
        public int CurrentTurn { get; private set; } = 1;
        public Action TurnEnd;
        

        public List<Command> plannedCommands = new List<Command>();

        public List<Command> activeCommands = new List<Command>();
        
        public TurnManager()
        {
            GameEvents.OnGoldAdd += GenerateGold;
        }
        ~TurnManager()
        {
            GameEvents.OnGoldAdd -= GenerateGold;
        }
        public List<Army> GetAllArmies()
        {


            return mapElements.Values.
                OfType<Edge>().
                SelectMany(x => x.armies).
                Concat(
                mapElements.Values
                .OfType<Node>()
                .Select(x => x.GetComponent<MilitaryComponent>()).
                Where(x => x != null)
                .SelectMany(x =>
                {              
                    return x.GetArmies();
                }))
                .ToList();
        }
        public void EndTurn()
        {
            activeCommands.RemoveAll(x => !x.IsValid());

            foreach(var command in activeCommands)
            {
                command.Execute();
                if(command.finishedExectuing)
                {
                    command.OnFinish();
                }
            }
            activeCommands.RemoveAll(x => x.finishedExectuing);

            plannedCommands.RemoveAll(x => !x.IsValid());
            foreach(Command command in plannedCommands)
            {
                command.OnStart();
                activeCommands.Add(command);
            }
            plannedCommands.Clear();


            foreach(var mapElement in mapElements.Values)
            {
                mapElement.OnTurnEnd();
            }

            currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;
            CurrentTurn++;

            TurnEnd?.Invoke();
        }
        public void AddCommand(Command command)
        {
            if(command is ITargetedCommand comm)
            {
                

                var existingCommand = plannedCommands.OfType<ITargetedCommand>().Where(x => x.subjectId == comm.subjectId).FirstOrDefault();

                plannedCommands.Remove(existingCommand as Command);


            }
            plannedCommands.Add(command);

        }

        public void GenerateGold(int factionId, int amount)
        {
            factions[factionId].ModifyGold(amount);
        }
        public int GetGoldPerTurn(int factionId)
        {

            return mapElements.Values.OfType<Node>()
                .Select(x => x.GetComponent<EconomyComponent>())
                .Where(x => x != null && x.parent.controledBy == factionId)
                .Sum(x => x.GoldPerTurn);
            
        }
        public int GetGoldPerTurn(Faction faction)
        {
            return GetGoldPerTurn(faction.id);
        }
    }
}
