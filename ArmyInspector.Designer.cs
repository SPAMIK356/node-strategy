namespace NodeStrategy
{
    partial class ArmyInspector
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
            moveOrder = new Button();
            description = new Label();
            armyName = new Label();
            nodeSelection = new ComboBox();
            label1 = new Label();
            currentPosition = new LinkLabel();
            SuspendLayout();
            // 
            // moveOrder
            // 
            moveOrder.Enabled = false;
            moveOrder.Location = new Point(16, 752);
            moveOrder.Name = "moveOrder";
            moveOrder.Size = new Size(281, 41);
            moveOrder.TabIndex = 5;
            moveOrder.Text = "Пересунути армію";
            moveOrder.UseVisualStyleBackColor = true;
            moveOrder.Click += moveOrder_Click;
            // 
            // description
            // 
            description.AutoSize = true;
            description.Font = new Font("Segoe UI", 9F);
            description.Location = new Point(16, 112);
            description.Name = "description";
            description.Size = new Size(83, 20);
            description.TabIndex = 4;
            description.Text = "description";
            // 
            // armyName
            // 
            armyName.AutoSize = true;
            armyName.Font = new Font("Segoe UI", 14F);
            armyName.Location = new Point(16, 24);
            armyName.Name = "armyName";
            armyName.Size = new Size(131, 32);
            armyName.TabIndex = 3;
            armyName.Text = "armyName";
            // 
            // nodeSelection
            // 
            nodeSelection.FormattingEnabled = true;
            nodeSelection.Location = new Point(16, 661);
            nodeSelection.Name = "nodeSelection";
            nodeSelection.Size = new Size(281, 28);
            nodeSelection.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(16, 68);
            label1.Name = "label1";
            label1.Size = new Size(147, 28);
            label1.TabIndex = 7;
            label1.Text = "Розташування:";
            // 
            // currentPosition
            // 
            currentPosition.AutoSize = true;
            currentPosition.Font = new Font("Segoe UI", 12F);
            currentPosition.Location = new Point(155, 68);
            currentPosition.Name = "currentPosition";
            currentPosition.Size = new Size(144, 28);
            currentPosition.TabIndex = 8;
            currentPosition.TabStop = true;
            currentPosition.Text = "currentPosition";
            currentPosition.LinkClicked += currentPosition_LinkClicked;
            // 
            // ArmyInspector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(currentPosition);
            Controls.Add(label1);
            Controls.Add(nodeSelection);
            Controls.Add(moveOrder);
            Controls.Add(description);
            Controls.Add(armyName);
            Name = "ArmyInspector";
            Size = new Size(317, 1080);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button moveOrder;
        private Label description;
        private Label armyName;
        private ComboBox nodeSelection;
        private Label label1;
        private LinkLabel currentPosition;
    }
}
