using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    class TurnManager
    {
        public List<int> turnOrder = new List<int>();
        public Dictionary<int, Faction> factions = new Dictionary<int, Faction>();
        public Dictionary<int, MapElement> mapElements = new Dictionary<int, MapElement>();
        public Faction currentFaction { get => factions[turnOrder[currentTurnIndex]]; }
        private int currentTurnIndex = 0;

        public List<Command> plannedCommands = new List<Command>();

        public List<Command> activeCommands = new List<Command>();
        

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
    }
}
