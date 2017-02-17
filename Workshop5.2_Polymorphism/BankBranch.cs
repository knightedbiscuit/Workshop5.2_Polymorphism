using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5._2_Polymorphism
{
    class BankBranch
    {
        string branchName;
        string branchManager;
        ArrayList accountList = new ArrayList();
        ArrayList custList = new ArrayList();

        //Constructor
        public BankBranch(string branchName, string branchManager)
        {
            this.branchName = branchName;
            this.branchManager = branchManager;
        }

        // Property
        public ArrayList AccountList
        {
            get {
                return accountList;
            }
        }

        public string BranchName
        {
            get {
                return branchName;
            }

            set
            {
                branchName = value;
            }
        }

        public string BranchManager
        {
            get {
                return branchManager;
            }

            set
            {
                branchManager = value;
            }
        }

        //Methods
        public void AddAccount(Account holder)
        {
            accountList.Add(holder);
        }

        public void PrintAccounts()
        {
            //temp is just a variable. Here you are assigning the Account class (Base) variable to reference of the AccountList array containing 
            //the Derived objects of the Account class. When you execute the show() method, it will attempt to execute the show() in the Account class
            //instead of the show() methods of the Derived objects. Hence polymorphism is useful here. bypass the show of Account to jump straight to
            //what we expect the program to perform and that is to execute the method of the Derived objects.
            for (int i = 0; i < accountList.Count; i++)
            {
                Account temp = (Account)accountList[i];
                Console.WriteLine(temp.Show());
            }
        }

        public void PrintCustomers()
        {
            for (int j = 0; j < accountList.Count; j++)
            {
                Account temp = (Account)accountList[j];
                if (custList.IndexOf(temp.Data) < 0) //check and omiit addition of repeated customer objects into arraylist. One customer may own mutiple accounts.
                {
                    custList.Add(temp.Data);
                }
            }

            for (int k = 0; k < custList.Count; k++)
            {
                Console.WriteLine(custList[k]);
            }

        }

        public double TotalDeposits()
        {
            double Total = 0;
            for (int i = 0; i < accountList.Count; i++)
            {
                Account temp = (Account)accountList[i];
                Total += temp.CurrentAmt;
            }

            return (Total);
        }

        public double TotalInterestPaid() //compute the interest that bank will have to pay
        {
            double total = 0;
            foreach (Account i in accountList) // Poly and Dyn binding at play here. Get interest for account has been passed to its subclass
            {
                if (i.Interest > 0)
                {
                    total += i.Interest;
                }
            }
            return total;
        }

        public double TotalIntererstEarn()
        {
            double total = 0;
            foreach (Account i in accountList) // Poly and Dyn binding at play here. Get interest for account has been passed to its subclass
            {
                if (i.Interest < 0)
                {
                    total += Math.Abs(i.Interest);
                }
            }
            return total;
        }

        public void CreditInterest()
        {
            for (int i = 0; i < accountList.Count; i++)
            {
                Account temp = (Account) accountList[i];
                temp.CalculateInterest();
                temp.CreditInterest();
            }
        }

    }
}
