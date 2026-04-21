using System.Diagnostics;

namespace NodeStrategy
{
    public partial class Form1 : Form
    {
        private TurnManager manager = new();
        private Army army;
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
