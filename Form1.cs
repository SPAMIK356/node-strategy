
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
                manager.AddCommand(new RecruitCommand(manager.CurrentFaction.id, node, template, manager.CurrentFaction));
            };

            manager.TurnEnd += FullUpdate;

            armyInspector.LinkLabelClicked += element =>
            {
                try
                {
                    cityInspector.DisplayInfo(element, manager.CurrentFaction);
                    tabControl1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            armyInspector.GiveOrderClicked += command => { manager.AddCommand(command); };

            cityInspector.DisplayInfo(node, manager.CurrentFaction);



            FullUpdate();
        }
        private void HeaderTextUpdate()
        {
            int gpt = manager.GetGoldPerTurn(manager.CurrentFaction);
            Text = $"Фракція {manager.CurrentFaction} | {manager.CurrentFaction.Gold} золота ({(gpt > 0 ? $"+{gpt}" : gpt)} за хід)";
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
                    cityInspector.Visible = mapTable.Rows.Count > 0 ? true : false;
                    armyInspector.Visible = false;
                    break;

                case 1:
                    ArmiesTabUpdate();
                    cityInspector.Visible = false;

                    armyInspector.Visible = armiesTable.Rows.Count > 0 ? true : false;

                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void endTurn_Click(object sender, EventArgs e)
        {
            manager.EndTurn();
            cityInspector.DisplayInfo(node, manager.CurrentFaction);
            Update();
        }

        private void FullUpdate()
        {
            MapElementsTabUpdate();
            ArmiesTabUpdate();
            HeaderTextUpdate();
        }

        private void mapTable_SelectionChanged(object sender, EventArgs e)
        {
            if (mapTable.SelectedRows.Count > 0)
            {
                var selectedRow = mapTable.SelectedRows[0];

                var element = selectedRow.DataBoundItem as MapElement;

                cityInspector.DisplayInfo(element, manager.CurrentFaction);
            }
        }

        private void armiesTable_SelectionChanged(object sender, EventArgs e)
        {
            if (armiesTable.SelectedRows.Count > 0)
            {
                var selectedRow = armiesTable.SelectedRows[0];

                var element = selectedRow.DataBoundItem as Army;

                armyInspector.DisplayInfo(element, manager.activeCommands
                    .OfType<ITargetedCommand>()
                    .Where(x => x.subjectId == element.Id)
                    .FirstOrDefault() as Command
                    , manager.CurrentFaction.id);
            }
            else
            {
                armyInspector.Visible = false;
            }
        }
    }
}
