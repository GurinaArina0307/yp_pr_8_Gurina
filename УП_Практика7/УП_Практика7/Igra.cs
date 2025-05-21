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
using static System.Net.Mime.MediaTypeNames;

namespace УП_Практика7
{
    public partial class Igra : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        Random r = new Random();
        List<Label> cells = new List<Label>();
        int Columns=1, Rows=1;
        TableLayoutPanel table;
        int size = 10;
        List<string> copia = new List<string>();
        List<string> image = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        int X, click=0;
        string login;
        public Igra(string Login, int x)
        {
            InitializeComponent();
            login = Login;
            X = x;
        }
        private void CREATE_TABLE(int Columns, int Rows)
        {
            table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.BackColor = Color.CornflowerBlue;
            Width = Convert.ToInt32(this.Width);
            Height = Convert.ToInt32(this.Height);
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            table.Location = new System.Drawing.Point(0, 0);
            table.Visible = true;
            table.ColumnCount = Convert.ToInt32(Columns);
            table.RowCount = Convert.ToInt32(Rows);
            int width = 100 / table.ColumnCount;
            int height = 100 / table.RowCount;
            for (int col = 0; col < table.ColumnCount; col++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
                for (int row = 0; row < table.RowCount; row++)
                {
                    if (col == 0)
                    {
                        table.RowStyles.Add(new RowStyle(SizeType.Percent, height));
                    }
                    var label = new Label();
                    label.AutoSize = false;
                    label.Font = new Font("Webdings", size);
                    label.Name = ("label" + row + col).ToString();
                    label.Text = 'с'.ToString();
                    label.Dock = DockStyle.Fill;
                    label.Click += label1_Click;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    cells.Add(label);
                    table.Controls.Add(label, col, row);
                }
            }
            Image();
            Controls.Add(table);
        }
        private void Image()
        {
            foreach (Control control in table.Controls)
            {
                Label imagelabel = control as Label;
                if (imagelabel != null)
                {
                    int rNumber = r.Next(image.Count);
                    imagelabel.Text = image[rNumber];
                    image.RemoveAt(rNumber);
                    imagelabel.ForeColor = imagelabel.BackColor;
                }
            }
        }
        private void Sortirovka()
        {
            int rNumber,x=0;
            foreach (Control control in table.Controls)
            {
                Label imagelabel = control as Label;
                if (imagelabel != null)
                {
                    if (imagelabel.ForeColor == Color.Black)
                    {
                        for (int i = 0; i < copia.Count; i++)
                        {
                            if (imagelabel.Text == copia[i])
                            {
                                x = i;
                                rNumber = r.Next(copia.Count);
                                imagelabel.Text = copia[rNumber];
                                copia.RemoveAt(rNumber);
                                break;
                            }
                        }
                        x=0;
                    }
                    else
                    {
                        rNumber = r.Next(copia.Count);
                        imagelabel.Text = copia[rNumber];
                        copia.RemoveAt(rNumber);
                    }
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                click++;
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                CheckForWinner();
                if (firstClicked.Text == secondClicked.Text)
                {
                    for (int i = 0; i < copia.Count; i++)
                    {
                        if (firstClicked.Text == copia[i])
                        {
                            copia.RemoveAt(i);
                            i--;
                        }
                    }
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
               
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
            if (X == 4 && click >40)
                {
                    Sortirovka();
                    X += 1;
                }
        }

        private void Igra_Load(object sender, EventArgs e)
        {
            if (X != 4)
            {
                MessageBox.Show("Найди пары рисунков");
            }
            if (X == 4)
            {
                MessageBox.Show("Найди несовпадающую пару последней чтобы пройти игру подсказка: одна из пары встречается три раза");
            }
            size = 48;
            list();
            CREATE_TABLE(Columns, Rows);

        }
        private void CheckForWinner()
        {
            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            StreamWriter s = File.AppendText("Info.txt");
            string y="";
            if (X == 1)
            {
                y = "Легкая";
            }
            else if (X == 2)
            {
                y = "Средняя";
            }
            else if (X == 3)
            {
                y = "Сложно";
            }
            else if (X == 5 || X==4)
            {
                y = "Супер сложно";
            }
            s.WriteLine(login);
            s.WriteLine(y);
            s.WriteLine(click);
            s.Close();
            MessageBox.Show("Поздравляю вы прошли игру!", "Congratulations");
            Close();
        }

        private void list()
        {
            if(X == 1)
            {
                Columns = 4;
                Rows = 4;
            }
            else if (X == 2)
            {
                Columns = 4;
                Rows = 6;
                image.Add("C");
                image.Add("C");
                image.Add("Z");
                image.Add("Z");
                image.Add("M");
                image.Add("M");
                image.Add("E");
                image.Add("E");
            }
            else if (X == 3 )
            {
                Columns = 5;
                Rows = 6;
                image.Add("C");
                image.Add("C");
                image.Add("Z");
                image.Add("Z");
                image.Add("M");
                image.Add("M");
                image.Add("E");
                image.Add("E");
                image.Add("I");
                image.Add("I");
                image.Add("Y");
                image.Add("Y");
                image.Add("T");
                image.Add("T");
            }
            else if(X == 4 )
            {
                Columns = 5;
                Rows = 6;
                image.Add("C");
                image.Add("C");
                image.Add("Z");
                image.Add("Z");
                image.Add("M");
                image.Add("M");
                image.Add("E");
                image.Add("E");
                image.Add("I");
                image.Add("I");
                image.Add("Y");
                image.Add("Y");
                image.Add("T");
                image.Add("T");
            }
            copia.Clear();
            copia.AddRange(image);
        }
    }
}
