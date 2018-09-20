namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matricular : DbMigration
    {
        public override void Up()
        {
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
            
            DropColumn("dbo.Alunos", "SenhaAluno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alunos", "SenhaAluno", c => c.String(nullable: false));
            DropForeignKey("dbo.Matricula", "CursoMatriculado_CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Matricula", "AlunoMatriculado_NumAluno", "dbo.Alunos");
            DropIndex("dbo.Matricula", new[] { "CursoMatriculado_CursoId" });
            DropIndex("dbo.Matricula", new[] { "AlunoMatriculado_NumAluno" });
            DropTable("dbo.Matricula");
        }
    }
}
