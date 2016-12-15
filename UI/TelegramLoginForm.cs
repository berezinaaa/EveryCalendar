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
        public TelegramLoginForm()
        {
            InitializeComponent();
            requestCodeButton.Enabled = false;
            TelegramManager.GetInstance();
        }

        private void TelegramLoginForm_Load(object sender, EventArgs e)
        {
            phoneTextBox.Mask = "0-000-000-00-00";
        }

        private void requestCodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var phone = phoneTextBox.Text.Replace("-", "");
                var telegram = TelegramManager.GetInstance();
                telegram.CodeRequest(phone);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось отправить код на указанный номер", "Ошибка");
            }
 
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            requestCodeButton.Enabled = phoneTextBox.Text.Length == 15;
        }
    }
}
