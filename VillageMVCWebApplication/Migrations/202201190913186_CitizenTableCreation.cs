namespace VillageMVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CitizenTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        CitizenId = c.Int(nullable: false, identity: true),
                        CitizenParent = c.String(),
                        Gender = c.String(),
                        IsBornInVillage = c.Boolean(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CitizenId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Citizens");
        }
    }
}
