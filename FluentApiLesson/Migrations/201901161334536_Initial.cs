namespace FluentApiLesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sports_players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Number = c.Int(nullable: false),
                        ref_team = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.ref_team, cascadeDelete: true)
                .Index(t => t.ref_team);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sports_players", "ref_team", "dbo.Teams");
            DropIndex("dbo.sports_players", new[] { "ref_team" });
            DropTable("dbo.Teams");
            DropTable("dbo.sports_players");
        }
    }
}
