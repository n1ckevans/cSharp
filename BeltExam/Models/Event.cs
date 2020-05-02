using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltExam.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public int UserId { get; set; }

        public int ActivityId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public User Attendee { get; set; }

        public Activity Activity { get; set; }
    }
}