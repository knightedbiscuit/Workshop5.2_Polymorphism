using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5._2_Polymorphism
{
    class BankTest5_2
    {
        public static void Main()
        {
            BankBranch branch = new BankBranch("KOKO Bank Branch",
                                    "Tan Mon Nee");
            Customer cus1 = new Customer("Tan Ah Kow", "2 Rich Street",
                                      "P345123", 40);
            Customer cus2 = new Customer("Lee Tee Kim", "88 Fatt Road",
                                      "P678678", 54);
            Customer cus3 = new Customer("Alex Gold", "91 Dream Cove",
                                      "P333221", 34);
            branch.AddAccount(new SavingsAccount("S1230123", cus1, 2000));
            branch.AddAccount(new OverdraftAccount("O1230124", cus1, 2000));
            branch.AddAccount(new CurrentAccount("C1230125", cus2, 2000));
            branch.AddAccount(new OverdraftAccount("O1230126", cus3, -2000));
            branch.PrintCustomers();
            branch.PrintAccounts();

            Console.WriteLine("Deposit $3000 to Account No. O1230126");
            branch.Deposit("01230126", 3000);
            Console.WriteLine("Deposit $10k to Account No. 0123456");
            branch.Deposit("0123456", 10000);

            //SavingsAccount.savingsInterestRate = 0.05;
            //Account temp = (Account)branch.AccountList[3];
            //temp.Deposit(3000);

            Console.WriteLine(branch.TotalDeposits());
            Console.WriteLine("The bank pays a total of ${0} in interest",branch.TotalInterestPaid());
            Console.WriteLine("The bank earns a total of ${0} in interest", branch.TotalIntererstEarn());

            branch.CreditInterest(); // This command tells the bank to execute the process to compute and credit interest to respective acccounts.

            branch.PrintAccounts();
        }
    }
}

