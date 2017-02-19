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
            CreateCustList(); //system auto generate and update a customerdata list after accounts have been added.
        }

        private void CreateCustList()
        {
            for (int j = 0; j < accountList.Count; j++)
            {
                Account temp = (Account)accountList[j];
                if (custList.IndexOf(temp.Data) < 0) //check and omit addition of repeated customer objects into arraylist. One customer may own mutiple accounts.
                {
                    custList.Add(temp.Data);
                }
            }
        } //system should automatically generate a customerdata list after accounts have been added.

        public void PrintAccounts()
        {
            //temp is just a variable. Here you are assigning the Account class (Base) variable to reference of the AccountList array containing 
            //the Derived objects of the Account class. When you execute the show() method, it will attempt to execute the show() in the Account class
            //instead of the show() methods of the Derived objects. Hence dynamic bindg is useful here. bypass the show() method 
            //of Account to jump straight to execute the show() method of the Derived objects, which is what we expect the program to perform
            for (int i = 0; i < accountList.Count; i++)
            {
                Account temp = (Account)accountList[i];
                Console.WriteLine(temp);
            }
        }

        public void PrintCustomers()
        {
            for (int i = 0; i < custList.Count; i++)
            {
                Console.WriteLine(custList[i]);
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

        public void Deposit(string accountNum, double amount)
        {
            bool gotaccount = false;
            foreach (Account i in accountList)
            {
                 if (i.AccountNum == accountNum)
                {
                    i.Deposit(amount);
                    gotaccount = true;
                    break;
                }
            }
            if (!gotaccount)
            {
                Console.WriteLine("No such account is found.");
            }
        }

    }
}
