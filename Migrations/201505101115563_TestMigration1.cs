namespace ReapersTest3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderHistoryModels",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderProduct = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostCode", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderHistoryModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OrderHistoryModels", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "PostCode");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.OrderHistoryModels");
        }
    }
}
