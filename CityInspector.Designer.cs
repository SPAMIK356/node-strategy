namespace NodeStrategy
{
    partial class CityInspector
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cityName = new Label();
            description = new Label();
            upgrade = new Button();
            recruitArmy = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // cityName
            // 
            cityName.AutoSize = true;
            cityName.Font = new Font("Segoe UI", 14F);
            cityName.Location = new Point(16, 24);
            cityName.Name = "cityName";
            cityName.Size = new Size(115, 32);
            cityName.TabIndex = 0;
            cityName.Text = "cityName";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Font = new Font("Segoe UI", 9F);
            description.Location = new Point(16, 74);
            description.Name = "description";
            description.Size = new Size(83, 20);
            description.TabIndex = 1;
            description.Text = "description";
            // 
            // upgrade
            // 
            upgrade.Enabled = false;
            upgrade.Location = new Point(16, 752);
            upgrade.Name = "upgrade";
            upgrade.Size = new Size(281, 41);
            upgrade.TabIndex = 2;
            upgrade.Text = "Покращити";
            upgrade.UseVisualStyleBackColor = true;
            // 
            // recruitArmy
            // 
            recruitArmy.Location = new Point(16, 824);
            recruitArmy.Name = "recruitArmy";
            recruitArmy.Size = new Size(281, 41);
            recruitArmy.TabIndex = 3;
            recruitArmy.Text = "Найняти армію";
            recruitArmy.UseVisualStyleBackColor = true;
            recruitArmy.Click += recruitArmy_Click;
            // 
            // CityInspector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(recruitArmy);
            Controls.Add(upgrade);
            Controls.Add(description);
            Controls.Add(cityName);
            Name = "CityInspector";
            Size = new Size(317, 1033);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cityName;
        private Label description;
        private Button upgrade;
        private Button recruitArmy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
