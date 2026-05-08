using System;
using System.IO;
using System.Windows.Forms;

namespace NodeStrategy
{
    public partial class AddNamesForm : Form
    {
        public AddNamesForm()
        {
            InitializeComponent();

            typeComboBox.Items.Add("Міста (CityNames.txt)");
            typeComboBox.Items.Add("Армії (ArmyNames.txt)");
            typeComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            string newName = nameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Ім'я не може бути порожнім!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string fileName = typeComboBox.SelectedIndex == 0 ? "CityNames.txt" : "ArmyNames.txt";

            try
            {
                File.AppendAllText(fileName, newName + Environment.NewLine);

                MessageBox.Show($"Ім'я '{newName}' успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка запису у файл: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}