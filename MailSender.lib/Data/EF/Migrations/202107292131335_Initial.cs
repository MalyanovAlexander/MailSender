namespace MailSender.lib.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    //Add-Migration Initial -StartUpProjectName MailSender
    //Update-Database -StartUpProjectName MailSender
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EMails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipientsLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adress = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        RecipientsList_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RecipientsLists", t => t.RecipientsList_ID)
                .Index(t => t.RecipientsList_ID);
            
            CreateTable(
                "dbo.SchedulerTasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Email_ID = c.Int(nullable: false),
                        Recipients_ID = c.Int(nullable: false),
                        Sender_ID = c.Int(nullable: false),
                        Server_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EMails", t => t.Email_ID, cascadeDelete: true)
                .ForeignKey("dbo.RecipientsLists", t => t.Recipients_ID, cascadeDelete: true)
                .ForeignKey("dbo.Senders", t => t.Sender_ID, cascadeDelete: true)
                .ForeignKey("dbo.Servers", t => t.Server_ID, cascadeDelete: true)
                .Index(t => t.Email_ID)
                .Index(t => t.Recipients_ID)
                .Index(t => t.Sender_ID)
                .Index(t => t.Server_ID);
            
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adress = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Host = c.String(nullable: false),
                        Port = c.Int(nullable: false),
                        UseSSL = c.Boolean(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Descrition = c.String(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchedulerTasks", "Server_ID", "dbo.Servers");
            DropForeignKey("dbo.SchedulerTasks", "Sender_ID", "dbo.Senders");
            DropForeignKey("dbo.SchedulerTasks", "Recipients_ID", "dbo.RecipientsLists");
            DropForeignKey("dbo.SchedulerTasks", "Email_ID", "dbo.EMails");
            DropForeignKey("dbo.Recipients", "RecipientsList_ID", "dbo.RecipientsLists");
            DropIndex("dbo.SchedulerTasks", new[] { "Server_ID" });
            DropIndex("dbo.SchedulerTasks", new[] { "Sender_ID" });
            DropIndex("dbo.SchedulerTasks", new[] { "Recipients_ID" });
            DropIndex("dbo.SchedulerTasks", new[] { "Email_ID" });
            DropIndex("dbo.Recipients", new[] { "RecipientsList_ID" });
            DropTable("dbo.Servers");
            DropTable("dbo.Senders");
            DropTable("dbo.SchedulerTasks");
            DropTable("dbo.Recipients");
            DropTable("dbo.RecipientsLists");
            DropTable("dbo.EMails");
        }
    }
}
