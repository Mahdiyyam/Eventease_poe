using System;
using System.ComponentModel.DataAnnotations;

namespace Eventease.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public int EventID { get; set; }

        public virtual Event Event { get; set; }
    }
}


