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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        int[] err = new int[100];

        private void button1_Click(object sender, EventArgs e)
        {
            int n = File.ReadAllLines("Users.txt").Length;
            string str;
            string[] pasAll = new string[n];
            string[] name = new string[n];
            string[] block = new string[n];
            string[] limit = new string[n];

            bool logFlag = false;
            FileStream file = new FileStream("Users.txt", FileMode.Open);
            StreamReader fnew = new StreamReader(file);

            for (int t = 0; t < n; t++)
            {
                int i = 0;
                int j = 0;
                str = fnew.ReadLine();
                while (str[j] != ' ')
                {
                    j++;

                }
                name[t] = str.Substring(0, j);
                j++;
                i = j;
                while (str[j] != ' ')
                {
                    j++;
                }
                pasAll[t] = str.Substring(i, j - i);
                block[t] = str.Substring(j + 1, 1);
                limit[t] = str.Substring(j + 3, 1);

            }
            fnew.Close();
            Global.names = name;
            Global.log = textBox1.Text;
            Global.pas = textBox2.Text;
            label3.Text = "";

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (Global.log == name[i])
                {
                    logFlag = true;
                    Global.k = i;
                    k = i;
                }
            }
            if (logFlag == false)
                label3.Text = "Неверное имя пользователя";
            else
            {
                label3.Text = "";

                if (block[k] == "1")
                    label3.Text = "Пользователь заблокирован";
                else
                {
                    if (pasAll[k] == "")
                    {

                        {
                            label3.Text = "";
                            NewFirstPas fpas = new NewFirstPas();
                            if (limit[k] == "1")
                                Global.limitK = true;
                            else
                                Global.limitK = false;
                            Hide();
                            fpas.ShowDialog();
                            Show();
                            textBox2.Text = "";

                        }

                    }
                    else if (Global.pas != pasAll[k])
                    {
                        err[k]--;
                        label3.Text = "Осталось " + (err[k] + 3) + " попытки";
                        textBox2.Text = "";

                        if (err[k] == -3)
                        {
                            Close();
                        }
                    }
                    else if (Global.pas == pasAll[k])
                    {

                        if (name[k] == "admin")
                        {

                            Hide();
                            Global.userFlag = false;
                            AdminForm fadmin = new AdminForm();
                            fadmin.ShowDialog();
                            textBox2.Text = "";
                            Show();
                        }
                        else
                        {
                            if (limit[k] == "1")
                                Global.limitK = true;
                            else
                                Global.limitK = false;
                            Hide();
                            Global.userFlag = true;
                            AdminForm fuser = new AdminForm();
                            fuser.ShowDialog();
                            textBox2.Text = "";
                            Show();
                        }
                        err[k] = 0;


                    }

                }
            }
            if (Global.closeFlag) { Close(); }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AB1;
            AB1 = new AboutBox1();
            AB1.Show();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            //mainForm f1 = new mainForm();
            if (!(File.Exists("Users.txt")))
            {
                FileStream file = new FileStream("Users.txt", FileMode.Create);
                StreamWriter fadmin = new StreamWriter(file);
                fadmin.WriteLine("admin" + ' ' + "" + ' ' + "0" + ' ' + "1");
                fadmin.Close();

            }
        }
    }



    public static class Global
    {
        public static int k;
        public static string log;
        public static string pas;
        public static bool limitK;
        public static string[] names;
        public static bool closeFlag = false;
        public static bool userFlag = false;

        public static void newPas(int k, string pas)
        {
            FileStream file = new FileStream("Users.txt", FileMode.Open);
            StreamReader NewPas = new StreamReader(file);
            string str = "";
            for (int t = 0; t < k + 1; t++)
            {
                str = NewPas.ReadLine();
            }
            int i = 0;
            while (str[i] != ' ')
            {
                i++;
            }
            i++;
            string newstr = str.Insert(i, pas);
            NewPas.Close();
            string text = File.ReadAllText("Users.txt");
            text = text.Replace(str, newstr);
            File.WriteAllText("Users.txt", text);

        }
        public static void ChangePas(int k, string newPas)
        {
            FileStream file = new FileStream("Users.txt", FileMode.Open);
            StreamReader NewPas = new StreamReader(file);
            string str = "";
            for (int t = 0; t < k + 1; t++)
            {
                str = NewPas.ReadLine();
            }
            int i = 0;
            while (str[i] != ' ')
            {
                i++;
            }
            string name = str.Substring(0, i);
            i++;
            while (str[i] != ' ')
            {
                i++;
            }
            i++;
            string prop = str.Substring(i, 3);

            NewPas.Close();
            string newstr = name + " " + newPas + " " + prop;
            string text = File.ReadAllText("Users.txt");
            text = text.Replace(str, newstr);
            File.WriteAllText("Users.txt", text);

        }


    }
}
