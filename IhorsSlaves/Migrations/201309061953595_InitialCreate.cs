namespace IhorsSlaves.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostName = c.String(nullable: false, maxLength: 80),
                        Text = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        PostUser = c.String(),
                    })
                .PrimaryKey(t => t.PostId);

            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        Email = c.String(),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
        }
    }
}
