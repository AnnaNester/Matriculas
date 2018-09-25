namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popopopopo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alunos", "Logradouro", c => c.String(nullable: false));
            AddColumn("dbo.Alunos", "CEP", c => c.String(nullable: false));
            AddColumn("dbo.Alunos", "Bairro", c => c.String(nullable: false));
            AddColumn("dbo.Alunos", "Localidade", c => c.String(nullable: false));
            AddColumn("dbo.Alunos", "UF", c => c.String(nullable: false));
            AddColumn("dbo.Alunos", "Numero", c => c.Int(nullable: false));
            AddColumn("dbo.Professores", "Logradouro", c => c.String(nullable: false));
            AddColumn("dbo.Professores", "CEP", c => c.String(nullable: false));
            AddColumn("dbo.Professores", "Bairro", c => c.String(nullable: false));
            AddColumn("dbo.Professores", "Localidade", c => c.String(nullable: false));
            AddColumn("dbo.Professores", "UF", c => c.String(nullable: false));
            AddColumn("dbo.Professores", "Numero", c => c.Int(nullable: false));
            DropColumn("dbo.Alunos", "EnderecoAluno");
            DropColumn("dbo.Professores", "EnderecoProfessor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Professores", "EnderecoProfessor", c => c.String(nullable: false));
            AddColumn("dbo.Alunos", "EnderecoAluno", c => c.String(nullable: false));
            DropColumn("dbo.Professores", "Numero");
            DropColumn("dbo.Professores", "UF");
            DropColumn("dbo.Professores", "Localidade");
            DropColumn("dbo.Professores", "Bairro");
            DropColumn("dbo.Professores", "CEP");
            DropColumn("dbo.Professores", "Logradouro");
            DropColumn("dbo.Alunos", "Numero");
            DropColumn("dbo.Alunos", "UF");
            DropColumn("dbo.Alunos", "Localidade");
            DropColumn("dbo.Alunos", "Bairro");
            DropColumn("dbo.Alunos", "CEP");
            DropColumn("dbo.Alunos", "Logradouro");
        }
    }
}
