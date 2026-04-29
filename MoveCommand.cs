using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public class MoveCommand : Command, ITargetedCommand
    {
        public int subjectId { get => army.Id; }

        public override string description { get; protected set; }

        private Army army;
        private Node targetElement;
        public float progress { get; private set; } = 0;
        private const float progressGoal = 1f;
        public override string Name { get; protected set; }
        public MoveCommand(int executerId, Army army, Node target) : base(executerId)
        {
            Name = $"Переміщення {army.Name} до {target.Name}";
            this.army = army;
            this.targetElement = target;

            description = $"{army.Name} переміщується до {targetElement.Name}";
        }
        public override void Execute()
        {
            Edge currentPos = army.CurrentPosition as Edge;

            progress += currentPos.traverseCost;

            if(progress >= progressGoal) finishedExectuing = true;
        }

        public override bool IsValid()
        {
            if(!targetElement.CanAcceptArmy(army)) return false;
            return true;
        }

        public override void OnStart()
        {
            Node sourceNode = army.CurrentPosition as Node;


            Edge? edge = sourceNode.GetConnection(targetElement);

            if(edge == null)
            {
                throw new Exception($"Вершина {sourceNode.Name} не з'єднана з {targetElement.Name}");
            }

            sourceNode.TryRemoveArmy(army);


            edge.AcceptArmy(army);

            army.ChangePosition(edge);

        }

        public override void OnFinish()
        {
            army.CurrentPosition.TryRemoveArmy(army);

            targetElement.AcceptArmy(army);
            army.ChangePosition(targetElement);
        }
    }
}
