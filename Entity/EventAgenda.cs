﻿using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class EventAgenda
    {
        [Key]
        public int EventID { get; set; }
        public int TripID { get; set; }
        public string Description { get; set; }
    }
}
