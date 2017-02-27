namespace WPF_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Index : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Login", c => c.String(maxLength: 450, unicode: false));
            CreateIndex("dbo.Users", "Login");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Login" });
            AlterColumn("dbo.Users", "Login", c => c.String());
        }
    }
}
