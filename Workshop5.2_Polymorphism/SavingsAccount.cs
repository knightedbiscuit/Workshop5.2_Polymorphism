using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5._2_Polymorphism
{
    public class SavingsAccount : Account
    {
        public static double savingsInterestRate = 0.01;
        double interest;

        //Constructor
        public SavingsAccount(string accountNum, Customer data, double initialAmt) : base(accountNum, data, initialAmt)
        {
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

        public override double Interest
        {
            get
            {
                CalculateInterest();
                return interest;
            }
        }

        // Methods
        public override void CalculateInterest() //calculate annual interest
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

        public override void CreditInterest()
        {
            base.Deposit(interest);
        }

    }
}
