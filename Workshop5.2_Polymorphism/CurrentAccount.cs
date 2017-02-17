using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5._2_Polymorphism
{
    public class CurrentAccount : Account
    {
        public static double currentInterestRate = 0.025;
        double interest;

        //Constructor
        public CurrentAccount(string accountNum, Customer data, double initialAmt) : base(accountNum, data, initialAmt)
        {
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
                interest = base.currentAmt * currentInterestRate;
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
