namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        NumAluno = c.Int(nullable: false, identity: true),
                        NomeAluno = c.String(nullable: false, maxLength: 100),
                        CPFAluno = c.String(nullable: false),
                        FotoAluno = c.String(),
                        EnderecoAluno = c.String(nullable: false),
                        SenhaAluno = c.String(nullable: false),
                        CursoMatriculado_CursoId = c.Int(),
                    })
                .PrimaryKey(t => t.NumAluno)
                .ForeignKey("dbo.Cursos", t => t.CursoMatriculado_CursoId)
                .Index(t => t.CursoMatriculado_CursoId);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        NomeCurso = c.String(nullable: false),
                        DuracaoCurso = c.Int(nullable: false),
                        LocalCurso = c.String(),
                        QtdeVagas = c.Int(nullable: false),
                        DescricaoCurso = c.String(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        CategoriaCurso_CategoriaId = c.Int(nullable: false),
                        ProfessorCurso_NumProfessor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.CategoriaCursoes", t => t.CategoriaCurso_CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Professores", t => t.ProfessorCurso_NumProfessor, cascadeDelete: true)
                .Index(t => t.CategoriaCurso_CategoriaId)
                .Index(t => t.ProfessorCurso_NumProfessor);
            
            CreateTable(
                "dbo.CategoriaCursoes",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(nullable: false),
                        DescricaoCategoria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Professores",
                c => new
                    {
                        NumProfessor = c.Int(nullable: false, identity: true),
                        NomeProfessor = c.String(nullable: false, maxLength: 100),
                        CPFProfessor = c.String(nullable: false),
                        FormacaoProfessor = c.String(),
                        FotoProfessor = c.String(),
                        EnderecoProfessor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NumProfessor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alunos", "CursoMatriculado_CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Cursos", "ProfessorCurso_NumProfessor", "dbo.Professores");
            DropForeignKey("dbo.Cursos", "CategoriaCurso_CategoriaId", "dbo.CategoriaCursoes");
            DropIndex("dbo.Cursos", new[] { "ProfessorCurso_NumProfessor" });
            DropIndex("dbo.Cursos", new[] { "CategoriaCurso_CategoriaId" });
            DropIndex("dbo.Alunos", new[] { "CursoMatriculado_CursoId" });
            DropTable("dbo.Professores");
            DropTable("dbo.CategoriaCursoes");
            DropTable("dbo.Cursos");
            DropTable("dbo.Alunos");
        }
    }
}
