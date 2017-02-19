using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5._2_Polymorphism
{
    public abstract class Account
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
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public abstract double Interest
        {
            get;
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

        public abstract void CalculateInterest();
        public abstract void CreditInterest();

        public override string ToString()
        {
            string customer = data.ToString();

            return (String.Format("{0}\t\t{1}\t\t{2}",accountNum,customer,currentAmt) );

        }
    }
}
