// <copyright file="Store.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Brezelapp.Models
{
    public class OpeningHours
    {
        private Timespan[] timespans;

        protected OpeningHours()
        {

        }

        public Dictionary<System.DayOfWeek, List<Timespan>> OpeningTimespans { get; set; }
    }
}