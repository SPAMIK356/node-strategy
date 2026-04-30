
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
            manager.factions[0].ModifyGold(1000);
            InitializeComponent();
            node = new Node("Арциз", IDReg.NextID, 0);
            node.AddComponent(new MilitaryComponent(10, 1));
            manager.mapElements.Add(node.id, node);
            template = new ArmyTemplate()
            {
                Name = "Лісові тварюки",
                Exp = 1,
                ExpCap = 4,
                Units = 100,
                UnitsCap = 100
            };
            cityInspector.OnRecruitButtonClicked += node =>
            {
                manager.AddCommand(new RecruitCommand(manager.currentFaction.id, node, template, manager.currentFaction));
            };

            armyInspector.LinkLabelClicked += element =>
            {
                try
                {
                    cityInspector.DisplayInfo(element, manager.currentFaction);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            armyInspector.GiveOrderClicked += command => { manager.AddCommand(command); };

            cityInspector.DisplayInfo(node, manager.currentFaction);

            TableSetup();
            mapTable.Update();
            armiesTable.Update();
        }
        private void TableSetup()
        {
            MapElementsTabUpdate();


            ArmiesTabUpdate();

        }
        private void MapElementsTabUpdate()
        {
            mapTable.DataSource = null;

            mapTable.DataSource = manager.mapElements.Values.ToList();
            mapTable.Columns["id"]?.Visible = false;
            mapTable.Columns["isContested"]?.Visible = false;
            mapTable.Columns["controledBy"]?.HeaderText = "Під контролем";
            mapTable.Columns["Name"]?.HeaderText = "Назва";
            mapTable.Columns["GoldGain"]?.HeaderText = "Дохід золота";
        }

        private void ArmiesTabUpdate()
        {
            armiesTable.DataSource = null;

            armiesTable.DataSource = manager.GetAllArmies();
            armiesTable.Columns["Id"]?.Visible = false;
            armiesTable.Columns["Name"]?.HeaderText = "Назва";
            armiesTable.Columns["Units"]?.HeaderText = "Кількість";
            armiesTable.Columns["UnitCap"]?.HeaderText = "Макс. юнітів";
            armiesTable.Columns["Exp"]?.HeaderText = "Досвід";
            armiesTable.Columns["ExpCap"]?.HeaderText = "Макс. досвід";
            armiesTable.Columns["ControledBy"]?.HeaderText = "Під контролем";
            armiesTable.Columns["CurrentPosition"]?.Visible = false;
            armiesTable.Columns["CurrentPositionName"]?.HeaderText = "Позиція";
            armiesTable.Columns["IsDead"]?.Visible = false;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    MapElementsTabUpdate();
                    break;

                case 1:
                    ArmiesTabUpdate();
                    break;
            }
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

        private void FullUpdate()
        {
            MapElementsTabUpdate();
            ArmiesTabUpdate();
        }
    }
}
