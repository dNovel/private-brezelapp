// <copyright file="Timespan.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    public class Timespan
    {
        public Timespan(string start, string end)
        {
            this.Start = start;
            this.End = end;
        }

        protected Timespan()
        {
        }

        public string Start { get; protected set; }

        public string End { get; protected set; }
    }
}