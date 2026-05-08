using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public partial class TurnManager
    {
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

            var edgeArmies = (from edge in mapElements.Values.OfType<Edge>()
                              from army in edge.armies
                              select army);

            var nodeArmies = (from node in mapElements.Values.OfType<Node>()
                              let militaryComp = node.GetComponent<MilitaryComponent>()
                              where militaryComp != null
                              from army in militaryComp.GetArmies()
                              select army);



            return edgeArmies.Concat(nodeArmies).ToList();
                /*mapElements.Values.
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
                .ToList();*/
        }
        public void EndTurn()
        {
            activeCommands.RemoveAll(x => !x.IsValid());

            foreach (var command in activeCommands)
            {
                command.Execute();
                if (command.finishedExectuing)
                {
                    command.OnFinish();
                }
            }
            activeCommands.RemoveAll(x => x.finishedExectuing);

            plannedCommands.RemoveAll(x => !x.IsValid());
            foreach (Command command in plannedCommands)
            {
                command.OnStart();
                activeCommands.Add(command);
            }
            plannedCommands.Clear();


            foreach (var mapElement in mapElements.Values)
            {
                mapElement.OnTurnEnd();
            }

            CheckForWin();

            currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;
            CurrentTurn++;

            TurnEnd?.Invoke();
        }
        private void CheckForWin()
        {
            var aliveFactions = mapElements.Values
            .Select(x => x.controledBy)
            .Distinct().ToList();

            var lostFactions = turnOrder.Except(aliveFactions).ToList();

            foreach (var lost in lostFactions)
            {
                turnOrder.Remove(lost);
            }

            if (turnOrder.Count < 2 || turnOrder.Count == 2 && turnOrder.Contains(0))
            {
                GameWon?.Invoke(factions[turnOrder.Where(x => x != 0).FirstOrDefault()]);
            }
        }
        public void AddCommand(Command command)
        {
            if (command is ITargetedCommand comm)
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
