using FluentMigrator;

namespace gd_api.Domain.Migrations
{
    [Migration(202402052000)]
    public class Migration_202402052000 : FluentMigrator.Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {
            Create.Table("file")
                .WithColumn("id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("createdat").AsDateTime().NotNullable()
                .WithColumn("updatedat").AsDateTime().NotNullable()
                .WithColumn("active").AsBoolean().NotNullable()
                .WithColumn("extension").AsString(50).NotNullable()
                .WithColumn("mimetype").AsString(255).NotNullable()
                .WithColumn("publicurl").AsString(255).NotNullable();

            Alter.Table("company")
                .AddColumn("bannerfileid").AsGuid().ForeignKey("file", "id").Nullable()
                .AddColumn("logofileid").AsGuid().ForeignKey("file", "id").Nullable();

            Alter.Table("product")
                .AddColumn("fileids").AsCustom("uuid[]").Nullable();
        }
    }
}
