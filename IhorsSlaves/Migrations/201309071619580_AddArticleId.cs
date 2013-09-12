namespace IhorsSlaves.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticleId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ArticleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "ArticleId");
        }
    }
}
