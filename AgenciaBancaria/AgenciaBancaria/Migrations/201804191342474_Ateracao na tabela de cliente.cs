namespace AgenciaBancaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ateracaonatabeladecliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "code", c => c.String());
            AddColumn("dbo.Clientes", "status", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "state", c => c.String());
            AddColumn("dbo.Clientes", "city", c => c.String());
            AddColumn("dbo.Clientes", "district", c => c.String());
            AddColumn("dbo.Clientes", "address", c => c.String());
            DropColumn("dbo.Clientes", "CEP");
            DropColumn("dbo.Clientes", "Logradouro");
            DropColumn("dbo.Clientes", "Bairro");
            DropColumn("dbo.Clientes", "Localidade");
            DropColumn("dbo.Clientes", "Uf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Uf", c => c.String());
            AddColumn("dbo.Clientes", "Localidade", c => c.String());
            AddColumn("dbo.Clientes", "Bairro", c => c.String());
            AddColumn("dbo.Clientes", "Logradouro", c => c.String());
            AddColumn("dbo.Clientes", "CEP", c => c.String());
            DropColumn("dbo.Clientes", "address");
            DropColumn("dbo.Clientes", "district");
            DropColumn("dbo.Clientes", "city");
            DropColumn("dbo.Clientes", "state");
            DropColumn("dbo.Clientes", "status");
            DropColumn("dbo.Clientes", "code");
        }
    }
}
