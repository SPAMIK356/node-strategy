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

        public void DisplayInfo(Army army)
        {
            armyName.Text = army.name;

            string description = $"контролюються фракцією {army.id}" +
                $"Юніти: {army.units}/{army.unitCap}\n" +
                $"Рівень досвіду: {army.exp}/{army.expCap}";
        }
    }
}
