using gd_api.Domain.Entities;
using gd_api.Domain.Settings;

namespace gd_api.Domain.Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext, "public.product")
        {
        }

        public async Task<List<ProductEntity>> ListByCompanyId(Guid companyId)
        {
            var sql = @$"SELECT * FROM {_tableName} WHERE companyid = @companyId";
            return await QueryAsync(sql, new {companyId});
        }
    }
}
