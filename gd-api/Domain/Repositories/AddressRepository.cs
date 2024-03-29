﻿using gd_api.Domain.Entities;
using gd_api.Domain.Settings;

namespace gd_api.Domain.Repositories
{
    public class AddressRepository : RepositoryBase<AddressEntity>
    {
        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext, "public.address")
        {
        }
    }
}
