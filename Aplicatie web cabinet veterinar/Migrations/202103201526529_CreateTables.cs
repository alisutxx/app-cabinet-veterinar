namespace Aplicatie_web_cabinet_veterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstimativePrice = c.Double(nullable: false),
                        Price = c.Double(),
                        Date = c.DateTime(nullable: false),
                        PetId = c.Int(nullable: false),
                        MedicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.MedicId, cascadeDelete: false)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: false)
                .Index(t => t.PetId)
                .Index(t => t.MedicId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 63),
                        LastName = c.String(nullable: false, maxLength: 31),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 31),
                        Specialization = c.String(maxLength: 63),
                        IsDeleted = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 31),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 63),
                        Species = c.String(nullable: false, maxLength: 63),
                        Breed = c.String(maxLength: 63),
                        BirthDate = c.DateTime(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: false)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.AppointmentServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.AppointmentId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 53),
                        Description = c.String(nullable: false, maxLength: 255),
                        Price = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 127),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AppointmentServices", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "MedicId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Services", new[] { "CategoryId" });
            DropIndex("dbo.AppointmentServices", new[] { "ServiceId" });
            DropIndex("dbo.AppointmentServices", new[] { "AppointmentId" });
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Appointments", new[] { "MedicId" });
            DropIndex("dbo.Appointments", new[] { "PetId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Services");
            DropTable("dbo.AppointmentServices");
            DropTable("dbo.Pets");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Appointments");
        }
    }
}
