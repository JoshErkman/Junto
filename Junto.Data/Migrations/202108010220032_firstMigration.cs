namespace Junto.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "TeamId", "dbo.Team");
            RenameColumn(table: "dbo.Message", name: "User_Id", newName: "Id");
            RenameIndex(table: "dbo.Message", name: "IX_User_Id", newName: "IX_Id");
            AddColumn("dbo.Team", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Team", "Id");
            AddForeignKey("dbo.Team", "Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Message", "TeamId", "dbo.Team", "TeamId");
            DropColumn("dbo.Team", "UserId");
            DropColumn("dbo.Message", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Team", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Message", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Team", new[] { "Id" });
            DropColumn("dbo.Team", "Id");
            RenameIndex(table: "dbo.Message", name: "IX_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Message", name: "Id", newName: "User_Id");
            AddForeignKey("dbo.Message", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
        }
    }
}
