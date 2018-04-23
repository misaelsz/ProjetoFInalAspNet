namespace AgenciaBancaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroDoCartao = c.String(),
                        CodigoDeSeguranca = c.String(),
                        Limite = c.String(),
                        Debito = c.Double(nullable: false),
                        QUantidadeDeParcelas = c.Int(nullable: false),
                        ValorDaParcela = c.Double(nullable: false),
                        Conta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contas", t => t.Conta_Id)
                .Index(t => t.Conta_Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        code = c.String(),
                        status = c.Int(nullable: false),
                        state = c.String(),
                        city = c.String(),
                        district = c.String(),
                        address = c.String(),
                        Senha = c.String(),
                        conta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contas", t => t.conta_Id)
                .Index(t => t.conta_Id);
            
            CreateTable(
                "dbo.Contas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Agencia = c.String(),
                        numeroDaConta = c.String(),
                        DataDeCadastro = c.DateTime(nullable: false),
                        Saldo = c.Double(nullable: false),
                        DataDeCancelamento = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "conta_Id", "dbo.Contas");
            DropForeignKey("dbo.Cartoes", "Conta_Id", "dbo.Contas");
            DropIndex("dbo.Clientes", new[] { "conta_Id" });
            DropIndex("dbo.Cartoes", new[] { "Conta_Id" });
            DropTable("dbo.Contas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Cartoes");
        }
    }
}
