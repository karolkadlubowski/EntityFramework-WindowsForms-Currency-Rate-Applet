namespace CryptoMoon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Currencies");
        }
        
    }
}
