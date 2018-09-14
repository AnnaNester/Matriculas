namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControllerViewUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
