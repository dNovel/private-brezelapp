// <copyright file="Store.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    public class Timespan
    {
        protected Timespan() { }

        public Timespan(string start, string end)
        {
            this.Start = start;
            this.End = end;
        }

        public string Start { get; protected set; }
        public string End { get; protected set; }
    }
}