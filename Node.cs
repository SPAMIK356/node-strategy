namespace NodeStrategy
{
    class Node : MapElement
    {

        public string name;
        public override int controledBy { get => base.controledBy; protected set => base.controledBy = value; }

        public override bool AcceptArmy(Army army)
        {
            var military = components.OfType<MilitaryComponent>().FirstOrDefault();

            if (military == null)
            {
                return false;
            }

            return military.TryAddArmy(army);            

        }
        public override bool CanAcceptArmy(Army army)
        {
            return components.OfType<MilitaryComponent>().Any();

        }

        public override void OnTurnEnd()
        {
            components.ForEach(x => x.OnTurnEnd());
        }

        public override bool TryRemoveArmy(Army army)
        {
            var military = components.OfType<MilitaryComponent>().FirstOrDefault();

            if(military == null)
            {
                return false;
            }

            return military.TryRemoveArmy(army);
        }
    }
}
