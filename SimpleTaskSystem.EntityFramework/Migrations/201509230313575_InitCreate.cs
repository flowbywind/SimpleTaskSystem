namespace SimpleTaskSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StsPeople",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StsTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignedPersonId = c.Int(),
                        Title = c.String(maxLength: 50, storeType: "nvarchar"),
                        Description = c.String(maxLength: 200, storeType: "nvarchar"),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreationUserID = c.Int(nullable: false),
                        ModifyTime = c.DateTime(nullable: false, precision: 0),
                        ModifyUserID = c.Int(nullable: false),
                        BeginTime = c.DateTime(nullable: false, precision: 0),
                        EndTime = c.DateTime(nullable: false, precision: 0),
                        TaskLevel = c.Byte(nullable: false),
                        TaskState = c.Byte(nullable: false),
                        TaskCategory = c.Byte(nullable: false),
                        RepeatMode = c.Byte(nullable: false),
                        Frequency = c.Int(nullable: false),
                        RepeatDays = c.String(maxLength: 50, storeType: "nvarchar"),
                        RepeatType = c.Byte(nullable: false),
                        RemindType = c.Byte(nullable: false),
                        RemindTime = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StsPeople", t => t.AssignedPersonId)
                .Index(t => t.AssignedPersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StsTasks", "AssignedPersonId", "dbo.StsPeople");
            DropIndex("dbo.StsTasks", new[] { "AssignedPersonId" });
            DropTable("dbo.StsTasks");
            DropTable("dbo.StsPeople");
        }
    }
}
