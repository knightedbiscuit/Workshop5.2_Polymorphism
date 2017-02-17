using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5._2_Polymorphism
{
    public class OverdraftAccount : Account
    {
        public static double interestRateNeg = 0.06;
        public static double interestRatePos = 0.025;
        double currInterestRate;
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
            setCurrInterestRate();
            interest = base.currentAmt * currInterestRate;
        }

        public override void CreditInterest()
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
