using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab1H
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flaf = false;

            string str;

            if (textBox1.Text.Trim() == "")
                label2.Text = "Нельзя создать пользователя без имени";
            else
            {

                int n = File.ReadAllLines("Users.txt").Length;
                string[] name = new string[n];
                FileStream file = new FileStream("Users.txt", FileMode.Open);
                StreamReader fnew = new StreamReader(file);
                for (int t = 0; t < n; t++)
                {
                    int j = 0;
                    str = fnew.ReadLine();
                    while (str[j] != ' ')
                    {
                        j++;

                    }
                    name[t] = str.Substring(0, j);
                    file.Close();
                }
                for (int j = 0; j < name.Length; j++)
                {
                    if (name[j] == textBox1.Text)
                        flaf = true;
                }

                if (!flaf)
                {
                    string newstr = textBox1.Text + ' ' + "" + ' ' + "0" + ' ' + "1";
                    string text = File.ReadAllText("Users.txt");
                    text = text + newstr + "\r\n";
                    File.WriteAllText("Users.txt", text);


                    Close();
                }
                else { label2.Text = "Данный пользователь уже зарегистрирован"; }
            }
        }
    }
}
