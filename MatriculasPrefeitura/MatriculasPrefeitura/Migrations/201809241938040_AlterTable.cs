namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cursos", "Professor_NumProfessor", "dbo.Professores");
            DropIndex("dbo.Cursos", new[] { "Professor_NumProfessor" });
            DropColumn("dbo.Cursos", "Professor_NumProfessor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cursos", "Professor_NumProfessor", c => c.Int());
            CreateIndex("dbo.Cursos", "Professor_NumProfessor");
            AddForeignKey("dbo.Cursos", "Professor_NumProfessor", "dbo.Professores", "NumProfessor");
        }
    }
}
