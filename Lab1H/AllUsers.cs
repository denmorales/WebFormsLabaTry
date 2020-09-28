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
    public partial class AllUsers : Form
    {
        CheckBox[] checkBoxes;
        Label[] labels;

        public AllUsers()
        {
            InitializeComponent();

            string str, name, p1, p2;
            int i = 0, j = 0, k = 0, t = 0;
            int y = 47;
            int count = File.ReadAllLines("Users.txt").Length;
            checkBoxes = new CheckBox[count * 2];

            labels = new Label[count];


            FileStream file = new FileStream("Users.txt", FileMode.Open);
            StreamReader fnew = new StreamReader(file);

            while (!fnew.EndOfStream)
            {
                str = fnew.ReadLine();

                while (str[i] != ' ')
                {
                    i++;
                }
                name = str.Substring(0, i);

                j = i + 1;
                while (str[j] != ' ')
                {
                    j++;
                }
                p1 = (str.Substring(j + 1, 1));
                p2 = (str.Substring(j + 3, 1));

                labels[k] = new Label
                {
                    Name = "Textbox" + k,
                    Text = name,
                    Location = new Point(32, y),
                    Size = new Size(100, 20),
                };
                checkBoxes[0 + k * 2] = new CheckBox
                {
                    Name = "checkBox1" + k * 2,
                    Text = "",
                    Location = new Point(32 + 155, y + 3), //135
                    Size = new Size(15, 14),
                };
                checkBoxes[1 + t * 2] = new CheckBox
                {
                    Name = "checkBox2" + (1 + t * 2),
                    Text = "",
                    Location = new Point(32 + 265, y + 3), //215
                    Size = new Size(15, 14),
                };

                this.Controls.Add(labels[k]);
                this.Controls.Add(checkBoxes[0 + k * 2]);
                this.Controls.Add(checkBoxes[1 + t * 2]);


                checkBoxes[0].Enabled = false;
                checkBoxes[1].Enabled = false;


                if (p1 == "1")
                    checkBoxes[0 + k * 2].Checked = true;
                else
                    checkBoxes[0 + k * 2].Checked = false;
                if (p2 != "0")
                    checkBoxes[1 + t * 2].Checked = true;
                else
                    checkBoxes[1 + t * 2].Checked = false;

                y += 25;
                i = 0;
                j = 0;
                k++;
                t++;

                Size = new Size(364, 158 + 28 * k); //334 `118
                button1.Location = new Point(215, 50 + 28 * k);
                button2.Location = new Point(33, 50 + 28 * k);
            }
            fnew.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str, p1, p2 = "";
            int count = File.ReadAllLines("Users.txt").Length;
            string[] pas = new string[count];
            bool block = false, limit = false;

            FileStream file = new FileStream("Users.txt", FileMode.Open);
            StreamReader fnew = new StreamReader(file);
            for (int t = 0, i = 0, j = 0; t < count; t++, i = 0, j = 0)
            {
                str = fnew.ReadLine();
                while (block == false)
                {
                    if ((str[i] == ' ') && (block == false))
                    {
                        if (str[i + 1] == ' ')
                        {
                            block = true;
                        }
                        else
                        {
                            do
                            {
                                i++;
                                j++;
                                block = true;
                            }
                            while (str[i + 1] != ' ');
                        }
                    }
                    i++;
                }
                pas[t] = str.Substring(i - j, j);
                block = false;
            }
            fnew.Close();

            FileStream file2 = new FileStream("Users.txt", FileMode.Open);
            StreamWriter fnew2 = new StreamWriter(file2);

            for (int k = 0, i = 0; i < count; k += 2, i++)
            {
                if (checkBoxes[k].Checked)
                    p1 = "1";
                else
                    p1 = "0";


                if (checkBoxes[k + 1].Checked)
                {
                    Global.limitK = true;

                    p2 = "1";
                }
                else
                {
                    p2 = "0";
                    Global.limitK = false;
                }

                fnew2.WriteLine(labels[i].Text + ' ' + pas[i] + ' ' + p1 + ' ' + p2);
            }
            fnew2.Close();
            if (limit == false)
                Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
