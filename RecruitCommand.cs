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
        public int Gold { get 
            {
                return (int)(Units * Exp + (UnitsCap + ExpCap * EconomyRules.expCapPriceFactor));
            } }

    }
    public class RecruitCommand : Command, ITargetedCommand
    {
        public int subjectId { get; init; }
        private readonly ArmyTemplate template;
        private readonly Node targetNode;
        private MilitaryComponent comp;
        private readonly Army armyToAdd;
        private readonly Faction faction;
        public RecruitCommand(int executerId, Node targetNode, ArmyTemplate template, Faction faction) : base(executerId) 
        {
            this.faction = faction;
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

            return comp != null && comp.CanAcceptArmy(armyToAdd) && !targetNode.isContested && faction.Gold > template.Gold;
        }

        public override void OnFinish()
        {

        }

        public override void OnStart()
        {
            targetNode.AcceptArmy(armyToAdd);
            faction.ModifyGold(-template.Gold);

            finishedExectuing = true;
        }
    }
}
