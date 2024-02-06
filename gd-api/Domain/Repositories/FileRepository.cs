using gd_api.Domain.Entities;
using gd_api.Domain.Settings;

namespace gd_api.Domain.Repositories
{
    public class FileRepository : RepositoryBase<FileEntity>
    {
        public FileRepository(ApplicationDbContext dbContext) : base(dbContext, "public.file")
        {
        }
    }
}
