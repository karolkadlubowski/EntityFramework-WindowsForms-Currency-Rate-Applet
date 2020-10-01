namespace CryptoMoon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstGiantStepForHumanityWhichMeansAddingRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DateRateCurrencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasureDate = c.DateTime(nullable: false),
                        Rate = c.Single(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DateRateCurrencies", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.DateRateCurrencies", new[] { "CurrencyId" });
            DropTable("dbo.DateRateCurrencies");
        }
    }
}
