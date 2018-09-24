namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
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
                        FotoCurso = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Categoria_CategoriaId = c.Int(),
                        Professor_NumProfessor = c.Int(),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaId)
                .ForeignKey("dbo.Professores", t => t.Professor_NumProfessor)
                .Index(t => t.Categoria_CategoriaId)
                .Index(t => t.Professor_NumProfessor);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(nullable: false),
                        DescricaoCategoria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
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
            
            CreateTable(
                "dbo.Matricula",
                c => new
                    {
                        numMatricula = c.Int(nullable: false, identity: true),
                        DataMatricula = c.DateTime(nullable: false),
                        AlunoMatriculado_NumAluno = c.Int(),
                        CursoMatriculado_CursoId = c.Int(),
                    })
                .PrimaryKey(t => t.numMatricula)
                .ForeignKey("dbo.Alunos", t => t.AlunoMatriculado_NumAluno)
                .ForeignKey("dbo.Cursos", t => t.CursoMatriculado_CursoId)
                .Index(t => t.AlunoMatriculado_NumAluno)
                .Index(t => t.CursoMatriculado_CursoId);
            
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
            DropForeignKey("dbo.Cursos", "Professor_NumProfessor", "dbo.Professores");
            DropForeignKey("dbo.Matricula", "CursoMatriculado_CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Matricula", "AlunoMatriculado_NumAluno", "dbo.Alunos");
            DropForeignKey("dbo.Alunos", "CursoMatriculado_CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Cursos", "Categoria_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Matricula", new[] { "CursoMatriculado_CursoId" });
            DropIndex("dbo.Matricula", new[] { "AlunoMatriculado_NumAluno" });
            DropIndex("dbo.Cursos", new[] { "Professor_NumProfessor" });
            DropIndex("dbo.Cursos", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.Alunos", new[] { "CursoMatriculado_CursoId" });
            DropTable("dbo.Professores");
            DropTable("dbo.Matricula");
            DropTable("dbo.Endereco");
            DropTable("dbo.Categoria");
            DropTable("dbo.Cursos");
            DropTable("dbo.Alunos");
        }
    }
}
