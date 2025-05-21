using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace УП_Практика7
{
    public partial class Vhod : Form
    {
        public Vhod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Text = "Сыграть еще раз";
                int x;
                string FamiliaorLogin;
                if (radioButton1.Checked)
                {
                    FamiliaorLogin = textBox1.Text;
                    x = 1;
                }
                else if (radioButton2.Checked)
                {
                    FamiliaorLogin = textBox1.Text;
                    x = 2;
                }
                else if (radioButton3.Checked)
                {
                    FamiliaorLogin = textBox1.Text;
                    x = 3;
                }
                else if (radioButton4.Checked)
                {
                    FamiliaorLogin = textBox1.Text;
                    x = 4;
                }
                else
                {
                    MessageBox.Show("Перед тем как запустить тест выберите свою группу");
                    return;
                }
                Igra z = new Igra(FamiliaorLogin,x);
                z.ShowDialog();
            }
            else
            {
                MessageBox.Show("Перед тем как запустить тест заполните все поля");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Логин игрока";
            dataGridView1.Columns[1].HeaderText = "Сложность игры";
            dataGridView1.Columns[2].HeaderText = "Количсетво кликов";
            dataGridView1.Columns[0].Width = dataGridView1.Width / 3;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 3;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 100 * 33;
            if (File.Exists("Info.txt"))
            {
                int i = 0;
                StreamReader s = new StreamReader("Info.txt");
                while (!s.EndOfStream)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = s.ReadLine();
                    dataGridView1[1, i].Value = s.ReadLine();
                    dataGridView1[2, i].Value = s.ReadLine();
                    i++;
                }
                s.Close();
            }
            else
            {
                MessageBox.Show("Файла с информацией о результатах игры не существует");
            }
        }
    }
}
