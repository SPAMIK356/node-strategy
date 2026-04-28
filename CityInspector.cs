using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace NodeStrategy
{

    public partial class CityInspector : UserControl
    {
        public MapElement inspectedElement;
        public event Action<Node> OnRecruitButtonClicked;
        public CityInspector()
        {
            InitializeComponent();
        }
        public void DisplayInfo(MapElement mapElement, Faction forFaction)
        {
            inspectedElement = mapElement;
            cityName.Text = mapElement.Name;

            description.Text = mapElement.GetDescription();

            Visible = true;
            if(forFaction.id != mapElement.controledBy)
            {
                recruitArmy.Enabled = false;
                upgrade.Enabled = false;
            }

            if (mapElement is Edge)
            {
                recruitArmy.Enabled = false;
            }
            else
            {
                recruitArmy.Enabled = true;
            }


            Update();
        }

        private void recruitArmy_Click(object sender, EventArgs e)
        {
            OnRecruitButtonClicked?.Invoke(inspectedElement as Node);
        }
    }
}
