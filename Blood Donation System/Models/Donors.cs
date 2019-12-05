using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blood_Donation_System.Models
{
    public class Donors
    {
        public Donors()
        {
            Donations = new HashSet<Donations>();
        }

        [Key, Display(Name = "Donor ID")]
        public int DonorId { get; set; }

        [Required, Display(Name ="Full Name")]
        public string FullName { get; set; }

        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Weight { get; set; }

        [Required]
        public string Disease { get; set; }

        [Required, Display(Name = "Mobile")]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Occupation { get; set; }

        public ICollection<Donations> Donations { get; set; }
    }

    public class Donations
    {
        [Key, Display(Name = "Donation ID")]
        public int DonationId { get; set; }

        [Required, Display(Name = "Donation City")]
        public string DonationCity { get; set; }

        [Required, Display(Name = "Amount(Liters)")]
        public int Amount { get; set; }

        [Required, Display(Name = "Donation Date")]
        public string DonatonDate { get; set; }

        [Display(Name = "Donor ID")]
        public int CurrentDonorId { get; set; }
        [Display(Name = "Donor ID")]
        public Donors Donor { get; set; }
    }
}
