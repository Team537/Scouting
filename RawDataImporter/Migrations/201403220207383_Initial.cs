namespace RawDataImporter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportantMatchDatas",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        MatchNumber = c.Int(nullable: false),
                        TeamNumber = c.Int(nullable: false),
                        AutonomousHighMade = c.Int(nullable: false),
                        TrussesMade = c.Int(nullable: false),
                        TrussesAttempted = c.Int(nullable: false),
                        Catches = c.Int(nullable: false),
                        Possessions = c.Int(nullable: false),
                        HighGoals = c.Int(nullable: false),
                        HighGoalsAttempted = c.Int(nullable: false),
                        BallsDropped = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImportantMatchDatas");
        }
    }
}
