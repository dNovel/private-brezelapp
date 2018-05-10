// <copyright file="IEntityAutoDateFields.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Contracts
{
    using System;

    public interface IEntityAutoDateFields
    {
        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }
    }
}
