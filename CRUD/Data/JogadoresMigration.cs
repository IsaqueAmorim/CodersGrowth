using FluentMigrator;

namespace CRUD
{
    [Migration(20180430121800)]
    public class JogadoresMigration : Migration
    {
        public override void Up()
        {
            Create.Table("TB_Jogadores")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().Unique()
                .WithColumn("Nome").AsString().NotNullable()
                ;

        }

        public override void Down()
        {
            Delete.Table("Log");
        }
    }
}