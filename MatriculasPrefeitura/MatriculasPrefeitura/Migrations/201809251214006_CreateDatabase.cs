namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Professores", "EnderecoProfessor_EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Professores", new[] { "EnderecoProfessor_EnderecoId" });
            AddColumn("dbo.Professores", "EnderecoProfessor", c => c.String(nullable: false));
            DropColumn("dbo.Professores", "EnderecoProfessor_EnderecoId");
            DropTable("dbo.Endereco");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Professores", "EnderecoProfessor_EnderecoId", c => c.Int(nullable: false));
            DropColumn("dbo.Professores", "EnderecoProfessor");
            CreateIndex("dbo.Professores", "EnderecoProfessor_EnderecoId");
            AddForeignKey("dbo.Professores", "EnderecoProfessor_EnderecoId", "dbo.Endereco", "EnderecoId", cascadeDelete: true);
        }
    }
}
