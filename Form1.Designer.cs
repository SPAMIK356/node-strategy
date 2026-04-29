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
            SuspendLayout();
            // 
            // endTurn
            // 
            endTurn.Cursor = Cursors.Hand;
            endTurn.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            endTurn.Location = new Point(12, 905);
            endTurn.Name = "endTurn";
            endTurn.Size = new Size(208, 76);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(armyInspector);
            Controls.Add(cityInspector);
            Controls.Add(endTurn);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion
        private CityInspector cityInspector1;
        private Button endTurn;
        private CityInspector cityInspector;
        private ArmyInspector armyInspector;
    }
}
