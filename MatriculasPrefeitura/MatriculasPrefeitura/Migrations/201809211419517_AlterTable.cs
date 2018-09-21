namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cursos", "CategoriaCurso_CategoriaId", "dbo.CategoriaCursoes");
            DropIndex("dbo.Cursos", new[] { "CategoriaCurso_CategoriaId" });
            AlterColumn("dbo.Cursos", "CategoriaCurso_CategoriaId", c => c.Int());
            CreateIndex("dbo.Cursos", "CategoriaCurso_CategoriaId");
            AddForeignKey("dbo.Cursos", "CategoriaCurso_CategoriaId", "dbo.CategoriaCursoes", "CategoriaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cursos", "CategoriaCurso_CategoriaId", "dbo.CategoriaCursoes");
            DropIndex("dbo.Cursos", new[] { "CategoriaCurso_CategoriaId" });
            AlterColumn("dbo.Cursos", "CategoriaCurso_CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cursos", "CategoriaCurso_CategoriaId");
            AddForeignKey("dbo.Cursos", "CategoriaCurso_CategoriaId", "dbo.CategoriaCursoes", "CategoriaId", cascadeDelete: true);
        }
    }
}
