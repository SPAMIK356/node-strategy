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
        public Action<Node> OnRecruitBUttonClicked;
        public CityInspector()
        {
            InitializeComponent();
        }

        public void DisplayInfo(MapElement mapElement)
        {
            inspectedElement = mapElement;
            cityName.Text = mapElement.Name;

            description.Text = mapElement.GetDescription();

            Enabled = true;

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
            OnRecruitBUttonClicked?.Invoke(inspectedElement as Node);
        }
    }
}
