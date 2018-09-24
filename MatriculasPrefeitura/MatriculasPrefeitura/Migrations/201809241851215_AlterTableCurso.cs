namespace MatriculasPrefeitura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableCurso : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cursos", "DataInicio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cursos", "DataInicio", c => c.DateTime(nullable: false));
        }
    }
}
