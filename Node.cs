namespace NodeStrategy
{
    class Node : MapElement
    {

        public override int controledBy { get => base.controledBy; protected set => base.controledBy = value; }
        List<Edge> edges = new List<Edge>();



        public Node(string name, int id) : base(name,id)
        {
            
        }

        public Edge? GetConnection(Node with)
        {
            return edges.Where(x => x.Conected(with)).FirstOrDefault();
        }
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
