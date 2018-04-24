namespace AgenciaBancaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cartoes", new[] { "Conta_Id" });
            AddColumn("dbo.Contas", "Senha", c => c.String());
            CreateIndex("dbo.Cartoes", "conta_Id");
            DropColumn("dbo.Clientes", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Senha", c => c.String());
            DropIndex("dbo.Cartoes", new[] { "conta_Id" });
            DropColumn("dbo.Contas", "Senha");
            CreateIndex("dbo.Cartoes", "Conta_Id");
        }
    }
}
