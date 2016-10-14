// Created By: Manuel Muncaster
// Date: October 11, 2016
// Cash Register Summative
// Special Thanks to Monty Python

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
using System.Threading;

namespace Monty_Python_Store
{
    public partial class Form1 : Form
    {
        //Setting up variables
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
        double tenderedAmount;
        double change;
        double subTotal;
        double total;
        double taxTotal;
        int orderNumber;
       
        public Form1()
        {
            InitializeComponent();

            //Hiding labels that shouldn't be visible at the start of the program
            subtotalOutputlabel.Visible = false;
            taxOutputlabel.Visible = false;
            totalOutputlabel.Visible = false;
            errorChangelabel.Visible = false;
            errorValueslabel.Visible = false;
            subtotalLabel.Visible = false;
            taxLabel.Visible = false;
            totalLabel.Visible = false;
            tenderedLabel.Visible = false;
            tenderedTextbox.Visible = false;
            changeButton.Visible = false;
            changeLabel.Visible = false;
            changeOutputlabel.Visible = false;
            receiptButton.Visible = false;
            errorChangelabel2.Visible = false;
            neworderButton.Visible = false;

            //Sound plays at the start of the program
            SoundPlayer player = new SoundPlayer(Properties.Resources.knightsoftheroundtable);
            player.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {  try
            {
                //Sound plays after the button is pressed
                SoundPlayer player = new SoundPlayer(Properties.Resources.fleshwound);
                player.Play();

                //Showing Labels that need to be seen
                subtotalLabel.Visible = true;
                taxLabel.Visible = true;
                totalLabel.Visible = true;
                tenderedLabel.Visible = true;
                tenderedTextbox.Visible = true;
                changeButton.Visible = true;

                //Converting textboxes to be able to hold numbers
                parrotNumber = Convert.ToInt32(parrotTextbox.Text);
                helmetNumber = Convert.ToInt32(helmetTextbox.Text);
                sillywalkNumber = Convert.ToInt32(sillywalkTextbox.Text);
                albumNumber = Convert.ToInt32(albumTextbox.Text);
                grenadeNumber = Convert.ToInt32(grenadeTextbox.Text);
                spanishNumber = Convert.ToInt32(spanishTextbox.Text);

                Graphics formGraphics = this.CreateGraphics();

                //Math to calculate subtotal, taxtotal, and grandtotal
                subTotal = PARROT_COST * parrotNumber + HELMET_COST * helmetNumber + SILLY_WALK_COST * sillywalkNumber + ALBUM_COST * albumNumber + GRENADE_COST * grenadeNumber + SPANISH_COST * spanishNumber;
                taxTotal = subTotal * TAX;
                total = subTotal + taxTotal;

                subtotalOutputlabel.Visible = true;
                taxOutputlabel.Visible = true;
                totalOutputlabel.Visible = true;

                //Printing out the totals onto the screen
                subtotalOutputlabel.Text = "" + subTotal.ToString("C");
                taxOutputlabel.Text = "" + taxTotal.ToString("C");
                totalOutputlabel.Text = "" + total.ToString("C");

                Pen whitePen = new Pen(Color.White);
                formGraphics.DrawLine(whitePen, 0, 400, 200, 400);
            }
            catch
            {   //Error messages pops up if there is a problem
                errorValueslabel.Visible = true;
                subtotalOutputlabel.Visible = false;
                taxOutputlabel.Visible = false;
                totalOutputlabel.Visible = false;
                subtotalLabel.Visible = false;
                taxLabel.Visible = false;
                totalLabel.Visible = false;
                tenderedLabel.Visible = false;
                tenderedTextbox.Visible = false;
                changeButton.Visible = false;
                errorChangelabel.Visible = false;
                errorChangelabel2.Visible = false;
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
           try {
                //Plays a sound when you press button
                SoundPlayer player = new SoundPlayer(Properties.Resources.romans);
                player.Play();

                tenderedAmount = Convert.ToInt32(tenderedTextbox.Text);

                //Math to calculate change
                change = tenderedAmount - total;

                changeOutputlabel.Text = "" + change.ToString("C");

                //if statments to determine if user pays enough money
                if (tenderedAmount < total)
                    errorChangelabel.Visible = true;
                receiptButton.Visible = false;
                changeOutputlabel.Visible = false;
                changeLabel.Visible = false;
                changeOutputlabel.Text = "$" + change;
               
                if (tenderedAmount >= total)
                    errorChangelabel.Visible = false;
                receiptButton.Visible = true;
                changeOutputlabel.Visible = true;
                changeLabel.Visible = true;

            }
            catch { errorChangelabel2.Visible = true;
                changeLabel.Visible = false;
                changeOutputlabel.Visible = false;
                receiptButton.Visible = false;
            }
    }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.printer);
            player.Play();

            Graphics formGraphics = this.CreateGraphics();
            Graphics fg = this.CreateGraphics();

            //Math to increase the order number by 1 each time user prints receipt while program is running
            orderNumber = orderNumber + 1;
            
            //Setting up pens, brushes and fonts
            Pen whitePen = new Pen(Color.White);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(Color.Black);
            Font blackFont = new Font("Consolas", 9, FontStyle.Bold);

            //Drawing the receipt
            formGraphics.DrawRectangle(whitePen, 375, 10, 300, 500);
            formGraphics.FillRectangle(whiteBrush, 375, 10, 300, 500);

            //Printing the receipt
            Thread.Sleep(1000);
            fg.DrawString("Monty Python Store", blackFont, blackBrush, 450, 10);
            Thread.Sleep(1000);
            fg.DrawString("Order Number: " + orderNumber, blackFont, blackBrush, 375, 40);
            Thread.Sleep(1000);
            fg.DrawString("Date: October 14, 2016", blackFont, blackBrush, 375, 60);
            Thread.Sleep(1000);
            fg.DrawString("Alive Parrot  x " + parrotNumber + " @ " + PARROT_COST, blackFont, blackBrush, 375, 100);
            Thread.Sleep(1000);
            fg.DrawString("Black Knight Helmet  x " + helmetNumber + " @ " + HELMET_COST, blackFont, blackBrush, 375, 120);
            Thread.Sleep(1000);
            fg.DrawString("Silly Walk  x " + sillywalkNumber + " @ " + SILLY_WALK_COST, blackFont, blackBrush, 375, 140);
            Thread.Sleep(1000);
            fg.DrawString("Lumberjack Song  x " + albumNumber + " @ " + ALBUM_COST, blackFont, blackBrush, 375, 160);
            Thread.Sleep(1000);
            fg.DrawString("Holy Hand Grenade  x " + grenadeNumber + " @ " + GRENADE_COST, blackFont, blackBrush, 375, 180);
            Thread.Sleep(1000);
            fg.DrawString("Spanish Inquisition  x " + spanishNumber + " @ " + SPANISH_COST, blackFont, blackBrush, 375, 200);
            Thread.Sleep(1000);
            fg.DrawString("Subtotal: $" + subTotal, blackFont, blackBrush, 375, 230);
            Thread.Sleep(1000);
            fg.DrawString("Tax: $" + taxTotal, blackFont, blackBrush, 375, 250);
            Thread.Sleep(1000);
            fg.DrawString("Total: $" + total, blackFont, blackBrush, 375, 270);
            Thread.Sleep(1000);
            fg.DrawString("Tendered: $" + tenderedAmount, blackFont, blackBrush, 375, 300);
            Thread.Sleep(1000);
            fg.DrawString("Change: $" + change, blackFont, blackBrush, 375, 320);
            Thread.Sleep(1000);
            fg.DrawString("Have a good day!", blackFont, blackBrush, 375, 360);
            Thread.Sleep(1000);

            neworderButton.Visible = true;

            SoundPlayer player2 = new SoundPlayer(Properties.Resources.brightside);
            player2.Play();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Resetting all of the textboxes to 0 and clearing the receipt
            Graphics formGraphics = this.CreateGraphics();

            SoundPlayer player = new SoundPlayer(Properties.Resources.frenchtaunt);
            player.Play();

            parrotTextbox.Text = "0";
            helmetTextbox.Text = "0";
            sillywalkTextbox.Text = "0";
            albumTextbox.Text = "0";
            grenadeTextbox.Text = "0";
            spanishTextbox.Text = "0";
            subtotalOutputlabel.Text = "0";
            taxOutputlabel.Text = "0";
            totalOutputlabel.Text = "0";
            tenderedTextbox.Text = "0";
            changeOutputlabel.Text = "0";

            tenderedAmount = 0;
            change = 0;
            subTotal = 0;
            total = 0;
            taxTotal = 0;

            parrotNumber = 0;
            helmetNumber = 0;
            sillywalkNumber = 0;
            albumNumber = 0;
            grenadeNumber = 0;
            spanishNumber = 0;

            Brush blackBrush = new SolidBrush(Color.Black);
            Pen blackPen = new Pen (Color.Black);

            formGraphics.FillRectangle(blackBrush, 375, 10, 300, 500);
            formGraphics.DrawRectangle(blackPen, 375, 10, 300, 500);
        }
    }
}
