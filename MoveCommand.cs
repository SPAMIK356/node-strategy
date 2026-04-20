using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    class MoveCommand : Command, ITargetedCommand
    {
        public int subjectId { get => army.id; }
        private Army army;
        private Node targetElement;
        public float progress { get; private set; } = 0;
        private const float progressGoal = 1f;
        public override string Name { get; protected set; }
        public MoveCommand(Army army, Node target)
        {
            Name = $"Переміщення {army.name} до {target.Name}";
            this.army = army;
            this.targetElement = target;
        }
        public override void Execute()
        {
            Edge currentPos = army.currentPosition as Edge;

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
            Node sourceNode = army.currentPosition as Node;


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
            army.currentPosition.TryRemoveArmy(army);

            targetElement.AcceptArmy(army);
            army.ChangePosition(targetElement);
        }
    }
}
