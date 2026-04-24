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

        public void DisplayInfo(Node node)
        {
            cityName.Text = node.Name;

            description.Text = node.GetDescription();
            
            Enabled = true;

            Update();
        }
    }
}
