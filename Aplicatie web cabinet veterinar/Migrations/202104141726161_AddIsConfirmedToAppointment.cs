namespace Aplicatie_web_cabinet_veterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsConfirmedToAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "IsConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "IsConfirmed");
        }
    }
}
