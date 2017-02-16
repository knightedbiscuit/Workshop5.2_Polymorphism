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
            //Console.WriteLine(branch.TotalInterestEarned());
            //Console.WriteLine(branch.TotalInterestPaid());
            //branch.CreditInterest();
          //  branch.PrintAccounts();
        }

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

        }

        public class Customer :Object
        {
            //attributes
            string name;
            string address;
            string nric;
            DateTime dob = new DateTime();
            int age;

            //prroperty
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public string Address
            {
                get
                {
                    return address;
                }
                set
                {
                    address = value;
                }
            }

            public string NRIC
            {
                get
                {
                    return nric;
                }
            }

            public int Age
            {
                get
                {
                    return age;
                }
            }

            //constructor
            public Customer(string name, string address, string nric, DateTime dobIn)
            {
                this.name = name;
                this.address = address;
                this.nric = nric;
                dob = dobIn;
                age = DateTime.Now.Year - dob.Year;
            }

            public Customer(string name, string address, string nric, int age)
            {
                this.name = name;
                this.address = address;
                this.nric = nric;
                this.age = age;
            }

            public Customer() : this("NoName", "NoAddress", "NoNRIC", new DateTime(1900, 1, 1))
            { }

            //Method
            public string Showcustomer()
            {
                return (String.Format(name + "\t\t" + address + "\t\t" + nric + "\t\t" + "{0}", age));
            }

            public override string ToString()
            {
                return (String.Format("{0}\t\t{1}\t\t{2}\t\t{3} ",name,address,nric,age));
            }
        }

        public class Account
        {
            //attributes
            protected string accountNum;
            protected double currentAmt;
            Customer data;

            //properties
            public string AccountNum
            {
                get
                {
                    return accountNum;
                }
            }

            public double CurrentAmt
            {
                get
                {
                    return currentAmt;
                }
            }

            public Customer Data
            {
                get {
                    return data;
                }

                set
                {
                    data = value;
                }
            }

            //constructor
            public Account(string accountNum, Customer data, double initialAmt)
            {
                this.accountNum = accountNum;
                this.data = data;
                currentAmt = initialAmt;
            }

            public Account()
                : this("xxx-xxx-xxx", new Customer(), 0)
            { }

            //methods
            public void Deposit(double amount)
            {
                currentAmt += amount;
            }

            public void Withdraw(double amount)
            {
                if (currentAmt - amount >= 0)
                {
                    currentAmt -= amount;
                }
                else
                {
                    Console.WriteLine("Withdrawal failed. Please ensure that there is sufficient balance in your account");
                }
            }

            public void TransferTo(double amount, Account Another)
            {
                Withdraw(amount);
                Another.Deposit(amount);
            }

            public string Show()
            {
                return (String.Format(accountNum + "\t\t" + data.Showcustomer() + "\t\t" + "{0}", currentAmt));
            }
        }

        public class SavingsAccount : Account
        {
            static double savingsInterestRate;
            double interest;

            //Constructor
            public SavingsAccount(string accountNum, Customer data, double initialAmt) : base(accountNum, data, initialAmt)
            {
                savingsInterestRate = 0.01;
            }

            public SavingsAccount() : base()
            { }

            //Property. Bank changes interest rates.
            public double InterestRate
            {
                get
                {
                    return savingsInterestRate;
                }
                set
                {
                    savingsInterestRate = value;
                }
            }

            public double Interest
            {
                get
                {
                    CalculateInterest();
                    return interest;
                }
            }

            // Methods
            public void CalculateInterest() //calculate annual interest
            {
                if (base.currentAmt > 0)
                {
                    interest = base.currentAmt * savingsInterestRate;
                }
                else
                {
                    interest = 0;
                }
            }

            public void CreditInterest()
            {
                base.Deposit(interest);
            }

        }

        public class CurrentAccount : Account
        {
            static double currentInterestRate;
            double interest;

            //Constructor
            public CurrentAccount(string accountNum, Customer data, double initialAmt) : base(accountNum, data, initialAmt)
            {
                currentInterestRate = 0.025;
            }

            public CurrentAccount() : base()
            { }

            //Property. Bank changes interest rates.
            public double InterestRate
            {
                get
                {
                    return currentInterestRate;
                }
                set
                {
                    currentInterestRate = value;
                }
            }

            public double Interest
            {
                get
                {
                    CalculateInterest();
                    return interest;
                }
            }

            // Methods
            public void CalculateInterest() //calculate annual interest
            {
                if (base.currentAmt > 0)
                {
                    interest = base.currentAmt * currentInterestRate;
                }
                else
                {
                    interest = 0;
                }
            }

            public void CreditInterest()
            {
                base.Deposit(interest);
            }
        }

        public class OverdraftAccount : Account
        {
            double interestRateNeg = 0.025;
            double interestRatePos = 0.06;
            static double currInterestRate;
            double interest;

            //Constructor
            public OverdraftAccount(string accountNum, Customer data, double initialAmt) : base(accountNum, data, initialAmt)
            {
                setCurrInterestRate();
            }

            public OverdraftAccount() : base()
            { }

            //Property. Bank changes interest rates.
            public double InterestRateNeg
            {
                get
                {
                    return interestRateNeg;
                }
                set
                {
                    interestRateNeg = value;
                }
            }

            public double InterestRatePos
            {
                get
                {
                    return interestRatePos;
                }
                set
                {
                    interestRatePos = value;
                }
            }

            public double Interest
            {
                get
                {
                    CalculateInterest();
                    return interest;
                }
            }

            // Methods
            public void CalculateInterest() //calculate annual interest
            {
                setCurrInterestRate();
                interest = base.currentAmt * currInterestRate;
            }

            public void CreditInterest()
            {
                base.Deposit(interest);
            }

            private void setCurrInterestRate()
            {
                if (base.currentAmt < 0)
                {
                    currInterestRate = interestRateNeg;
                }
                else
                {
                    currInterestRate = interestRatePos;
                }
            }
        }
    }
}
