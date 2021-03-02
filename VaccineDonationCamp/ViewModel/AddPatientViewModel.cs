using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineDonationCamp.ViewModel
{
    public class AddPatientViewModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3 and 50 charecters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3 and 50 charecters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
       
        public string Dob { get; set; }
       
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Enter contact no correctly.")]
        public string ContactNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public  string State { get; set; }
        public int Zip { get; set; }



    }
}
