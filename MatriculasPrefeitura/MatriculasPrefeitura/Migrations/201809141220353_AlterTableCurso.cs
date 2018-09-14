namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableCurso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursos", "FotoCurso", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cursos", "FotoCurso");
        }
    }
}
