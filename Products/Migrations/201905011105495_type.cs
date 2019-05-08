namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class type : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "TypeId", c => c.Int());
            CreateIndex("dbo.Products", "TypeId");
            AddForeignKey("dbo.Products", "TypeId", "dbo.ProductTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "TypeId" });
            DropColumn("dbo.Products", "TypeId");
            DropTable("dbo.ProductTypes");
        }
    }
}
