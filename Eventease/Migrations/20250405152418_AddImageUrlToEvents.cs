using Eventease.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eventease.Models
{
    public class Events
    {
        public int EventID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int VenueID { get; set; }

        // Navigation property to the Venue table
        public virtual Venue Venue { get; set; }
    }
}