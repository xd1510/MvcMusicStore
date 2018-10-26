namespace MvcMusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosvarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        AlmbumID = c.Int(nullable: false),
                        Contents = c.String(),
                        ReviwerEmail = c.String(nullable: false),
                        Album_AlbumID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID)
                .Index(t => t.Album_AlbumID);
            
            AddColumn("dbo.Albums", "Artist_ArtistID", c => c.Int());
            CreateIndex("dbo.Albums", "Artist_ArtistID");
            AddForeignKey("dbo.Albums", "Artist_ArtistID", "dbo.Artists", "ArtistID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Artist_ArtistID", "dbo.Artists");
            DropIndex("dbo.Reviews", new[] { "Album_AlbumID" });
            DropIndex("dbo.Albums", new[] { "Artist_ArtistID" });
            DropColumn("dbo.Albums", "Artist_ArtistID");
            DropTable("dbo.Reviews");
            DropTable("dbo.Artists");
        }
    }
}
