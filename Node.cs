namespace NodeStrategy
{
    class Node : MapElement
    {

        public string name;
        public override int controledBy { get => base.controledBy; set => base.controledBy = value; }

        public override bool TryAcceptArmy(Army army)
        {
            var military = components.OfType<MilitaryComponent>().FirstOrDefault();

            if(military != null)
            {
                return military.TryAddArmy(army);
            }
            return false;
        }

    }
}
