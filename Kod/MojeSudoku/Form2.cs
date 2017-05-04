using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// Dla Debug.Write lub Debug.WriteLine
using System.Diagnostics;

namespace MojeSudoku
{
    public partial class Form2 : Form
    {
        // Zmienna czy wciśnięto odpowiedni klawisz 
        private Boolean czyjestok = true;
        // Zmienna z sudoku
        private string sudoku = "";//System.IO.File.ReadAllText(@"C:\Users\Maks\Desktop\Sudoka\sudoku.sudoku");
        // MojeObliczenia
        MojeObliczenia obliczeniaSudoku = new MojeObliczenia();


        //private string import = "";
        
        public Form2()
        {
            InitializeComponent();
            MessageBox.Show("Formularz interaktywny po otwarciu zawiera domyślnie przykład \nz książki \"Sudoku dla Dzieci\" (str.21, przykład nr 6). \nWydawnictwo REA. 2006.",
            "Informacja",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
        }
        private string czytaj()
        {
            string txtTemp = ""; // System.IO.File.ReadAllText(@"C:\Users\Maks\Desktop\Sudoka\sudoku.sudoku");
            return txtTemp;
        }
        
        // Gdy zmieni się tekst w ! którymś polu !
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Sprawdza czy nie jest ok
            if (!czyjestok)
            {
                czyjestok = true;
                TextBox pole = (TextBox)sender;
                pole.Text = "";
                MessageBox.Show("Wprowadź cyfrę od 1 - 9", "Komunikat");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar) > '0'))
            {
                // Wciśnięto prawidłowy klawisz 1 - 9
            }
            else // Jeśli nie..
            {
                czyjestok = false;
            }
        }

        // Gdy przycisk Wyczyść zostanie kliknięty to...
        private void button2_Click(object sender, EventArgs e)
        {
            {  
                // Czyszczenie pól
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox tb = (TextBox)c;
                        tb.Text = "";
                    }
                }
                obliczeniaSudoku.zerujPolawDanychSudoku();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Czyszczenie pól ze wcześniejszych danych
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    tb.Text = "";
                }
            }

            string nazwaZbioru = "";
            string[,] daneZeZbioru = new string[9, 9];


            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Metoda
            sudoku = czytaj();
            //MessageBox.Show("Zawartość pliku to: " + sudoku);
            
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nazwaZbioru = "" + openFileDialog.FileName;

                StreamReader sr;
                String linia;
                // Wiersz
                int i = 0;
                // Kolumna
                int j = 0;
                try
                {
                    sr = new StreamReader(nazwaZbioru);
                    while ((linia = sr.ReadLine()) != null)
                    {
                        //Debug.WriteLine("*linia*=" + linia);
                        for (j = 0; j < 9; j++)
                        {
                            daneZeZbioru[i, j] = "" + linia[j];
                        }
                        i++;
                    }
                    sr.Close();
                    // Wczytywanie
                    obliczeniaSudoku.wczytajDaneDoTab(daneZeZbioru);
                    wypelnijPlansze(obliczeniaSudoku.pobierzSudokuTab());
                }
                catch (Exception)
                {
                    MessageBox.Show("Otwarcie i obsługa pliku się nie powiodła", "Błąd!");
                }
            }
        }

        private void wypelnijPlansze(int[,] dane)
        {
            int licznik = 0;
            int i = 0, j = 0;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {

                    i = licznik / 9; //liczba całkowita z dzielenia przez 9
                    j = licznik - (i * 9);

                    //TextBox tb = (TextBox)c;
                    //Debug.WriteLine(""+tb.Name + " i,j="+i+","+j);

                    string tbName = "pole" + (i + 1) + (j + 1);
                    TextBox tbx = this.Controls.Find(tbName, true).FirstOrDefault() as TextBox;
                    if (dane[i,j] > 0)
                        tbx.Text = "" + dane[i, j];

                    licznik++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Wiersz od zera
            int i = 0;
            //Kolumna od zera
            int j = 0;
            // Nazwa textBoxa
            string tbName = "";
            // Tekst z textBoxa
            string wartoscPola = "";
            // Tablica dwuwymiarowa, w której zapisujemy dane z ekranu
            string[,] daneZEkranu = new string[9, 9];
            // Przejście kolejno przez 81 pól na ekranie (przykład dla drugiego elementu)
            for (int index = 1; index < 82; index++)
            {
                // Wiersze
                i = (index - 1) / 9; //liczba całkowita z dzielenia przez 9
                // Kolumny
                j = (index - 1) - (i * 9);
                // Buduje nazwe textBoxa
                tbName = "pole" + (i + 1) + (j + 1);
                // Tworzy zmienną i odwołuje się do pola na ekanie (przykład z internetu)
                TextBox tbx = this.Controls.Find(tbName, true).FirstOrDefault() as TextBox;
                // Tekst z textboxa
                wartoscPola = tbx.Text;
                
                //Zamiana pustych pól na kropki
                if (wartoscPola.CompareTo("") == 0)
                {
                    wartoscPola = ".";    
                }
                // Przypisuje wartość pola do pola w tablicy
                daneZEkranu[i, j] = wartoscPola;
            }
            // Na jutro!
            obliczeniaSudoku.wczytajDaneDoTab(daneZEkranu);
            //obliczeniaSudoku.debuguj();

            // kursor dla użytkownika
            Cursor.Current =
            Cursors.WaitCursor;
            
            //obliczeniaSudoku wylicz i wyświetl !!!
            obliczeniaSudoku.oblicz(this);
            
            Cursor.Current =
            Cursors.Default; 
            
            wypelnijPlansze(obliczeniaSudoku.pobierzSudokuTab());
        }

        public void ustawLabel3Tekst(string tekst)
        {
            label3.Text = tekst;
        }

        public void ustawLabel4Tekst(string tekst)
        {
            label4.Text = tekst;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

    }
}
