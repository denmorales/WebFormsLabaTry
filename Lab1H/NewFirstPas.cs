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
    public partial class NewFirstPas : Form
    {
        public NewFirstPas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pas1 = textBox1.Text;
            string pas2 = textBox2.Text;
            label5.Text = "";
            if (pas2 != pas1)
            {
                label5.Text = "Пароли не совпадают";
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (pas2 == pas1)
            {
                label5.Text = "";
                //-------------
                bool flagL = false, flagU = false, flagD = false, flagS = false, flag = false;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (Char.IsLower(textBox2.Text[i]))
                    {
                        flagL = true;
                    }
                    if (Char.IsUpper(textBox2.Text[i]))
                    {
                        flagU = true;
                    }
                    if (Char.IsDigit(textBox2.Text[i]))
                    {
                        flagD = true;
                    }
                    if (Char.IsSymbol(textBox2.Text[i]) || (textBox2.Text[i] == '-') || (textBox2.Text[i] == '*') || (textBox2.Text[i] == '/'))
                    {
                        flagS = true;
                    }
                }
                if (flagL && flagU && flagS && flagD) flag = true;
                //---------------
                if (pas1.Length > 1)
                {
                    if (flag || !Global.limitK)
                    {
                        label5.Text = "";
                        if (Global.log == "admin")
                        {
                            AdminForm fadmin = new AdminForm();
                            Hide();
                            Global.pas = pas1;
                            Global.newPas(0, pas1);


                            fadmin.ShowDialog();
                            Close();
                        }
                        else
                        {
                            AdminForm fuser = new AdminForm();
                            Hide();
                            Global.userFlag = true;
                            Global.pas = pas1;
                            Global.newPas(Global.k, pas1);
                            fuser.ShowDialog();
                            Close();
                        }
                    }
                    else { label5.Text = "Пароль не отвечает ограничениям"; }
                }
                else

                { label5.Text = "Пароль не отвечает ограничениям"; }

            }
        }
    }
}
