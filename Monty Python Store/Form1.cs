using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monty_Python_Store
{
    public partial class Form1 : Form
    {
        const double PARROT_COST = 5.00;
        const double HELMET_COST = 15.00;
        const double SILLY_WALK_COST = 20.00;
        const double ALBUM_COST = 25.00;
        const double GRENADE_COST = 1000000.00;
        const double SPANISH_COST = 50.00;
        const double TAX = 0.13;
        int parrotNumber;
        int helmetNumber;
        int sillywalkNumber;
        int albumNumber;
        int grenadeNumber;
        int spanishNumber;
        double subTotal;
        double Total;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parrotNumber = Convert.ToInt32(parrotTextbox.Text);
            helmetNumber = Convert.ToInt32(helmetTextbox.Text);
            sillywalkNumber = Convert.ToInt32(sillywalkTextbox.Text);
            albumNumber = Convert.ToInt32(albumTextbox.Text);
            grenadeNumber = Convert.ToInt32(grenadeTextbox.Text);
            spanishNumber = Convert.ToInt32(spanishTextbox.Text);

            subTotal = PARROT_COST * parrotNumber + HELMET_COST * helmetNumber + SILLY_WALK_COST * sillywalkNumber + ALBUM_COST * albumNumber + GRENADE_COST * grenadeNumber + SPANISH_COST * spanishNumber;
            Total = subTotal * TAX;

            subtotalOutputlabel.Text = "" + subTotal.ToString ("C");

              
        }
    }
}
