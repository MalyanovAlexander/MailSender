namespace MailSender.ConsoleTest2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumAddedStyleRemovedFromTrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackAlbums",
                c => new
                    {
                        Track_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Track_Id, t.Album_Id })
                .ForeignKey("dbo.Track", t => t.Track_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Track_Id)
                .Index(t => t.Album_Id);
            
            DropColumn("dbo.Track", "Style");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Track", "Style", c => c.Byte());
            DropForeignKey("dbo.TrackAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.TrackAlbums", "Track_Id", "dbo.Track");
            DropIndex("dbo.TrackAlbums", new[] { "Album_Id" });
            DropIndex("dbo.TrackAlbums", new[] { "Track_Id" });
            DropTable("dbo.TrackAlbums");
            DropTable("dbo.Albums");
        }
    }
}
