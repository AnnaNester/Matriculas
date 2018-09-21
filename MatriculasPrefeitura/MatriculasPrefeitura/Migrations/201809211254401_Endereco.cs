namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Endereco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        CEP = c.String(),
                        Bairro = c.String(),
                        Localidade = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            AddColumn("dbo.Cursos", "Latitude", c => c.String());
            AddColumn("dbo.Cursos", "Longitutde", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cursos", "Longitutde");
            DropColumn("dbo.Cursos", "Latitude");
            DropTable("dbo.Endereco");
        }
    }
}
