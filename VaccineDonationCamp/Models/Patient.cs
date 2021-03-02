using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineDonationCamp.Models
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Dob  { get; set; }
        public  string ContactNo { get; set; }
        public string Email { get; set; }
        //public string Dob { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public int Id { get; set; }


        public Patient()
        {
            //Empty Constructor
        }

        public Patient(string firstName, string lastName, string dob, string email, string contactNo, string address, string city, string state, int Zip)
        {
            FirstName = firstName;
            LastName = lastName;
            Dob = dob;
            ContactNo = contactNo;
            Email = email;
            Address = address;
            City = city;
            State = state;
            Zip = Zip;
          
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
