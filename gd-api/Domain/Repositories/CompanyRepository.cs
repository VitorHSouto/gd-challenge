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
            try
            {
                var sql = "SELECT DISTINCT c.* FROM company c ";

                if (!string.IsNullOrEmpty(searchText))
                {
                    var searchableText = $"UNACCENT('%{searchText}%')";

                    sql += @$"LEFT JOIN product p ON c.id = p.companyid
                    WHERE
                        UNACCENT(c.name) ILIKE {searchableText} OR
                        UNACCENT(p.name) ILIKE {searchableText} OR
                        UNACCENT(p.description) ILIKE {searchableText} ";
                }

                sql += "ORDER BY c.name DESC";

                return await QueryAsync(sql, new { searchText });
            }
            catch (Exception ex)
            {
                throw new Exception("dsds");
            }
        }
    }
}
