using FluentMigrator;
using gd_api.Domain.Helpers;
using System;
using System.ComponentModel.Design;
using System.Globalization;

namespace gd_api.Domain.Migrations
{
    [Migration(202402072230)]
    public class Migration_202402072230 : FluentMigrator.Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {
            var email = "fred@graodireto.com.br";
            var password = TokenHelper.EncodeString("123Fred");
            var id = Guid.NewGuid();
            var now = DateTime.UtcNow;

            Execute.Sql($@"INSERT INTO public.user
                (id, createdat, updatedat, active, name, email, password)
                VALUES('{id}', '{now}', '{now}', true, 'Fred', '{email}', '{password}')");
        }
    }
}
