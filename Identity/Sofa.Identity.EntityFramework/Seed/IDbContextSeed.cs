// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;

namespace Sofa.Identity.EntityFramework.Seed
{
    public interface IDbContextSeed
    {
        void Seed(ModelBuilder modelBuilder);
    }
}
