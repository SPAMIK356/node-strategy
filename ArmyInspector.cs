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
        Action<MapElement> OnLinkLabelClicked;
        Action<Command> OnGiveOrderClicked;
        private MapElement armyPosition;
        private int factionId;
        private Army inspectedArmy;

        public ArmyInspector()
        {
            InitializeComponent();
        }

        public void DisplayInfo(Army army, Command? asociatedCommand, int perspective)
        {
            factionId = perspective;
            armyPosition = army.currentPosition;
            inspectedArmy = army;

            armyName.Text = army.name;

            if (perspective != army.controledBy) SetInteractiveElements(false);
            else SetInteractiveElements(true);

            string description = $"контролюються фракцією {army.controledBy}" +
                $"Юніти: {army.units}/{army.unitCap}\n" +
                $"Рівень досвіду: {army.exp}/{army.expCap}\n";
            if (army.controledBy != perspective) SetInteractiveElements(false);
            if (army.currentPosition is Node node)
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
            else if (army.currentPosition is Edge edge)
            {
                if (asociatedCommand == null)
                {
                    throw new Exception("Армія знаходиться на ребрі без команди!");

                }
                if (asociatedCommand.description == null || asociatedCommand.description == string.Empty)
                    throw new Exception("Відсутній опис команди!");
                description += asociatedCommand.description;
            }


        }

        private void SetInteractiveElements(bool state)
        {
            moveOrder.Enabled = state;
            nodeSelection.Enabled = state;
        }

        private void currentPosition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Visible = false;
            OnLinkLabelClicked?.Invoke(armyPosition);
        }

        private void moveOrder_Click(object sender, EventArgs e)
        {
            if(nodeSelection.SelectedItem == null)
            {
                throw new ArgumentNullException("Неможливо віддати команду без вибраної вершини!");
            }

            OnGiveOrderClicked?.Invoke(new MoveCommand(factionId, inspectedArmy, nodeSelection.SelectedItem as Node));
        }
    }
}
