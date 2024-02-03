using gd_api.Domain.Entities;
using gd_api.Domain.Settings;

namespace gd_api.Domain.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext, "public.user")
        {

        }

        public async Task<UserEntity?> GetByLogin(string email, string password)
        {
            var sql = @$"SELECT * FROM {_tableName} 
                WHERE email = @email AND password = @password";

            var parameters = new { Email = email, Password = password };

            return await QueryFirstOrDefaultAsync(sql, parameters);
        }
    }
}
