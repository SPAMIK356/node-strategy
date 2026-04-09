using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    class MoveCommand : Command
    {
        private Army army;
        private Node targetElement;
        private float progress = 0;
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
            throw new NotImplementedException();
        }

        public override void OnStart()
        {
            Node sourceNode = army.currentPosition as Node;


            Edge? edge = sourceNode.GetConnection(targetElement);

            if(edge == null)
            {
                throw new Exception($"Вершина {sourceNode.name} не з'єднана з {targetElement.name}");
            }

            sourceNode.TryRemoveArmy(army);


            edge.AcceptArmy(army);

        }

        public override void OnFinish()
        {
            army.currentPosition.TryRemoveArmy(army);

            targetElement.AcceptArmy(army);
        }
    }
}
