using FluentMigrator;

namespace gd_api.Domain.Migrations
{
    [Migration(202402072220)]
    public class Migration_202402072220 : FluentMigrator.Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {
            Execute.Sql("CREATE EXTENSION IF NOT EXISTS unaccent;");
        }
    }
}
