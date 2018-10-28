namespace MvcMusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class album : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Album_AlbumID", "dbo.Albums");
            DropIndex("dbo.Reviews", new[] { "Album_AlbumID" });
            RenameColumn(table: "dbo.Reviews", name: "Album_AlbumID", newName: "AlbumID");
            AlterColumn("dbo.Reviews", "AlbumID", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "AlbumID");
            AddForeignKey("dbo.Reviews", "AlbumID", "dbo.Albums", "AlbumID", cascadeDelete: true);
            DropColumn("dbo.Reviews", "AlmbumID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "AlmbumID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "AlbumID", "dbo.Albums");
            DropIndex("dbo.Reviews", new[] { "AlbumID" });
            AlterColumn("dbo.Reviews", "AlbumID", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "AlbumID", newName: "Album_AlbumID");
            CreateIndex("dbo.Reviews", "Album_AlbumID");
            AddForeignKey("dbo.Reviews", "Album_AlbumID", "dbo.Albums", "AlbumID");
        }
    }
}
