namespace WPF_Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Numbers", "Number", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Numbers", "Number", c => c.Int(nullable: false));
        }
    }
}
