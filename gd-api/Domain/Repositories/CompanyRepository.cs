using gd_api.Domain.Entities;
using gd_api.Domain.Settings;

namespace gd_api.Domain.Repositories
{
    public class CompanyRepository : RepositoryBase<CompanyEntity>
    {
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext, "public.company")
        {
        }

        public async Task<List<CompanyEntity>> Filter(string searchText)
        {
            var sql = "SELECT DISTINCT c.* FROM company c ";

            if (!string.IsNullOrEmpty(searchText))
            {
                var searchableText = $"LOWER('%{searchText}%')";
                sql += @$"LEFT JOIN product p ON c.id = p.companyid
                    WHERE
		                LOWER(c.name) LIKE {searchableText} OR
		                LOWER(p.name) LIKE {searchableText} OR
		                LOWER(p.description) LIKE {searchableText} ";
            }

            sql += "ORDER BY c.name DESC";
	            
            return await QueryAsync(sql, new { searchText });
        }
    }
}
