using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
    class Checking : Account
    {


        new public double Deposit{ get; set; }

        new public double Withdraw { get; set; }


        public Checking(string name, double balance, int acctNum, string acctType) : base(name, balance,acctNum,acctType)
        {
            this.name = name;
            this.balance = balance;
            this.acctNum = acctNum;
            this.acctType = acctType;
        }

        public override void Withdrawal()
        {


            
            try
            {
                Console.WriteLine('\n' + "How much would you like to withdraw?");
                Console.WriteLine("Current Balance: {0}",Balance);            //display initial balance on screen
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

        public override void depWrite()
        {
            StreamWriter randy = new StreamWriter("Checking.txt");
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
        }


        public override void witWrite()
        {
            
                StreamWriter randy = new StreamWriter("Checking.txt");
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




        public override void putINmoney()
        {

            
            try
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

        }

    
   


} 
            
    

