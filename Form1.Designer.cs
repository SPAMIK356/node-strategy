namespace NodeStrategy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            endTurn = new Button();
            cityInspector = new CityInspector();
            armyInspector = new ArmyInspector();
            tabControl1 = new TabControl();
            mapTab = new TabPage();
            mapTable = new DataGridView();
            armiesTab = new TabPage();
            armiesTable = new DataGridView();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            додаToolStripMenuItem = new ToolStripMenuItem();
            addNames = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            mapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mapTable).BeginInit();
            armiesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)armiesTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // endTurn
            // 
            endTurn.Cursor = Cursors.Hand;
            endTurn.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            endTurn.Location = new Point(25, 852);
            endTurn.Name = "endTurn";
            endTurn.Size = new Size(474, 151);
            endTurn.TabIndex = 1;
            endTurn.Text = "Завершити Хід";
            endTurn.UseVisualStyleBackColor = true;
            endTurn.Click += endTurn_Click;
            // 
            // cityInspector
            // 
            cityInspector.Location = new Point(1507, 1);
            cityInspector.Name = "cityInspector";
            cityInspector.Size = new Size(396, 1080);
            cityInspector.TabIndex = 2;
            cityInspector.Visible = false;
            // 
            // armyInspector
            // 
            armyInspector.Location = new Point(1507, 1);
            armyInspector.Name = "armyInspector";
            armyInspector.Size = new Size(396, 1080);
            armyInspector.TabIndex = 3;
            armyInspector.Visible = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(mapTab);
            tabControl1.Controls.Add(armiesTab);
            tabControl1.Location = new Point(525, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(976, 1020);
            tabControl1.TabIndex = 4;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // mapTab
            // 
            mapTab.Controls.Add(mapTable);
            mapTab.Location = new Point(4, 29);
            mapTab.Name = "mapTab";
            mapTab.Padding = new Padding(3);
            mapTab.Size = new Size(968, 987);
            mapTab.TabIndex = 0;
            mapTab.Text = "Мапа";
            mapTab.UseVisualStyleBackColor = true;
            // 
            // mapTable
            // 
            mapTable.AllowUserToAddRows = false;
            mapTable.AllowUserToDeleteRows = false;
            mapTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mapTable.Dock = DockStyle.Fill;
            mapTable.Location = new Point(3, 3);
            mapTable.Name = "mapTable";
            mapTable.ReadOnly = true;
            mapTable.RowHeadersWidth = 51;
            mapTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mapTable.Size = new Size(962, 981);
            mapTable.TabIndex = 0;
            mapTable.SelectionChanged += mapTable_SelectionChanged;
            // 
            // armiesTab
            // 
            armiesTab.Controls.Add(armiesTable);
            armiesTab.Location = new Point(4, 29);
            armiesTab.Name = "armiesTab";
            armiesTab.Padding = new Padding(3);
            armiesTab.Size = new Size(968, 987);
            armiesTab.TabIndex = 1;
            armiesTab.Text = "Армії";
            armiesTab.UseVisualStyleBackColor = true;
            // 
            // armiesTable
            // 
            armiesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            armiesTable.Dock = DockStyle.Fill;
            armiesTable.Location = new Point(3, 3);
            armiesTable.Name = "armiesTable";
            armiesTable.RowHeadersWidth = 51;
            armiesTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            armiesTable.Size = new Size(962, 981);
            armiesTable.TabIndex = 0;
            armiesTable.SelectionChanged += armiesTable_SelectionChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-7, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(533, 805);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { додаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1902, 28);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // додаToolStripMenuItem
            // 
            додаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addNames });
            додаToolStripMenuItem.Name = "додаToolStripMenuItem";
            додаToolStripMenuItem.Size = new Size(125, 24);
            додаToolStripMenuItem.Text = "Налаштування";
            // 
            // addNames
            // 
            addNames.Name = "addNames";
            addNames.Size = new Size(224, 26);
            addNames.Text = "Додати імена";
            addNames.Click += addNames_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(pictureBox1);
            Controls.Add(tabControl1);
            Controls.Add(armyInspector);
            Controls.Add(cityInspector);
            Controls.Add(endTurn);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            mapTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mapTable).EndInit();
            armiesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)armiesTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CityInspector cityInspector1;
        private Button endTurn;
        private CityInspector cityInspector;
        private ArmyInspector armyInspector;
        private TabControl tabControl1;
        private TabPage mapTab;
        private TabPage armiesTab;
        private DataGridView mapTable;
        private DataGridView armiesTable;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem додаToolStripMenuItem;
        private ToolStripMenuItem addNames;
    }
}
