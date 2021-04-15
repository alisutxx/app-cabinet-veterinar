namespace Aplicatie_web_cabinet_veterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedToPets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "IsDeleted");
        }
    }
}
