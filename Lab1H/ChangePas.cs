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
    public partial class ChangePas : Form
    {
        public ChangePas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != Global.pas)
            {
                label4.Text = "Неверный старый пароль";
            }
            else
            {
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
                    if (Char.IsSymbol(textBox2.Text[i]) || (textBox2.Text[i] == '-') || (textBox2.Text[i] == '*') || (textBox2.Text[i] == '/')) //
                    {
                        flagS = true;
                    }
                }
                if (flagL && flagU && flagS && flagD) flag = true;
                //---------------
                label4.Text = "";
                string NewPas = textBox2.Text;
                string NewPas1 = textBox3.Text;
                if (NewPas != NewPas1)
                {
                    label4.Text = "Пароли не совпадают";
                }
                else if (NewPas.Length > 1)
                {
                    if (!Global.limitK)
                    {

                        Global.ChangePas(Global.k, NewPas);
                        Close();
                    }
                    else if (Global.limitK && flag)
                    {
                        label4.Text = "";
                        Global.ChangePas(Global.k, NewPas);
                        Close();
                    }
                    else { label4.Text = "Пароль не отвечает ограничениям"; }
                }
                else { label4.Text = "Пароль не отвечает ограничениям"; }

            }
        }
    }
}
