namespace Aplicatie_web_cabinet_veterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTestsfromDb : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
