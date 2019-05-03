namespace AgilTeamManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao1500 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tarefas", name: "Historia_Id", newName: "HistoriaId_Id");
            RenameIndex(table: "dbo.Tarefas", name: "IX_Historia_Id", newName: "IX_HistoriaId_Id");
            CreateTable(
                "dbo.HistoriaHistoricoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HistoriaId = c.Int(nullable: false),
                        Descricao = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        SprintId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tarefas", "UsuarioId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarefas", "UsuarioId");
            DropTable("dbo.HistoriaHistoricoes");
            RenameIndex(table: "dbo.Tarefas", name: "IX_HistoriaId_Id", newName: "IX_Historia_Id");
            RenameColumn(table: "dbo.Tarefas", name: "HistoriaId_Id", newName: "Historia_Id");
        }
    }
}
