using System;
using System.Windows.Forms;

namespace Projekt_Numer_6
{
    public partial class Form1 : Form
    {
        int zabezpieczenie = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Logowanie(object sender, EventArgs e)
        {
            
            if ((username_txtb.Text == "Bartek") && (password_txtb.Text == "qwerty"))
            {
            new Form2().Show();
            this.Hide();
            } 
            else if ((username_txtb.Text == "") && (password_txtb.Text == ""))
            {
            new Form2().Show();
            this.Hide();
            }
            else
            {
                if (zabezpieczenie == 3)
                {
                    MessageBox.Show("Zbyt duża liczba nieudanych prób logowania, nastąpi zamknięcie systemu");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Niepoprawne dane logowania");
                    zabezpieczenie++;
                    username_txtb.Clear();
                    password_txtb.Clear();
                }
            } 
        }

        private void Wyjscie(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
