namespace UI
{
    partial class EditEventForm
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
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dayPicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.telegramCheckBox = new System.Windows.Forms.CheckBox();
            this.smsCheckBox = new System.Windows.Forms.CheckBox();
            this.completeButton = new System.Windows.Forms.Button();
            this.visualCheckbox = new System.Windows.Forms.CheckBox();
            this.repeatTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.repeatCheckbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(75, 10);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Начало";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Конец";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "HH:mm";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(75, 36);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startTimePicker.TabIndex = 9;
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "HH:mm";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(75, 62);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endTimePicker.TabIndex = 10;
            // 
            // dayPicker
            // 
            this.dayPicker.Location = new System.Drawing.Point(76, 91);
            this.dayPicker.Name = "dayPicker";
            this.dayPicker.Size = new System.Drawing.Size(200, 20);
            this.dayPicker.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "День";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(75, 117);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(200, 63);
            this.descriptionTextBox.TabIndex = 13;
            this.descriptionTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Описание";
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.FormattingEnabled = true;
            this.priorityComboBox.Items.AddRange(new object[] {
            "Низкий",
            "Обычный",
            "Высокий"});
            this.priorityComboBox.Location = new System.Drawing.Point(75, 186);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(127, 21);
            this.priorityComboBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Приоритет";
            // 
            // telegramCheckBox
            // 
            this.telegramCheckBox.AutoSize = true;
            this.telegramCheckBox.Location = new System.Drawing.Point(116, 256);
            this.telegramCheckBox.Name = "telegramCheckBox";
            this.telegramCheckBox.Size = new System.Drawing.Size(70, 17);
            this.telegramCheckBox.TabIndex = 17;
            this.telegramCheckBox.Text = "Telegram";
            this.telegramCheckBox.UseVisualStyleBackColor = true;
            // 
            // smsCheckBox
            // 
            this.smsCheckBox.AutoSize = true;
            this.smsCheckBox.Location = new System.Drawing.Point(116, 279);
            this.smsCheckBox.Name = "smsCheckBox";
            this.smsCheckBox.Size = new System.Drawing.Size(49, 17);
            this.smsCheckBox.TabIndex = 18;
            this.smsCheckBox.Text = "SMS";
            this.smsCheckBox.UseVisualStyleBackColor = true;
            // 
            // completeButton
            // 
            this.completeButton.Location = new System.Drawing.Point(162, 367);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(111, 24);
            this.completeButton.TabIndex = 19;
            this.completeButton.UseVisualStyleBackColor = true;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // visualCheckbox
            // 
            this.visualCheckbox.AutoSize = true;
            this.visualCheckbox.Location = new System.Drawing.Point(116, 233);
            this.visualCheckbox.Name = "visualCheckbox";
            this.visualCheckbox.Size = new System.Drawing.Size(86, 17);
            this.visualCheckbox.TabIndex = 20;
            this.visualCheckbox.Text = "Визуальное";
            this.visualCheckbox.UseVisualStyleBackColor = true;
            // 
            // repeatTimePicker
            // 
            this.repeatTimePicker.CustomFormat = "HH:mm";
            this.repeatTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.repeatTimePicker.Location = new System.Drawing.Point(97, 341);
            this.repeatTimePicker.Name = "repeatTimePicker";
            this.repeatTimePicker.ShowUpDown = true;
            this.repeatTimePicker.Size = new System.Drawing.Size(182, 20);
            this.repeatTimePicker.TabIndex = 22;
            this.repeatTimePicker.Value = new System.DateTime(2016, 12, 18, 0, 10, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "с интервалом";
            // 
            // repeatCheckbox
            // 
            this.repeatCheckbox.AutoSize = true;
            this.repeatCheckbox.Location = new System.Drawing.Point(17, 327);
            this.repeatCheckbox.Name = "repeatCheckbox";
            this.repeatCheckbox.Size = new System.Drawing.Size(80, 17);
            this.repeatCheckbox.TabIndex = 25;
            this.repeatCheckbox.Text = "Повторять";
            this.repeatCheckbox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Уведомления";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 403);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.repeatCheckbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.repeatTimePicker);
            this.Controls.Add(this.visualCheckbox);
            this.Controls.Add(this.completeButton);
            this.Controls.Add(this.smsCheckBox);
            this.Controls.Add(this.telegramCheckBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.priorityComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.dayPicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleTextBox);
            this.Name = "EditEventForm";
            this.Text = "EditEventForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditEventForm_FormClosed);
            this.Load += new System.EventHandler(this.EditEventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.DateTimePicker dayPicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox telegramCheckBox;
        private System.Windows.Forms.CheckBox smsCheckBox;
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.CheckBox visualCheckbox;
        private System.Windows.Forms.DateTimePicker repeatTimePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox repeatCheckbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}