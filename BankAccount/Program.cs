using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            string doSomething = "yes";

            StringBuilder op = new StringBuilder();

            Checking mMk = new Checking("Townsend, Michael", 5000.00, 55342,"Checking");
            Savings uMm = new Savings("Stewart, John", 800.00, 55343,"Savings");
            Reserve yEa = new Reserve("Wayne, Bruce", 100000.00, 55344,"Reserve");




            Console.WriteLine("Hello, this is the Bank Teller App used to track information on your businesses Account(s)" + '\n');
            Console.WriteLine(" Here you can view the accounts balance,");
            Console.WriteLine(" and deposit or withdraw funds" + '\n');


            op.Append('\t' + " Main Menu");
            op.Append('\n' + "1.Client Info");
            op.Append('\n' + "2.View Account");
            op.Append('\n' + "3.Withdraw Funds");
            op.Append('\n' + "4.Deposit");
            op.Append('\n' + "5.Exit");
            op.Append('\n' + "Enter the number of the action you would like to take: ");
            

            do
            {
                Console.WriteLine(op.ToString());
                choice = int.Parse(Console.ReadLine());
            


            
                    switch (choice)         //switch statement based on variable choice
                {
                    case 1:    //client info
                        Console.WriteLine('\n' + "Client Name : Lucky13's Electronics");
                        Console.WriteLine("Associated Accounts: 3");
                        break;

                    case 2:   //view balance

                        StringBuilder ezio = new StringBuilder();
                        ezio.Append("Which account would you like to view?");
                        ezio.Append('\n'+"1.Checking");
                        ezio.Append("2.Savings");
                        ezio.Append("3.Reserve");
                        Console.WriteLine(ezio.ToString());

                        choice = int.Parse(Console.ReadLine());            //user input variable choice

                         switch(choice)             //switch statement based on variable choice
                        {
                            case 1:
                                mMk.snapShot();
                                break;

                            case 2:
                                uMm.snapShot();
                                break;

                            case 3:
                                yEa.snapShot();
                                break;
                        }

                        break;

                    case 3:  //withdraw monies

                        StringBuilder grr = new StringBuilder();
                        grr.Append("Which account would you like to withdraw from?");
                        grr.Append('\n' + "1.Checking");
                        grr.Append("2.Savings");
                        grr.Append("3.Reserve");
                        Console.WriteLine(grr.ToString());
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)                 //switch statement based on variable choice
                        {
                            case 1:
                                mMk.Withdrawal();
                                mMk.witWrite();
                                break;

                            case 2:
                                uMm.Withdrawal();
                                uMm.witWrite();
                                break;

                            case 3:
                                yEa.Withdrawal();
                                break;
                        }

                                break;

                    case 4:    //deposit monies

                        StringBuilder zim = new StringBuilder();
                        zim.Append("Which account would you like to deposit funds?");
                        zim.Append('\n' + "1.Checking");
                        zim.Append("2.Savings");
                        zim.Append("3.Reserve");
                        Console.WriteLine(zim.ToString());

                        choice = int.Parse(Console.ReadLine());

                        switch (choice)                        //switch statement based on variable choice
                        {
                            case 1:
                                mMk.putINmoney();
                                mMk.depWrite();
                                break;

                            case 2:
                                uMm.putINmoney();
                                uMm.depWrite();
                                break;

                            case 3:
                                yEa.putINmoney();
                                yEa.depWrite();
                                break;

                        }

                        break;

                   
                }

                    Console.WriteLine('\n'+"Would you like to continue?");                     //exit condition
                    Console.WriteLine("Type Yes to continue or No to exit" + '\n');
                    doSomething = Console.ReadLine().ToLower();


                }
            while (doSomething == "yes");

            













        }
    }
}
