namespace DJLNET.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        JumpUrl = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Platform",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EnglishName = c.String(nullable: false, maxLength: 32),
                        ChineseName = c.String(nullable: false, maxLength: 32),
                        DomainUrl = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Platform");
            DropTable("dbo.City");
        }
    }
}
