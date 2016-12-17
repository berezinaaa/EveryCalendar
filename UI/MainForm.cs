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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var telegram = TelegramManager.GetInstance();
            telegram.SendMessage("hello world");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var editForm = new EditEventForm();
            editForm.ShowDialog();
        }
    }
}
