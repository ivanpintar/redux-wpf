namespace ReduxWPF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateToTodo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todo", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todo", "Date");
        }
    }
}
