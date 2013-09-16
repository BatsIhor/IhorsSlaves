using System.Data.Entity.Migrations;

namespace IhorsSlaves.Migrations
{
    public partial class AddRequiredToComment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "User", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Comments", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false, maxLength: 800));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String(maxLength: 800));
            AlterColumn("dbo.Comments", "Email", c => c.String());
            AlterColumn("dbo.Comments", "User", c => c.String(maxLength: 40));
        }
    }
}
