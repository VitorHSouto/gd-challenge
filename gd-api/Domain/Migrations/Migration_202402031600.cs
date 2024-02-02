using FluentMigrator;

namespace gd_api.Domain.Migrations
{
    [Migration(202402031600)]
    public class Migration_202402031600 : FluentMigrator.Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Create.Table("user")
                .WithColumn("id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("createdat").AsDateTime().NotNullable()
                .WithColumn("updatedat").AsDateTime().NotNullable()
                .WithColumn("active").AsBoolean().NotNullable()
                .WithColumn("email").AsString(100).NotNullable()
                .WithColumn("password").AsString(100).NotNullable();
        }
    }
}
