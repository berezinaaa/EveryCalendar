using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class TelegramLoginForm : Form
    {
        public TelegramLoginForm()
        {
            InitializeComponent();
        }

        private void TelegramLoginForm_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "0-000-000-00-00";
        }
    }
}
