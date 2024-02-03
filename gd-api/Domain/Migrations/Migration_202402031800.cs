using FluentMigrator;

namespace gd_api.Domain.Migrations
{
    [Migration(202402031800)]
    public class Migration_202402031800 : FluentMigrator.Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Create.Table("address")
                .WithColumn("id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("createdat").AsDateTime().NotNullable()
                .WithColumn("updatedat").AsDateTime().NotNullable()
                .WithColumn("active").AsBoolean().NotNullable()
                .WithColumn("street").AsString(100).NotNullable()
                .WithColumn("number").AsString(20).NotNullable()
                .WithColumn("city").AsString(100).Nullable()
                .WithColumn("state").AsString(100).Nullable()
                .WithColumn("zipcode").AsString(20).Nullable();

            Create.Table("company")
                .WithColumn("id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("createdat").AsDateTime().NotNullable()
                .WithColumn("updatedat").AsDateTime().NotNullable()
                .WithColumn("active").AsBoolean().NotNullable()
                .WithColumn("name").AsString(100).NotNullable()
                .WithColumn("phone").AsString(20).NotNullable()
                .WithColumn("description").AsString(1024).Nullable()
                .WithColumn("addressid").AsGuid().ForeignKey("address", "id").Nullable();

            Create.Table("product")
                .WithColumn("id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("createdat").AsDateTime().NotNullable()
                .WithColumn("updatedat").AsDateTime().NotNullable()
                .WithColumn("active").AsBoolean().NotNullable()
                .WithColumn("name").AsString(100).NotNullable()
                .WithColumn("description").AsString(1024).Nullable()
                .WithColumn("price").AsDecimal().NotNullable()
                .WithColumn("companyid").AsGuid().ForeignKey("company", "id").NotNullable();
        }
    }
}
