namespace Aplicatie_web_cabinet_veterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRoles : DbMigration
    {
        public override void Up()
        {
            Sql("insert into roles values ('Utilizator')");
            Sql("insert into roles values ('Angajat')");
            Sql("insert into roles values ('Manager')");
            Sql("insert into roles values ('Admin')");
        }
        
        public override void Down()
        {
            Sql("delete from roles");
        }
    }
}
