namespace DocShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaiLieux", "Anh", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaiLieux", "Anh");
        }
    }
}
