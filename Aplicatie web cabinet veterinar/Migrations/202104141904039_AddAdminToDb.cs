namespace Aplicatie_web_cabinet_veterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using System.Security.Cryptography;

	public partial class AddAdminToDb : DbMigration
    {
        public override void Up()
        {
            var md5 = MD5.Create();
            var pas = Convert.ToBase64String(md5.ComputeHash(System.Text.UTF8Encoding.Default.GetBytes("123qwe!@#")));
            Sql($"INSERT INTO [dbo].[Users] VALUES ('Admin', 'Admin', 'petronela.bigu@yahoo.com', '{pas}', '0123456789', null, 0, 4)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [dbo].[Users] WHERE Email = 'petronela.bigu@yahoo.com'");
        }
    }
}
