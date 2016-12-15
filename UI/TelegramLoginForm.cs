using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace UI
{
    public partial class TelegramLoginForm : Form
    {
        TelegramManager telegram;
        Action<bool, string> callback;

        public TelegramLoginForm()
        {
            InitializeComponent();
            requestCodeButton.Enabled = false;
            sendCodeButton.Enabled = false;
            telegram = TelegramManager.GetInstance();

            callback = (success, message) =>
            {
                if (!success)
                {
                    MessageBox.Show(message, "Ошибка");
                }
            };
        }

        private void TelegramLoginForm_Load(object sender, EventArgs e)
        {
            phoneTextBox.Mask = "0-000-000-00-00";
        }

        private void requestCodeButton_Click(object sender, EventArgs e)
        {
            var phone = phoneTextBox.Text.Replace("-", "");
            telegram.CodeRequest(phone, callback);
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            requestCodeButton.Enabled = phoneTextBox.Text.Length == 15;
        }

        private void sendCodeButton_Click(object sender, EventArgs e)
        {
            telegram.Auth(codeTextBox.Text, callback);
        }

        private void codeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (codeTextBox.Text.Length == 5 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            sendCodeButton.Enabled = codeTextBox.Text.Length == 5;
        }
    }
}
