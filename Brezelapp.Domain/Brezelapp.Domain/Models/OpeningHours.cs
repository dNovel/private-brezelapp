// <copyright file="OpeningHours.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Contracts;

    public class OpeningHours : IEntityAutoDateFields
    {
        private Timespan[] timespans;

        protected OpeningHours()
        {
        }

        [Key]
        public int Id { get; set; }

        public Dictionary<System.DayOfWeek, List<Timespan>> OpeningTimespans { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}