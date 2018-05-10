// <copyright file="OpeningHours.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OpeningHours
    {
        private Timespan[] timespans;

        protected OpeningHours()
        {
        }

        [Key]
        public int Id { get; set; }

        public Dictionary<System.DayOfWeek, List<Timespan>> OpeningTimespans { get; set; }
    }
}