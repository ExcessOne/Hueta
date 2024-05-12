using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Diplom
{
    public partial class PPacient : Form
        
    {
        public PPacient()
        {
            
           InitializeComponent();
        }

        Point lastPoint;
        private void menuStrip2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void menuStrip2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void свернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void главнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainForm = new Main();
            mainForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Policlinika mainForm = new Policlinika();
            mainForm.Show();
        }

        private void PPacient_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.Пациенты_поликлиника". При необходимости она может быть перемещена или удалена.
            this.пациенты_поликлиникаTableAdapter.Fill(this.dbDataSet.Пациенты_поликлиника);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbDataSet.Пациенты_поликлиникаRow nrow = (dbDataSet.Пациенты_поликлиникаRow)dbDataSet.Пациенты_поликлиника.NewRow();
            nrow.ФИО = textBox1.Text;
            nrow.Дата_рождения = textBox2.Text;
            nrow.Телефон = textBox3.Text;
            dbDataSet.Пациенты_поликлиника.AddПациенты_поликлиникаRow(nrow);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Validate();

            this.tableAdapterManager1.UpdateAll(this.dbDataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить эти записи?", "Удаление записей", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
        }

        private string result = "";
        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result = "Строка 1\n\n";

            result += "Строка 2\nСтрока 3";

            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += PrintPageHandler;

            PrintDialog printDialog = new PrintDialog();

            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print(); 
        }

        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            
            e.Graphics.DrawString(result, new Font("Arial", 14), Brushes.Black, 0, 0);
        }
    }
}
