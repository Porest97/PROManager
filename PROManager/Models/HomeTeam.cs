﻿namespace PROManager.Models
{
    public class HomeTeam
    {
        public int Id { get; set; }

        public Team Team { get; set; }
        public int? TeamId { get; set; }
    }
}