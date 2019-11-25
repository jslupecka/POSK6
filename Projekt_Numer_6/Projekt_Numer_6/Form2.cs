using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Projekt_Numer_6
{
    public partial class Form2 : Form
    {
        Timer t = new Timer();
        bool R1 = false;
        bool R2 = false;
        bool R3 = false;
        bool R4 = false;
        bool R5 = false;
        bool R6 = false;
        bool R7 = false;
        bool R8 = false;
        bool R9 = false;
        bool R10 = false;
        bool RURA = false;
        int cisnienie = 30;
        Random rnd = new Random();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();     
        }

        private void t_Tick(object sender, EventArgs e)
        {
            if (cisnienie <= 50)
                DIODA1.BackColor= Color.Lime;
            if (cisnienie >= 51 && cisnienie <= 75)
                DIODA1.BackColor = Color.Orange;
            if (cisnienie >= 76 && cisnienie <= 90)
                DIODA1.BackColor = Color.DarkOrange;
            if (cisnienie >= 91 && cisnienie <= 100)
                DIODA1.BackColor = Color.Red;
            cisnienie++; // Zwiększenie wartości progres baru o 1.
            if (cisnienie == 50) // Jeśli progres bar osiągnie połowę swej max wartości zostanie podany komunikat o Braku Czynności Operatora.
            {
                Console.Beep();
                MessageBox.Show("Nienaturalne ciśnienie w rurze głównej");
            }
            else if (cisnienie == 100) // Jeśli progres Bar osiągnie 100% wówczas usłyszymy 5 dźwięków konsolowych i wycofanie do okna logowania.
            {
                for (int i = 0; i <= 2; i++)
                {
                    Console.Beep();
                }                
                RURA = true;
                MessageBox.Show("NASTĄPIŁO USZKODZENIE RURY GLÓWNEJ - AWARIA SYSTEMU!");
                Application.Exit();
            }
            if (RURA == false) // Jeśli zmienna boolowska RURA jest false wówczas będziemy widzieć wzrost progress Baru
                progressBar1.Value = cisnienie;              
            int Wydarzenie = rnd.Next(1, 20);// Z każdym Tickiem zegara istnieje 1/30 szansy na wystąpienie błędu.
            if (Wydarzenie == 1)
                RNG.PerformClick();
        }

        private void RNG_Click(object sender, EventArgs e) // Naciśnięcie przycisku "REG" powoduje wygenerowanie losowego błędu. 
        {
            int Wybor = rnd.Next(1, 10); // Zmienna losowa która określa jaki wystąpi błąd. 
            switch (Wybor) // Wykonanie procedur w zależności od wystąpionej awarii
            {
                case 1:
                    if (R1 == false) // Jeśli awaria nie nastąpiła wcześniej
                    {
                        rura1.BackColor = System.Drawing.Color.Red; // "Dioda" Zmienia barwę na kolor świadczący o wystąpieniu awarii.
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 1"); // Wyświetla informacje o awarii.
                        R1 = true; // Zmienna boolowska pozwala uniknąć wyświetlenia tego samego błędu kilka razy jeśli nie został on wcześniej naprawiony.
                    }
                    break;
                case 2:
                    if (R2 == false)
                    {
                        rura2.BackColor = Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 2");
                        R2 = true;
                    }
                    break;
                case 3:
                    if (R3 == false)
                    {
                        rura3.BackColor = System.Drawing.Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 3");
                        R3 = true;
                    }
                    break;
                case 4:
                    if (R4 == false)
                    {
                        rura4.BackColor = System.Drawing.Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 4");
                        R4 = true;
                    }
                    break;
                case 5:
                    if (R5 == false)
                    {
                        rura5.BackColor = System.Drawing.Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 5");
                        R5 = true;
                    }
                    break;
                case 6:
                    if (R6 == false)
                    {
                        rura6.BackColor = System.Drawing.Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 6");
                        R6 = true;
                    }
                    break;
                case 7:
                    if (R7 == false)
                    {
                        rura7.BackColor = System.Drawing.Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 7");
                        R7 = true;
                    }
                    break;
                case 8:
                    if (R8 == false)
                    {
                        rura8.BackColor = System.Drawing.Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 8");
                        R8 = true;
                    }
                    break;
                case 9:
                    if (R9 == false)
                    {
                        rura9.BackColor = System.Drawing.Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 9");
                        R9 = true;
                    }
                    break;
                case 10:
                    if (R10 == false)
                    {
                        rura10.BackColor = System.Drawing.Color.Red;
                        MessageBox.Show("Zbyt wysokie ciśnienie w rurze nr 10");
                        R10 = true;
                    }
                    break;               
                default:
                    break;
            }
        }

        private void zatwierdzanie_Click(object sender, EventArgs e)
        {
            if (cisnienie >= 10)
                cisnienie = cisnienie - 10;
            switch (komenda.Text)
            {
                case "R1":
                    rura1.BackColor = System.Drawing.Color.Lime; // Wprowadzenie procedury B1C zmienia barwę buttonu na kolor Lime czyli świadczący o naprawie błędu
                    R1 = false; // Również parametr boolowski IB1C zmienia się na false, czyli wskazuje na brak błędu dla tej konkretnej awarii. 
                    break;
                case "R2":
                    rura2.BackColor = System.Drawing.Color.Lime;
                    R2 = false;
                    break;
                case "R3":
                    rura3.BackColor = System.Drawing.Color.Lime;
                    R3 = false;
                    break;
                case "R4":
                    rura4.BackColor = System.Drawing.Color.Lime;
                    R4 = false;
                    break;
                case "R5":
                    rura5.BackColor = System.Drawing.Color.Lime;
                    R5 = false;
                    break;
                case "R6":
                    rura6.BackColor = System.Drawing.Color.Lime;
                    R6 = false;
                    break;
                case "R7":
                    rura7.BackColor = System.Drawing.Color.Lime;
                    R7 = false;
                    break;
                case "R8":
                    rura8.BackColor = System.Drawing.Color.Lime;
                    R8 = false;
                    break;
                case "R9":
                    rura9.BackColor = System.Drawing.Color.Lime;
                    R9 = false;
                    break;
                case "R10":
                    rura10.BackColor = System.Drawing.Color.Lime;
                    R10 = false;
                    break;              
                default:
                    break;
            }
            komenda.Clear();
        }

        private void Klawiatura(object sender, KeyPressEventArgs e) //Naciśnięcie klawisza Enter zatwierdza wprowadzoną komendę. Naciśnięcie powoduje uruchomienie funkcji Wykonaj.
        {
            if (e.KeyChar == (char)Keys.Enter) // Jeśli naciśnięty klawisz to enter wykonaj poniższą funkcję. 
                zatwierdzanie.PerformClick(); // Uruchom funkcję Wykonaj (private void Wykonaj_Click(...))
        }

        private void LogOut_Click(object sender, EventArgs e) // Naciśnięcie przycisku "Wyloguj" ukrywa okno 2 i przenosi nas z powrotem do okna logowania
        {
            new Form1().Show();
            this.Hide();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = cisnienie.ToString();
        }
    }
}
