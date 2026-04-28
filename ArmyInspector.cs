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

        public void DisplayInfo(Army army, Command asociatedCommand)
        {
            armyName.Text = army.name;

            string description = $"контролюються фракцією {army.id}" +
                $"Юніти: {army.units}/{army.unitCap}\n" +
                $"Рівень досвіду: {army.exp}/{army.expCap}\n";

            if(army.currentPosition is Node node)  
            {
                if (node.isContested)
                {
                    description += $"Б'ється у {node.Name}";
                }
                else
                {
                    description += $"Знаходиться у: {node.Name}";
                }
            }
            else if(army.currentPosition is Edge edge){
                if(asociatedCommand == null)
                {
                    throw new Exception("Армія знаходиться на ребрі без команди!");

                }
                if (asociatedCommand.description == null || asociatedCommand.description == string.Empty)
                    throw new Exception("Відсутній опис команди!");
                description += asociatedCommand.description;
            }
            

        }
    }
}
