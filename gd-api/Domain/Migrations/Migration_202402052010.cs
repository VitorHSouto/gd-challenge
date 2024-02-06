using FluentMigrator;
using Microsoft.VisualBasic.FileIO;

namespace gd_api.Domain.Migrations
{
    [Migration(202402052010)]
    public class Migration_202402052010 : FluentMigrator.Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            InsertFile("https://images.pexels.com/photos/1640777/pexels-photo-1640777.jpeg");
            InsertFile("https://images.pexels.com/photos/376464/pexels-photo-376464.jpeg");
            InsertFile("https://images.pexels.com/photos/1279330/pexels-photo-1279330.jpeg");
            InsertFile("https://images.pexels.com/photos/1099680/pexels-photo-1099680.jpeg");
            InsertFile("https://images.pexels.com/photos/958545/pexels-photo-958545.jpeg");
            InsertFile("https://images.pexels.com/photos/1640774/pexels-photo-1640774.jpeg");
            InsertFile("https://images.pexels.com/photos/842571/pexels-photo-842571.jpeg");
            InsertFile("https://images.pexels.com/photos/1640772/pexels-photo-1640772.jpeg");
            InsertFile("https://images.pexels.com/photos/1660030/pexels-photo-1660030.jpeg");
            InsertFile("https://images.pexels.com/photos/784633/pexels-photo-784633.jpeg");
            InsertFile("https://images.pexels.com/photos/699953/pexels-photo-699953.jpeg");
            InsertFile("https://images.pexels.com/photos/1633525/pexels-photo-1633525.jpeg");
            InsertFile("https://images.pexels.com/photos/1109197/pexels-photo-1109197.jpeg");
            InsertFile("https://images.pexels.com/photos/1128678/pexels-photo-1128678.jpeg");
            InsertFile("https://images.pexels.com/photos/262959/pexels-photo-262959.jpeg");
            InsertFile("https://images.pexels.com/photos/769289/pexels-photo-769289.jpeg");
            InsertFile("https://images.pexels.com/photos/1391487/pexels-photo-1391487.jpeg");
            InsertFile("https://images.pexels.com/photos/2641886/pexels-photo-2641886.jpeg");
            InsertFile("https://images.pexels.com/photos/323682/pexels-photo-323682.jpeg");
            InsertFile("https://images.pexels.com/photos/1267320/pexels-photo-1267320.jpeg");
            InsertFile("https://images.pexels.com/photos/1092730/pexels-photo-1092730.jpeg");
            InsertFile("https://images.pexels.com/photos/718742/pexels-photo-718742.jpeg");

            var now = DateTime.UtcNow;

            Execute.Sql($@"UPDATE product as c
	            SET fileIds = ARRAY(
		            SELECT f.id FROM file f 
			            ORDER BY RANDOM() * c.price 
		            LIMIT 1
	            ), updatedat = '{now}'");

            Execute.Sql($@"UPDATE company AS c
                SET bannerfileid = (
                    SELECT UNNEST(p.fileids) FROM product p WHERE p.companyid = c.id ORDER BY RANDOM() LIMIT 1
                ), logofileid = (
                    SELECT UNNEST(p.fileids) FROM product p WHERE p.companyid = c.id ORDER BY RANDOM() LIMIT 1
                ), updatedat = '{now}'");
        }

        private void InsertFile(string publicUrl)
        {
            var fileId = Guid.NewGuid();
            var now = DateTime.UtcNow;

            Execute.Sql($@"INSERT INTO file
                (id, createdat, updatedat, active, extension, mimetype, publicurl)
                VALUES('{fileId}', '{now}', '{now}', true, '.jpg', 'image/jpeg', '{publicUrl}')");
        }

    }
}
