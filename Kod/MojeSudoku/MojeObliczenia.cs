using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Dla Debug.Write lub Debug.WriteLine
using System.Diagnostics;


namespace MojeSudoku
{
    class MojeObliczenia
    {
        // Tworzenie tablicy
        private int[,] sudokuTab = new int[9,9];
        // oraz jej kopii
        private int[,] kopiaSudokuTab = new int[9, 9];

        public void wczytajDaneDoTab (string[,] daneWej) {
            // Wiersze
                for (int i = 0; i < 9; i++)
            {
                // Kolumny
                for (int j = 0; j < 9; j++)
                {
                    string tym = daneWej[i, j];
                    if (tym.CompareTo(".") != 0)
                    { 
                        // Ustawia liczbę w tabeli na odpowiedniej pozycji
                        sudokuTab[i,j] = Convert.ToInt32(tym);
                        //Debug.WriteLine("sudokuTab[" + i + ", " + j + "] = " + sudokuTab[i, j]);
                    }
                    else
                    { 
                        // W zbiorze występuje kropka, co oznacza że nie wyświetla się nic
                        sudokuTab[i, j] = 0;
                    }
                }
            }
        }

        public int[,] pobierzSudokuTab ()
        {
            return sudokuTab;
        }

        public void debuguj()
        {
            int i, j = 0;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++) {
                   // Debug.WriteLine("sudokuTab["+i+", "+j+"]" + sudokuTab[i, j]);
                }
            }
        }

        // Zamiana w tabeli na zera tam gdzie są braki
        private void zerujPustePolawDanychSudoku()
        {
            int i, j = 0;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++) {
                    if (sudokuTab[i, j]>0) {
                    } else {
                        sudokuTab[i, j] = 0;
                    }
                }
            }
        }


        // Zamiana w tabeli na zera tam gdzie są braki
        public void zerujPolawDanychSudoku()
        {
            int i, j = 0;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    sudokuTab[i, j]=0;
                }
            }
        }


        // Zamiana w tabeli na zera tam gdzie są braki
        private void kopiowanieTablicy(int[,] source, int[,] destination)
        {
            int i, j = 0;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    destination[i, j] = source[i,j];
                }
            }
        }

        private bool czyTablicaMaZera(int[,] source)
        {
            int i, j = 0;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    if (source[i, j] == 0) return true;
                }
            }
            return false;
        }


        // Sprawdzenie wiersza, kolumny i kwadratu 
        private bool czyMoznaWstawicLiczbe(int x, int y, int liczbaTestowa)
        {
            for (int i = 0; i < 9; i++)
            {
                //Debug.WriteLine("liczbaTestowa = " + liczbaTestowa + ", sudokuTab[x, i] to " + sudokuTab[x, i]);
                if (liczbaTestowa == sudokuTab[x, i] || liczbaTestowa == sudokuTab[i, y] || liczbaTestowa == sudokuTab[x / 3 * 3 + i % 3, y / 3 * 3 + i / 3])
                {
                    return false;
                }
            }
            return true;
        }


        public void oblicz(Object parent)
        {
            Form2 form = (Form2) parent;

            // Pseudokod algorytmowy
            /*

                 Initialize 2D array with 81 empty grids(nx=9,ny=9)
                 Fill in some empty grid with the known values
                 Make an original copy of the array
                 Start from top left grid(nx=0,ny=0), check if grid is empty
                 if (grid is empty){
                 assign the empty grid with values (i) 
                   if (no numbers exists in same rows & same columns same as (i))
                   fill in the number
                   if (numbers exists in same rows & same columns same as (i))
                   discard (i) and repick other values (i++)
                 }else{
                   while (nx<9){
                     Proceed to next row grid(nx++,ny)
                       if (nx equal 9){
                       reset nx = 1
                       proceed to next column grid(nx,ny++)
                           if (ny equal 9){
                           print solutions
                           }
                       }           
                 } 
 
             */




            zerujPustePolawDanychSudoku();
            // licznik prób
            int licz = 1;

            //while (warunek)
            //{
                kopiowanieTablicy(sudokuTab, kopiaSudokuTab);

                // Tablica z cyframi od 1 - 9 kolejno
                int[] liczbyWygenerowane = Enumerable.Range(1, 9).ToArray();

                // x i y do poruszania się po tablicy sudoku od lewego górnego rogu
                int x = 0;
                int y = 0;

                // czy wygenerowane liczby działają? da się rozwiązać?
                bool znacznikPoprawnosci = true;
                // liczymy dalej, czy to już koniec?
                bool warunek_ = true;
                // koniec jak dotarliśmy do ostatniego elementu
                if (x == 8 && y == 8)
                {
                    warunek_ = false;
                }

                while (warunek_ == true)
                {
                    Debug.WriteLine("sudokuTab[" + x + ", " + y + "]" + sudokuTab[x, y]);
                    if (sudokuTab[x, y] == 0)
                    {
                        // dla danego elementu w tablicy sudoku
                        znacznikPoprawnosci = false;
                        // generator to indeks kolejnej liczby z ciągu 9 liczb
                        for (int generator = 0; generator < 9; generator++)
                        {
                            // czy ok - wiersz, kolumna, kwadrat
                            if (czyMoznaWstawicLiczbe(x, y, liczbyWygenerowane[generator]))
                            {
                                sudokuTab[x, y] = liczbyWygenerowane[generator];
                                znacznikPoprawnosci = true;
                                if (x == 8 && y == 8)
                                {
                                    warunek_ = false;
                                }
                                else
                                {
                                    if (x == 8)
                                    {
                                        x = 0; y = y + 1;
                                    }
                                    else
                                    {
                                        x = x + 1;
                                    }
                                }
                            }
                        }
                        if (!znacznikPoprawnosci)
                        {
                            // musimy wygenerować nowy ciąg liczb, niestety - kolejna próba
                            Debug.WriteLine("Bląd dla pozycji [x,y] gdzie x= "+x+",y="+y);

                            x = 0; y = 0;

                            liczbyWygenerowane = Enumerable.Range(1, 9).ToArray();

                            // przypadkowe ustawienie za użyciem Random - przykład z internetu dla przestawienia liczb w tabeli
                            var rnd = new Random();

                            for (int i = 0; i < liczbyWygenerowane.Length; ++i)
                            {
                                int randomIndex = rnd.Next(liczbyWygenerowane.Length);
                                int temp = liczbyWygenerowane[randomIndex];
                                liczbyWygenerowane[randomIndex] = liczbyWygenerowane[i];
                                liczbyWygenerowane[i] = temp;
                            }

                            Debug.WriteLine("--------------" + licz + "---------------");
                            // zmienna dla wyświetlenia ciągu wygenerowanego
                            string label3Text = "";
                            for (int i = 0; i < 9; i++)
                            {
                                label3Text = label3Text + "" + liczbyWygenerowane[i];
                            }
                                      Debug.WriteLine("------------------------------");

                            form.ustawLabel3Tekst(label3Text);
                            form.ustawLabel4Tekst("" + licz);
                            licz++;

                            // przywracamy sudoku z kopii po nieudanym uzupełnieniu
                            kopiowanieTablicy(kopiaSudokuTab, sudokuTab);


                        }

                    }
                    else
                    {
                        if (x == 8 && y == 8)
                        {
                            // koniec
                            warunek_ = false;
                        }
                        else
                        {
                            if (x == 8)
                            {
                                x = 0; y = y + 1;
                            }
                            else
                            {
                                x = x + 1;
                            }
                        }
                    }
                }

                debuguj();


            }
 
        }
}
