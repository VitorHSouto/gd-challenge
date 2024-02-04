using FluentMigrator;

namespace gd_api.Domain.Migrations
{
    [Migration(202402041700)]
    public class Migration_202402041700 : FluentMigrator.Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Alter.Table("user").AddColumn("name").AsString(100).Nullable();
        }
    }
}
