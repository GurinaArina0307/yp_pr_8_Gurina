using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika19
{
    public partial class Form1 : Form
    {
        int[,] a = new int[3, 4];
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = 4;
            dataGridView1.ColumnCount = 4;
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1.Columns[j].HeaderCell.Value = (j + 1).ToString();
                    a[i, j] = r.Next(-10, 11);
                    dataGridView1[j, i].Value = a[i, j].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[4].HeaderText = "Min"; 
            for (int i = 0; i < 3; i++)
            {
                int min = a[i, 0];
                for (int j = 1; j < 4; j++)
                {
                    if (a[i, j] < min) min = a[i, j];
                }
                dataGridView1[4, i].Value = min.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[3].HeaderCell.Value="Max";
            for (int i = 0; i < 4; i++)
            {
                int max = a[0, i];
                for (int j = 0; j < 3; j++)
                {
                    if (a[j, i] > max) 
                        max = a[j, i];
                }
                dataGridView1[i, 3].Value = max.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBox1.Text);
                int y = Convert.ToInt32(textBox2.Text);
                int z = Convert.ToInt32(textBox3.Text);
                x -= 1;
                y -= 1;
                dataGridView1[x, y].Value = z.ToString();
                a[y, x] = z;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
