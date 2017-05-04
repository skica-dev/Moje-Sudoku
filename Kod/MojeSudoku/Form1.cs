using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MojeSudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void formularzInteraktywnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Zdefiniowanie zmiennej dla formularza interaktywnego
            Form2 formularzInteraktywny = new Form2();
            // Otwarcie okna formularza interaktywnego w trybie modalnym
            formularzInteraktywny.ShowDialog();

        }

        private void zakończPracęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Wyjście z aplikacji
            Application.Exit();
        }

        private void oMnieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();

        }
    }
}
