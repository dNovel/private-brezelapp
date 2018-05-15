// <copyright file="IMappable.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Services.Contracts
{
    public interface IMappable<T>
    {
        T MapToDbModel();
    }
}
