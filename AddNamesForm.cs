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

            // Заповнюємо випадаючий список варіантами
            typeComboBox.Items.Add("Міста (CityNames.txt)");
            typeComboBox.Items.Add("Армії (ArmyNames.txt)");
            typeComboBox.SelectedIndex = 0; // Робимо перший пункт вибраним за замовчуванням
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Забираємо текст і обрізаємо зайві пробіли по краях
            string newName = nameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Ім'я не може бути порожнім!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Визначаємо, в який файл писати, залежно від вибраного пункту
            string fileName = typeComboBox.SelectedIndex == 0 ? "CityNames.txt" : "ArmyNames.txt";

            try
            {
                // Дописуємо текст у файл + додаємо перенесення на новий рядок (Environment.NewLine)
                File.AppendAllText(fileName, newName + Environment.NewLine);

                MessageBox.Show($"Ім'я '{newName}' успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTextBox.Clear(); // Очищаємо поле для наступного вводу
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка запису у файл: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}