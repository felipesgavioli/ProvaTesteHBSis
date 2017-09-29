namespace ProvaHBSis.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class script_Inicial_ProvaHBSis_SQL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        CpfCnpj = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Cliente");
        }
    }
}
