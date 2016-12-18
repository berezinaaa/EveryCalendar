namespace UI
{
    partial class TelegramLoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.requestCodeButton = new System.Windows.Forms.Button();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.sendCodeButton = new System.Windows.Forms.Button();
            this.phoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер телефона";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите полученый код";
            // 
            // requestCodeButton
            // 
            this.requestCodeButton.Location = new System.Drawing.Point(88, 90);
            this.requestCodeButton.Name = "requestCodeButton";
            this.requestCodeButton.Size = new System.Drawing.Size(100, 23);
            this.requestCodeButton.TabIndex = 3;
            this.requestCodeButton.Text = "Прислать код";
            this.requestCodeButton.UseVisualStyleBackColor = true;
            this.requestCodeButton.Click += new System.EventHandler(this.requestCodeButton_Click);
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(88, 155);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(100, 20);
            this.codeTextBox.TabIndex = 4;
            this.codeTextBox.TextChanged += new System.EventHandler(this.codeTextBox_TextChanged);
            this.codeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codeTextBox_KeyPress);
            // 
            // sendCodeButton
            // 
            this.sendCodeButton.Location = new System.Drawing.Point(88, 181);
            this.sendCodeButton.Name = "sendCodeButton";
            this.sendCodeButton.Size = new System.Drawing.Size(100, 23);
            this.sendCodeButton.TabIndex = 5;
            this.sendCodeButton.Text = "Отправить код";
            this.sendCodeButton.UseVisualStyleBackColor = true;
            this.sendCodeButton.Click += new System.EventHandler(this.sendCodeButton_Click);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(88, 64);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex = 6;
            this.phoneTextBox.TextChanged += new System.EventHandler(this.phoneTextBox_TextChanged);
            // 
            // TelegramLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.sendCodeButton);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.requestCodeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TelegramLoginForm";
            this.Text = "Авторизация Telegram";
            this.Load += new System.EventHandler(this.TelegramLoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button requestCodeButton;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Button sendCodeButton;
        private System.Windows.Forms.MaskedTextBox phoneTextBox;
    }
}