using gd_api.Domain.Entities;
using gd_api.Domain.Settings;

namespace gd_api.Domain.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext, "public.user")
        {

        }
    }
}
