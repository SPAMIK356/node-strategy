namespace NodeStrategy
{
    partial class AddNamesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameTextBox = new TextBox();
            addButton = new Button();
            typeComboBox = new ComboBox();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(230, 12);
            nameTextBox.Multiline = true;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(387, 304);
            nameTextBox.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(39, 262);
            addButton.Name = "addButton";
            addButton.Size = new Size(152, 54);
            addButton.TabIndex = 1;
            addButton.Text = "Додати імена";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(39, 190);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(152, 28);
            typeComboBox.TabIndex = 2;
            // 
            // AddNamesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 347);
            Controls.Add(typeComboBox);
            Controls.Add(addButton);
            Controls.Add(nameTextBox);
            Name = "AddNamesForm";
            Text = "AddNamesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private Button addButton;
        private ComboBox typeComboBox;
    }
}