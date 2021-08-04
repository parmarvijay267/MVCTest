using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCTest.Models.DBEntities
{
    public partial class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public bool? Gender { get; set; }
        [Required(ErrorMessage = "Birthdate is required")]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address1 is required")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Address2 is required")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Pincode is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{6}$", ErrorMessage = "Please enter valid 6 digit Pincode.")]
        public string PinCode { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
    }
}
