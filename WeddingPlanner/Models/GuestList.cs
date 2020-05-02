using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models
{
    public class GuestList
    {
        [Key]
        public int GuestListId { get; set; }

        public int UserId { get; set; }

        public int WeddingId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public User Attendee { get; set; }

        public Wedding Event{ get; set; }
    }
}