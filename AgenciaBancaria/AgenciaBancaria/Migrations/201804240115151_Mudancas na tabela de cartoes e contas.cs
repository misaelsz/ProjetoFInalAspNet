namespace AgenciaBancaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mudancasnatabeladecartoesecontas : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cartoes", new[] { "Conta_Id" });
            CreateIndex("dbo.Cartoes", "conta_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cartoes", new[] { "conta_Id" });
            CreateIndex("dbo.Cartoes", "Conta_Id");
        }
    }
}
