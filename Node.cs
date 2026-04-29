namespace NodeStrategy
{
    public class Node : MapElement
    {

        public override int GoldGain { get {
                var economyComponent = components.OfType<EconomyComponent>().FirstOrDefault();

                if (economyComponent != null)
                {
                    return economyComponent.GoldPerTurn;
                }
                return base.GoldGain;
            } 
        }
        public override int controledBy { get => base.controledBy; protected set => base.controledBy = value; }
        List<Edge> edges = new List<Edge>();

        public override bool isContested { get 
            {
                var comp = GetComponent<MilitaryComponent>();
                if(comp != null)
                {
                    return comp.attackersCount > 0;
                }
                else
                {
                    return false;
                }
            } 
        }
        
        public Node(string name, int id, int controledBy) : base(name,id)
        {
            this.controledBy = controledBy;
        }
        public bool TryConnect(Node node, Edge edge)
        {
            if (IsConnected(node)) return false;

            edges.Add(edge);

            node.TryConnect(this, edge);

            return true;
        }
        public bool IsConnected(Node with)
        {
            return edges.Any(x => x.a == with ||  x.b == with);
        }
        public Edge? GetConnection(Node with)
        {
            return edges.Where(x => x.Conected(with)).FirstOrDefault();
        }
        public List<Node> GetConnectedNodes()
        {
            return edges.Select(x => x.a == this ? x.b : x.a).ToList();
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
        public void SetControl(int by)
        {
            controledBy = by;
        }
        public override bool CanAcceptArmy(Army army)
        {
            var component = components.OfType<MilitaryComponent>().FirstOrDefault();
            
            return component == null ? false : component.CanAcceptArmy(army);
        }

        public override void OnTurnEnd()
        {
            components.ForEach(x => x.OnTurnEnd());
        }

        public override bool TryRemoveArmy(Army army)
        {
            var military = GetComponent<MilitaryComponent>();

            if(military == null)
            {
                return false;
            }

            return military.TryRemoveArmy(army);
        }
        public override string GetDescription()
        {
            var baseDecription = base.GetDescription();

            var descrtiption = $"Місто\n" +
                $"{baseDecription}";

            foreach(var comp in components)
            {
                descrtiption += '\n'+comp.GetDescription()+'\n';
            }
            return descrtiption;
        }
    }
}
