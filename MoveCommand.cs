using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    class MoveCommand : Command
    {
        private Army army;
        private MapElement targetElement;
        private float progress = 0;
        private const float progressGoal = 100f;
        public override string Name { get; protected set; }
        public MoveCommand(Army army, MapElement target)
        {
            Name = $"Переміщення {army.name} до {target.Name}";
            this.army = army;
            this.targetElement = target;
        }
        public override void Execute()
        {
            if (progress == 0)
            {

            }
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
