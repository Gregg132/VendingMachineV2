using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vending_Machine_2
{
    public partial class VendingMachine : Form
    {
        #region Constructor

        public VendingMachine()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialisation

        // this bit of code just assigns my data structures to an array

        double Money; //needed accessible to all functions, so declared here
        Snack[] snacks = new Snack[] //array created as needed in multiple fucntions
        {
        new Snack("Fanta", 0.50, 15, 11),
        new Snack("Sprite", 0.50, 15, 12),
        new Snack("Mars", 0.75, 15, 13),
        new Snack("Snickrs", 0.75, 15, 14),
        new Snack("Quavers", 0.50, 15, 15),
        new Snack("Scampi Fries", 0.50, 15, 16),
        new Snack("Dandelion & Burdock", 0.50, 15, 17),
        new Snack("Cream Soda", 0.50, 15, 18),
        new Snack("Topic", 0.75, 15, 19),
        new Snack("Beef Jerky", 1.00, 15, 21),
        new Snack("Rolos", 0.75, 15, 22),
        new Snack("Mcdonalds Hash Brown", 1.00, 15, 23)
        };

        #endregion

        #region Number Buttons

        //Each of these is an event handler regarding to when buttons in the form are pressed

        //adds number to code box

        private void Btn1_Click(object sender, EventArgs e)
        {
            InsertVal("1");
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            InsertVal("2");
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            InsertVal("3");
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            InsertVal("4");
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            InsertVal("5");
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            InsertVal("6");
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            InsertVal("7");
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            InsertVal("8");
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            InsertVal("9");
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            InsertVal("0");
        }

        //adds money to balance

        private void Btn10p_Click(object sender, EventArgs e)
        {
            AddMoney(0.10);
        }

        private void Btn20p_Click(object sender, EventArgs e)
        {
            AddMoney(0.20);
        }

        private void Btn50p_Click(object sender, EventArgs e)
        {
            AddMoney(0.50);
        }

        private void Btn100p_Click(object sender, EventArgs e)
        {
            AddMoney(1.00);
        }

        private void Btn200p_Click(object sender, EventArgs e)
        {
            AddMoney(2.00);
        }

        #endregion

        #region Operation Buttons

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.TxtNumScreen.Text = this.TxtNumScreen.Text.Remove(0, this.TxtNumScreen.Text.Count()); //empties code box when cancel button clicked
        }

        private void BtnTick_Click(object sender, EventArgs e)
        {
            string scode = this.TxtNumScreen.Text;
            scode = scode.Replace(@"[^0-9a-zA-Z]/g", "");
            char scode2 = scode[0];
            char scode3 = scode[1];
            int code1 = Parse(scode2.ToString());
            int code2 = Parse(scode3.ToString());
            //extracts the 2 first characters in the code entering box and checks they are integers
            if (code1 == 0 || code2 == 0)
            {
                Error(); //throws an error if the funtion returns 0, i.e not existing
                Refocus();
            }
            else
            {
                this.TxtNumScreen.Text = code1.ToString() + code2.ToString(); //displays code on screen, covered almost instantly however, primarily for testing
            }

            int Y = 0;
            foreach (var snack in snacks) //foreach snack in the array
            {
                if (Convert.ToInt32(code1.ToString() + code2.ToString()) == snacks[Y].Index) //check if the code entered belongs to it
                {
                    break;
                }
                else
                {
                    Y++; // Y used to identify the item later
                }
            }
            try
            {
                if (Money >= snacks[Y].Price) //if balance > item cost
                {
                    Dispense(Y, code1, code2); //dispense item
                }
                else
                {
                    this.TxtNumScreen.Text = "Insert Coin"; //else insert more money
                }
            }
            catch
            {
                Error();
            }
        }

        private void BtnResetMoney_Click(object sender, EventArgs e)
        {
            Money = 0; //resets money
            this.BalBox.Text = "£0.00"; //display the reset
            Refocus();
        }

        #endregion

        #region Dispense

        void Dispense(int Y,int code1, int code2)
        {
            this.TxtNumScreen.Text = snacks[Y].Name; // displays name of selected snack
            Money = Money - snacks[Y].Price; //subtracts items cost form balance
            switch  (Convert.ToInt32(code1.ToString() + code2.ToString())) //switch statement comparing the code to the index of the data structs from the array
            {
                case 11:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Fanta;
                    Dispensebox.Refresh();
                    break;
                case 12:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.sprite;
                    Dispensebox.Refresh();
                    break;
                case 13:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Mars;
                    Dispensebox.Refresh();
                    break;
                case 14:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Snickers;
                    Dispensebox.Refresh();
                    break;
                case 15:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.quavers;
                    Dispensebox.Refresh();
                    break;
                case 16:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Scampi_Fries;
                    Dispensebox.Refresh();
                    break;
                case 17:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Dandelion_and_Burdock;
                    Dispensebox.Refresh();
                    break;
                case 18:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Cream_Soda;
                    Dispensebox.Refresh();
                    break;
                case 19:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Topic;
                    Dispensebox.Refresh();
                    break;
                case 21:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Jerky;
                    Dispensebox.Refresh();
                    break;
                case 22:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.Rolos;
                    Dispensebox.Refresh();
                    break;
                case 23:
                    this.BalBox.Text = "£" + Money.ToString("N2");
                    this.Dispensebox.Image = Vending_Machine_2.Properties.Resources.MChashBrown;
                    Dispensebox.Refresh();
                    break;
                default:
                    this.TxtNumScreen.Text = "Error";
                    break;
            }
        }

        private void BtnDispChange_Click(object sender, EventArgs e)
        {
            this.ChangeBox.Text = "£" + Money.ToString("N2"); //displays the money remaining as change
            Money = 0; //resets money
            this.BalBox.Text = string.Empty; //empties the balance box
            this.TxtNumScreen.Text = string.Empty; //empties code box
            this.Dispensebox.Image = null; //removes image from dispense
        }
        #endregion

        #region Helpful Bits

        //the error works but i didnt want to dabble in assigning threads and stuff

        private void Error()
        {
            this.TxtNumScreen.Text = "Error";
            ///this.TxtNumScreen.ForeColor = Color.Red;
            ///System.Threading.Thread.Sleep(1500);
            ///this.TxtNumScreen.Text = string.Empty;

        }

        private void Refocus()
        {
            this.TxtNumScreen.Focus(); //focus just sets where the curor is in the form
            this.TxtNumScreen.Select(this.TxtNumScreen.Text.Count(), this.TxtNumScreen.Text.Count()); //this just selects the end spot as when you focus it highlights the text box
        }

        private void InsertVal(string X)
        {
            if (this.TxtNumScreen.Text.Length >= 5) //clears if there was error message
            {
                this.TxtNumScreen.Text = string.Empty;
            }
            if (this.TxtNumScreen.Text.Length < 2) // maximum of 2 digit codes
            {
                this.TxtNumScreen.Text = this.TxtNumScreen.Text.Insert(this.TxtNumScreen.Text.Count(), X); //this adds the number pressed to end of the text box
                Refocus();
            }
            else
            {
                Refocus();
            }
        }

        private void AddMoney(double X)
        {
            Money = Money + X; //just adds the amount form the button pressed to the balance
            this.BalBox.Text = "£"+Money.ToString("N2"); //displays it with 2 decimal places
            Refocus();
        }

        private int Parse(string X) //just a simple try catch parse as to not crash the program when parsing strings
        {
            try
            {
                int Z = int.Parse(X);
                return Z;
            }
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}
