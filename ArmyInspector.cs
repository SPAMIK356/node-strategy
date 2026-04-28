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
        public ArmyInspector()
        {
            InitializeComponent();
        }

        public void DisplayInfo(Army army, Command? asociatedCommand, int perspective)
        {
            armyName.Text = army.name;

            if (perspective != army.controledBy) SetInteractiveElements(false);
            else SetInteractiveElements(true);

            string description = $"контролюються фракцією {army.controledBy}" +
                $"Юніти: {army.units}/{army.unitCap}\n" +
                $"Рівень досвіду: {army.exp}/{army.expCap}\n";

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

                    }
                    else
                    {
                        SetInteractiveElements(false);
                    }
                }
            }
            else if (army.currentPosition is Edge edge) {
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
    }
}
