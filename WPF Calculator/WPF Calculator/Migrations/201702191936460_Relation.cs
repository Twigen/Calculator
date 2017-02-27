namespace WPF_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Numbers", "UserId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Numbers", "UserId");
        }
    }
}
