using gd_api.Domain.Entities;
using gd_api.Domain.Settings;

namespace gd_api.Domain.Repositories
{
    public class CompanyRepository : RepositoryBase<CompanyEntity>
    {
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext, "public.company")
        {
        }
    }
}
