using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UVM
{
    public partial class PasswordDialog : Form
    {

        private string password;

        public PasswordDialog()
        {
            InitializeComponent();
        }

        public string Password { get => password; set => password = value; }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            Password = PasswordBox.Text;
        }

        private void PasswordDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }
    }
}
