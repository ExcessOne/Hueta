using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Diplom
{
    
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        Point lastPoint;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Excess\Desktop\Diplom\Diplom\Авторизация.accdb");
            OleDbDataAdapter ada = new OleDbDataAdapter("SELECT COUNT(*) From Login where Name = '" + Name1.Text + "'and Password = '" + Password.Text + "'", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Hide();
                Main main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!!!");
            }
        }


    }
}
