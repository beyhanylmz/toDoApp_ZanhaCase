namespace toDoApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContentStr = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contents");
        }
    }
}
