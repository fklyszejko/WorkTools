namespace Schedule
{
    partial class MainForm
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
            monthLabel = new Label();
            yearLabel = new Label();
            depotLabel = new Label();
            monthComboBox = new ComboBox();
            yearComboBox = new ComboBox();
            depotComboBox = new ComboBox();
            inputRichTextBox = new RichTextBox();
            convertButton = new Button();
            exitButton = new Button();
            SuspendLayout();
            // 
            // monthLabel
            // 
            monthLabel.Location = new Point(54, 12);
            monthLabel.Margin = new Padding(3);
            monthLabel.Name = "monthLabel";
            monthLabel.Size = new Size(100, 23);
            monthLabel.TabIndex = 0;
            monthLabel.Text = "Miesiąc:";
            monthLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // yearLabel
            // 
            yearLabel.Location = new Point(287, 12);
            yearLabel.Margin = new Padding(3);
            yearLabel.Name = "yearLabel";
            yearLabel.Size = new Size(100, 23);
            yearLabel.TabIndex = 1;
            yearLabel.Text = "Rok:";
            yearLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // depotLabel
            // 
            depotLabel.Location = new Point(520, 12);
            depotLabel.Margin = new Padding(3);
            depotLabel.Name = "depotLabel";
            depotLabel.Size = new Size(100, 23);
            depotLabel.TabIndex = 2;
            depotLabel.Text = "Zakład:";
            depotLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // monthComboBox
            // 
            monthComboBox.FormattingEnabled = true;
            monthComboBox.Items.AddRange(new object[] { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" });
            monthComboBox.Location = new Point(160, 12);
            monthComboBox.Name = "monthComboBox";
            monthComboBox.Size = new Size(121, 23);
            monthComboBox.TabIndex = 3;
            // 
            // yearComboBox
            // 
            yearComboBox.FormattingEnabled = true;
            yearComboBox.Location = new Point(393, 12);
            yearComboBox.Name = "yearComboBox";
            yearComboBox.Size = new Size(121, 23);
            yearComboBox.TabIndex = 4;
            // 
            // depotComboBox
            // 
            depotComboBox.FormattingEnabled = true;
            depotComboBox.Items.AddRange(new object[] { "R1", "R2", "R3", "R4", "R5" });
            depotComboBox.Location = new Point(626, 12);
            depotComboBox.Name = "depotComboBox";
            depotComboBox.Size = new Size(121, 23);
            depotComboBox.TabIndex = 5;
            depotComboBox.SelectedValueChanged += DepotComboBox_SelectedValueChanged;
            // 
            // inputRichTextBox
            // 
            inputRichTextBox.Location = new Point(12, 41);
            inputRichTextBox.Name = "inputRichTextBox";
            inputRichTextBox.Size = new Size(776, 335);
            inputRichTextBox.TabIndex = 6;
            inputRichTextBox.Text = "";
            // 
            // convertButton
            // 
            convertButton.Location = new Point(322, 382);
            convertButton.Name = "convertButton";
            convertButton.Size = new Size(75, 23);
            convertButton.TabIndex = 7;
            convertButton.Text = "Konwertuj";
            convertButton.UseVisualStyleBackColor = true;
            convertButton.Click += ConvertButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(403, 382);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 8;
            exitButton.Text = "Zakończ";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 416);
            Controls.Add(exitButton);
            Controls.Add(convertButton);
            Controls.Add(inputRichTextBox);
            Controls.Add(depotComboBox);
            Controls.Add(yearComboBox);
            Controls.Add(monthComboBox);
            Controls.Add(depotLabel);
            Controls.Add(yearLabel);
            Controls.Add(monthLabel);
            Name = "MainForm";
            Text = "Konwenter danych grafiku";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label monthLabel;
        private Label yearLabel;
        private Label depotLabel;
        private ComboBox monthComboBox;
        private ComboBox yearComboBox;
        private ComboBox depotComboBox;
        private RichTextBox inputRichTextBox;
        private Button convertButton;
        private Button exitButton;
    }
}
