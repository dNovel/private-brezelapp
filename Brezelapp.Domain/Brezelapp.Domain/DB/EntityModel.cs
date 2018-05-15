// <copyright file="EntityModel.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.DB
{
    using System;

    public class EntityModel
    {
        public EntityModel()
        {
            this.EntityId = Guid.NewGuid();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EntityId { get; protected set; }
    }
}
