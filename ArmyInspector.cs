using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NodeStrategy
{
    public partial class ArmyInspector : UserControl
    {
        public Action<MapElement> LinkLabelClicked;
        public Action<Command> GiveOrderClicked;
        private MapElement armyPosition;
        private int factionId;
        private Army inspectedArmy;

        public ArmyInspector()
        {
            InitializeComponent();
        }

        public void DisplayInfo(Army army, Command? asociatedCommand, int perspective)
        {
            Visible = true;
            factionId = perspective;
            armyPosition = army.CurrentPosition;
            inspectedArmy = army;

            armyName.Text = army.Name;

            if (perspective != army.ControledBy) SetInteractiveElements(false);
            else SetInteractiveElements(true);

            string description = $"Контролюються фракцією {army.ControledBy}\n" +
                $"Юніти: {army.Units}/{army.UnitCap}\n" +
                $"Рівень досвіду: {army.Exp}/{army.ExpCap}\n";
            if (army.ControledBy != perspective) SetInteractiveElements(false);
            if (army.CurrentPosition is Node node)
            {
                if (node.isContested)
                {
                    description += $"Б'ється у {node.Name}";
                }
                else
                {
                    description += $"Знаходиться у: {node.Name}";
                    if (asociatedCommand != null)
                    {
                        description += asociatedCommand.description;
                        SetInteractiveElements(false);
                    }
                    else
                    {
                        nodeSelection.DataSource = null;
                        nodeSelection.DataSource = node.GetConnectedNodes();
                        nodeSelection.DisplayMember = "Name";
                    }
                }
            }
            else if (army.CurrentPosition is Edge edge)
            {
                if (asociatedCommand == null)
                {
                    throw new Exception("Армія знаходиться на ребрі без команди!");

                }
                if (asociatedCommand.description == null || asociatedCommand.description == string.Empty)
                    throw new Exception("Відсутній опис команди!");
                description += asociatedCommand.description;
            }

            this.description.Text = description;

            currentPosition.Text = army.CurrentPositionName;
        }

        private void SetInteractiveElements(bool state)
        {
            moveOrder.Enabled = state;
            nodeSelection.Enabled = state;
        }

        private void currentPosition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Visible = false;
            LinkLabelClicked?.Invoke(armyPosition);
        }

        private void moveOrder_Click(object sender, EventArgs e)
        {
            if(nodeSelection.SelectedItem == null)
            {
                throw new ArgumentNullException("Неможливо віддати команду без вибраної вершини!");
            }

            GiveOrderClicked?.Invoke(new MoveCommand(factionId, inspectedArmy, nodeSelection.SelectedItem as Node));
        }
    }
}
