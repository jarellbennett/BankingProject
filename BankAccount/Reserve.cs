using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
    class Reserve:Account
    {
        new public double Deposit { get; set; }

        new public double Withdraw { get; set; }


        public Reserve(string name, double balance, int acctNum, string acctType) : base(name, balance, acctNum, acctType)
        {
            this.name = name;
            this.balance = balance;
            this.acctNum = acctNum;
            this.acctType = acctType;
        }


        public override void Withdrawal()
        {
            Console.WriteLine('\n' + "This Account does not allow this action.");
            Console.WriteLine("If you feel this is an error, please contact customer service immediately");
        }

        public override void depWrite()
        {
            StreamWriter randy = new StreamWriter("Reserve.txt");
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

    }
}
