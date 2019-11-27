using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blood_Donation_System.Models
{
    public class DonorsModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone_Number { get; set; }

        public string Blood_Type { get; set; }

    }
}
