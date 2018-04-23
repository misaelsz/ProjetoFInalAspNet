namespace AgenciaBancaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mudancasnastabelasclienteeconta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contas", "Senha", c => c.String());
            DropColumn("dbo.Clientes", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Senha", c => c.String());
            DropColumn("dbo.Contas", "Senha");
        }
    }
}
