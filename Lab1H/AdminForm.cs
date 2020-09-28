using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1H
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePas adminNewPas = new ChangePas();
            adminNewPas.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Global.closeFlag = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllUsers aus = new AllUsers();
            aus.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddUser newUs = new AddUser();
            newUs.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (Global.userFlag)
            {
                button2.Enabled = false;
                button3.Enabled = false;

            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}
