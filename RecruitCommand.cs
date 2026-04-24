using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public struct ArmyTemplate
    {
        public string Name;
        public int Units;
        public int UnitsCap;
        public float Exp;
        public float ExpCap;


    }
    public class RecruitCommand : Command, ITargetedCommand
    {
        public int subjectId { get; init; }
        private ArmyTemplate template;
        private Node targetNode;
        private MilitaryComponent comp;
        private Army armyToAdd;
        public RecruitCommand(int executerId, Node targetNode, ArmyTemplate template) : base(executerId) 
        {
            this.targetNode = targetNode;
            this.template = template;
            subjectId = targetNode.id;

            armyToAdd = new Army(IDReg.NextID,template.Units,
                template.Exp,
                template.ExpCap,
                template.UnitsCap,
                executerId,
                targetNode,
                template.Name);
            
        }

        public override void Execute()
        {
        }

        public override bool IsValid()
        {
            comp = targetNode.GetComponent<MilitaryComponent>();

            return comp != null && comp.CanAcceptArmy(armyToAdd) && !targetNode.isContested;
        }

        public override void OnFinish()
        {

        }

        public override void OnStart()
        {
            targetNode.AcceptArmy(armyToAdd);

            finishedExectuing = true;
        }
    }
}
