namespace NodeStrategy
{
    class Node : MapElement
    {

        public string name;
        public int controledBy;

        public override bool AcceptArmy(Army army)
        {
            throw new NotImplementedException();
        }
        public override bool CanAcceptArmy()
        {
            if(components.Contains(x => { return x is MilitaryComponent;  }))
            {

            }
        }
    }
}
