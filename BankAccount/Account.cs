using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
    public abstract class Account
    {
        protected string name;
        protected double balance;
        protected double deposit;
        protected double withdraw;
        protected int acctNum;
        protected string acctType;
        protected DateTime dt = new DateTime();





        public Account(string name, double balance, int acctNum, string acctType)
        {
            this.name = name;
            this.balance = balance;
            this.acctNum = acctNum;
            this.acctType = acctType;
        }

        public double Deposit { get; set; }    //get and set for deposit

        public double Withdraw { get; set; }    //get and set for withdraw

        public double Balance                   //get and set for balance
        {
            get { return balance; }

            set
            {
                balance = value;

                if (balance < 0)
                {
                    balance = 0;
                    Console.WriteLine("You haz No monies");
                }
            }
        }


        public void snapShot()              //shows account admin name, current balance, and acct number
        {
            StringBuilder toasty = new StringBuilder();
            toasty.Append('\n');
            toasty.Append('\n'+"Account admin: " + name);
            toasty.Append('\n'+"Account Number: " +acctNum);
            toasty.Append('\n' + "Available Balance: " +Balance);
            Console.WriteLine(toasty.ToString());
        }



        public virtual void putINmoney()             //Deposit method
        {

            try                        //try block makes sure number is entered by user
            {
                Console.WriteLine("How much would you like to deposit?");
                Console.WriteLine("Current Balance: {0}", Balance);
                Deposit = double.Parse(Console.ReadLine());                  //Set deposit amount
            }
            catch (NotFiniteNumberException)
            {
                Console.WriteLine("You did not enter a numerical value");
            }


            Balance += Deposit;

            Console.WriteLine("Deposit Amount: +{0}", Deposit);
            Console.WriteLine("Updated Balance: {0}", Balance);

        }

        public virtual void Withdrawal()   //withdrawal method
        {

            try
            {
                Console.WriteLine('\n' + "How much would you like to withdraw?");
                Console.WriteLine("Available Balance: {0}", Balance);            //display initial balance on screen
                Withdraw = double.Parse(Console.ReadLine());                  //Set withdrawal amount


            }
            catch (NotFiniteNumberException)
            {
                Console.WriteLine("You did not enter a numerical value");
            }

            if (Withdraw > Balance)
            {
                Console.WriteLine("Insufficient Funds");
            }
            else
            {
                Balance -= Withdraw;

                Console.WriteLine("Withdrawal Amount: -{0}", Withdraw);
                Console.WriteLine("Updated Balance: {0}", Balance);

            }
        }


        public virtual void depWrite()               //stream writer method for deposits
        {
            StreamWriter randy = new StreamWriter("");
            StringBuilder ramRod = new StringBuilder();

            double initial = balance - deposit;

            //the using statement will auto-close the file 
            using (randy)
            {
                ramRod.Append('\n' + "Admin: " + name);
                ramRod.Append('\n' + "Account Number: " + acctNum);
                ramRod.Append('\n' + "Type: " + acctType);
                ramRod.Append('\n' + "Balance Prior: " + initial);
                ramRod.Append('\n' + "Deposit: +" + deposit);
                ramRod.Append('\n' + "Updated Balance: " + balance);
                ramRod.Append('\n');



                randy.WriteLine(ramRod.ToString());               //writes stringBuilder randy to writer ramRod
            }

            Console.WriteLine(ramRod.ToString());
        }


        public virtual void witWrite()               //stream writer
        {
            StreamWriter randy = new StreamWriter("");
            StringBuilder ramRod = new StringBuilder();

            double initial = balance + Withdraw;

            //the using statement will auto-close the file 
            using (randy)
            {
                ramRod.Append('\n' + "Admin: " + name);
                ramRod.Append('\n' + "Account Number: " + acctNum);
                ramRod.Append('\n' + "Type: " + acctType);
                ramRod.Append('\n' + "Balance Prior: " + initial);
                ramRod.Append('\n' + "Withdrawal: -" + Withdraw);
                ramRod.Append('\n' + "Updated Balance: " + Balance);
                ramRod.Append('\n');



                randy.WriteLine(ramRod.ToString());               //writes stringBuilder randy to writer ramRod
            }

        }
    }
}