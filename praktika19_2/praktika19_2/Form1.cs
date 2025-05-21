using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika19_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Добавить столбец с именем column-1, заголовок столбца - "Header column - 1"
            dataGridView1.Columns.Add("column-1", "Header column - 1");
            // Добавить столбец с именем column-2
            dataGridView1.Columns.Add("column-2", "Header column - 2");
            label1.Text = "Столбцы добавлены";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // удаление столбца в позиции index
            int index; // номер столбца, который удаляется
            int n; // текущее количество столбцов в dataGridView
                   // задать номер столбца, который удаляется
            index = 1;
            // определить текущее количество столбцов в dataGridView
            n = dataGridView1.Columns.Count;
            // удаление
            if ((n > 0) && (index >= 0) && (index < n))
            {
                dataGridView1.Columns.RemoveAt(index);
                label1.Text = "Столбец удален";
            }
            else

            {
                label1.Text = "Столбец не удален";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Добавить строки в таблицу
            if (dataGridView1.Columns.Count <= 0)
            {
                label1.Text = "Строки не добавлены";
                return;
            }
            dataGridView1.Rows.Add("Ivanov I.I.", 25, "New York");
            dataGridView1.Rows.Add("Petrenko P.P.", 38, "Moscow");
            label1.Text = "Строки добавлены";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Удалить строку
            int nr, nc;
            nc = dataGridView1.Columns.Count; // количество столбцов
            nr = dataGridView1.RowCount;
            if ((nc > 0) && (nr > 1))
            {
                dataGridView1.Rows.RemoveAt(0); // удалить первую строку

                label1.Text = "Строка удалена";
            }
            else
            {
                label1.Text = "Строка не удалена";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // задать текст в заголовке
            int nc = dataGridView1.ColumnCount;
            if (nc > 0)
            {
                // задать новый текст заголовке первого столбца
                dataGridView1.Columns[0].HeaderText = "Header - 1";
                label1.Text = "Текст задан";
            }
            else
            {
                label1.Text = "Текст не задан";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // выравнивание заголовка
            int nc;
            nc = dataGridView1.ColumnCount;
            if (nc > 0)
            {
                // задать выравнивание по центру (по горизонтали и по вертикалу)

                dataGridView1.Columns[0].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
                label1.Text = "Выравнивание выполнено";
            }
            else
            {
                label1.Text = "Выравнивание не выполнено";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // задать шрифт в заголовке
            int nc;
            nc = dataGridView1.ColumnCount;
            // создать шрифт "Arial", размер 12, начертание - "курсив"
            Font F = new Font("Arial", 12, FontStyle.Italic);
            if (nc > 0)
            {
                // установить шрифт заголовка
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = F;
                label1.Text = "Шрифт задан";
            }
            else
            {
                label1.Text = "Шрифт не задан";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int nc;
            nc = dataGridView1.ColumnCount;
            if (nc > 0)
            {

                // создать системный шрифт
                Font F = new Font("Arial", 14);
                // задать цвет в заголовках столбцов
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                // задать шрифт
                dataGridView1.Columns[0].DefaultCellStyle.Font = F;
                label1.Text = "Цвет заголовка изменен";
            }
            else
            {
                label1.Text = "Цвет не изменен";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // задать размер dataGridView1
            dataGridView1.Width = 600;
            dataGridView1.Height = 150;
            label1.Text = "Размер установлен";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // задать ширину столбца
            int nc;
            nc = dataGridView1.ColumnCount;
            if (nc > 0)
            {
                // задать ширину столбца с индексом 0
                dataGridView1.Columns[0].Width = 70;
                label1.Text = "Ширина столбца задана";
            }
            else
            {
                label1.Text = "Ширина столбца не задана";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // задать высоту строки

            int nc, nr;
            nc = dataGridView1.ColumnCount;
            nr = dataGridView1.RowCount;
            if ((nc > 0) && (nr > 1))
            {
                dataGridView1.Rows[0].Height = 50;
                label1.Text = "Высота строки задана";
            }
            else
            {
                label1.Text = "Высота строки не задана";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // выравнивание в строках
            int nc, nr;
            nc = dataGridView1.ColumnCount;
            nr = dataGridView1.RowCount;
            if ((nc > 0) && (nr > 1))
            {
                // выравнивание для всех строк
                dataGridView1.RowsDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.BottomRight;
                // выравнивание для строки с индексом 0
                dataGridView1.Rows[0].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
                // выравнивание для столбца с индексом 0
                dataGridView1.Columns[0].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.BottomLeft;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // шрифт и цвет в первом столбце
            int nc, nr;
            nc = dataGridView1.ColumnCount;
            nr = dataGridView1.RowCount;
            if ((nc > 0) && (nr > 1))
            {
                // создать шрифт
                Font F = new Font("Times New Roman", 10, FontStyle.Bold);
                // цвет символов и фона в первом столбце
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Red;
                dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
                // шрифт в первом столбце
                dataGridView1.Columns[0].DefaultCellStyle.Font = F;
                label1.Text = "Шрифт и цвет в 1-м столбце изменен";
            }
            else
            {
                label1.Text = "Шрифт не изменен";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // определить количество столбцов
            int n;
            n = dataGridView1.Columns.Count;
            label1.Text = n.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // определить количество строк без строки заголовка
            int n;
            n = dataGridView1.Rows.Count;
            label1.Text = (n - 1).ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // ширина столбца в пикселах
            int w;
            int nc;
            nc = dataGridView1.Columns.Count;
            if (nc > 0)
            {
                w = dataGridView1.Columns[0].Width;
                label1.Text = w.ToString();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // определить высоту строки в пикселах
            int h;
            int nr, nc;
            nc = dataGridView1.Columns.Count;
            nr = dataGridView1.RowCount;
            if ((nr > 1) && (nc > 0))
            {
                h = dataGridView1.Rows[0].Height;
                label1.Text = h.ToString();
            }
        }
    }
}
