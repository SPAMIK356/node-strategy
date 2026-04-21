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
            nextTurn = new Button();
            armyState = new Label();
            table = new DataGridView();
            nodeSelection = new ComboBox();
            giveOrder = new Button();
            activeComands = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)table).BeginInit();
            ((System.ComponentModel.ISupportInitialize)activeComands).BeginInit();
            SuspendLayout();
            // 
            // nextTurn
            // 
            nextTurn.Location = new Point(71, 337);
            nextTurn.Name = "nextTurn";
            nextTurn.Size = new Size(136, 46);
            nextTurn.TabIndex = 0;
            nextTurn.Text = "Наступний хід";
            nextTurn.UseVisualStyleBackColor = true;
            nextTurn.Click += nextTurn_Click;
            // 
            // armyState
            // 
            armyState.AutoSize = true;
            armyState.Location = new Point(36, 38);
            armyState.Name = "armyState";
            armyState.Size = new Size(50, 20);
            armyState.TabIndex = 1;
            armyState.Text = "label1";
            // 
            // table
            // 
            table.AllowUserToAddRows = false;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Location = new Point(287, 215);
            table.Name = "table";
            table.RowHeadersWidth = 51;
            table.Size = new Size(468, 223);
            table.TabIndex = 2;
            // 
            // nodeSelection
            // 
            nodeSelection.FormattingEnabled = true;
            nodeSelection.Location = new Point(38, 131);
            nodeSelection.Name = "nodeSelection";
            nodeSelection.Size = new Size(61, 28);
            nodeSelection.TabIndex = 3;
            // 
            // giveOrder
            // 
            giveOrder.Location = new Point(71, 259);
            giveOrder.Name = "giveOrder";
            giveOrder.Size = new Size(114, 34);
            giveOrder.TabIndex = 4;
            giveOrder.Text = "Віддати наказ";
            giveOrder.UseVisualStyleBackColor = true;
            giveOrder.Click += giveOrder_Click;
            // 
            // activeComands
            // 
            activeComands.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            activeComands.Location = new Point(297, 89);
            activeComands.Name = "activeComands";
            activeComands.RowHeadersWidth = 51;
            activeComands.Size = new Size(453, 119);
            activeComands.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(activeComands);
            Controls.Add(giveOrder);
            Controls.Add(nodeSelection);
            Controls.Add(table);
            Controls.Add(armyState);
            Controls.Add(nextTurn);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)table).EndInit();
            ((System.ComponentModel.ISupportInitialize)activeComands).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button nextTurn;
        private Label armyState;
        private DataGridView table;
        private ComboBox nodeSelection;
        private Button giveOrder;
        private DataGridView activeComands;
    }
}
