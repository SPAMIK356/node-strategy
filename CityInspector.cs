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
                SetInteractiveElements(false);
            }
            else
            {
                SetInteractiveElements(true);
            }
            if (mapElement is Edge || forFaction.Gold < 150) //TODO: поміняти магічне число на щось нормальне, для мвп не критично
            {
                recruitArmy.Enabled = false;
            }
            else
            {
                recruitArmy.Enabled = true;
            }


            Update();
        }
        private void SetInteractiveElements(bool state)
        {
            recruitArmy.Enabled = state;
            upgrade.Enabled = state;
        }
        private void recruitArmy_Click(object sender, EventArgs e)
        {
            OnRecruitButtonClicked?.Invoke(inspectedElement as Node);
        }
    }
}
