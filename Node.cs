namespace NodeStrategy
{
    class Node : MapElement
    {

        public string name;
        public override int controledBy { get => base.controledBy; set => base.controledBy = value; }

        public override bool AcceptArmy(Army army)
        {
            var military = components.OfType<MilitaryComponent>().FirstOrDefault();

            if (military == null)
            {
                return false;
            }

            //TODO: завершити метод
            

        }
        public override bool CanAcceptArmy(Army army)
        {
            return components.OfType<MilitaryComponent>().Any();

        }

        public override void OnTurnEnd()
        {
            throw new NotImplementedException();
        }

        public override bool TryRemoveArmy(Army army)
        {
            throw new NotImplementedException();
        }
    }
}
