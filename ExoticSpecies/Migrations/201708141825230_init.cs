namespace ExoticSpeciesOfTheNorth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Homelands",
                c => new
                    {
                        HomelandId = c.Int(nullable: false, identity: true),
                        HomelandName = c.String(),
                    })
                .PrimaryKey(t => t.HomelandId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        SpeciesName = c.String(),
                        DateIntroduced = c.DateTime(nullable: false),
                        HomelandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpeciesId)
                .ForeignKey("dbo.Homelands", t => t.HomelandId, cascadeDelete: true)
                .Index(t => t.HomelandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Species", "HomelandId", "dbo.Homelands");
            DropIndex("dbo.Species", new[] { "HomelandId" });
            DropTable("dbo.Species");
            DropTable("dbo.Homelands");
        }
    }
}
