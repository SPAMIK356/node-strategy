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
        public CityInspector()
        {
            InitializeComponent();
        }

        public void DisplayInfo(MapElement mapElement)
        {
            cityName.Text = mapElement.Name;

            description.Text = mapElement.GetDescription();
            
            Enabled = true;

            if(mapElement is Edge)
            {
                recruitArmy.Enabled = false;
            }
            else
            {
                recruitArmy.Enabled = true;
            }


            Update();
        }
    }
}
