using System;
using System.ComponentModel.DataAnnotations;

namespace Eventease.Models
{
    public class Venue
    {
        public int VenueID { get; set; }  // This is the primary key

        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        // Adding ImageUrl to Venue model
        public string ImageUrl { get; set; }  // New property to store venue image URL
    }
}
