using System.Diagnostics;

namespace NodeStrategy
{
    public partial class Form1 : Form
    {
        Node node;
        private TurnManager manager = new();
        ArmyTemplate template;
        public Form1()
        {
            manager.factions.Add(0, new Faction(IDReg.NextID));
            manager.turnOrder.Add(0);
            InitializeComponent();
            node = new Node("Арциз", 0, 0);
            node.AddComponent(new MilitaryComponent(10, 1));

            template = new ArmyTemplate()
            {
                Name = "Лісові тварюки",
                Exp = 1,
                ExpCap = 4,
                Units = 100,
                UnitsCap = 100
            };
            cityInspector.OnRecruitButtonClicked += OnRecruitClick;

            armyInspector.LinkLabelClicked += OnLinkLabelClicked;
            armyInspector.GiveOrderClicked += OnMoveOrderClicked;

            cityInspector.DisplayInfo(node, manager.currentFaction);


        }

        private void OnRecruitClick(Node node)
        {
            manager.AddCommand(new RecruitCommand(manager.currentFaction.id, node, template, manager.currentFaction));
        }
        private void OnLinkLabelClicked(MapElement element)
        {
            try
            {
                cityInspector.DisplayInfo(element, manager.currentFaction);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message,"Помилка!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnMoveOrderClicked(Command command)
        {
            manager.AddCommand(command);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void endTurn_Click(object sender, EventArgs e)
        {
            manager.EndTurn();
            cityInspector.DisplayInfo(node, manager.currentFaction);
            Update();
        }
    }
}
