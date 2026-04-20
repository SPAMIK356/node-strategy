using System.Diagnostics;

namespace NodeStrategy
{
    public partial class Form1 : Form
    {
        private TurnManager manager = new();
        private Army army;
        public Form1()
        {

            InitializeComponent();
            Load += new EventHandler(OnFormLoad);
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            table.DataSource = manager.plannedCommands;

            var a = new Node("City 1", 0);
            a.components.Add(new MilitaryComponent(10, 1));


            var b = new Node("City 2", 1);
            var road = new Edge("Road", 2, a, b, 0.1f, 1);
            a.TryConnect(b, road);
            manager.factions.Add(4, new Faction());
            manager.mapElements.Add(a.id, a);
            manager.mapElements.Add(b.id, b);
            manager.mapElements.Add(road.id, road);
            activeComands.DataSource = manager.activeCommands;
            manager.turnOrder.Add(4);

            army = new Army(3, 100, 0, 5, 100, 0, a, "Army");
            a.AcceptArmy(army);
            nodeSelection.Items.AddRange((army.currentPosition as Node).GetConnectedNodes().ToArray());
            nodeSelection.ValueMember = "Name";
            nodeSelection.Update();
            DisplayArmyState(army);
        }
        private void DisplayArmyState(Army army)
        {
            string state = $"Армія під назвою {army.name} знаходиться у {army.currentPosition.Name}.";

            armyState.Text = state;

            armyState.Update();
        }

        private void giveOrder_Click(object sender, EventArgs e)
        {
            manager.AddCommand(new MoveCommand(army, (Node)nodeSelection.SelectedItem));
            table.DataSource = null;

            table.DataSource = manager.plannedCommands;
            table.Update();
        }

        private void nextTurn_Click(object sender, EventArgs e)
        {
            manager.EndTurn();
            table.DataSource = null;
            activeComands.DataSource = null;
            activeComands.DataSource = manager.activeCommands;
            DisplayArmyState(army);
            Update();
        }
    }
}
