using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5._2_Polymorphism
{
    public class Customer : Object
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
        public override string ToString()
        {
            return (String.Format("{0}\t\t{1}\t\t{2}\t\t{3} ", name, address, nric, age));
        }
    }
}
