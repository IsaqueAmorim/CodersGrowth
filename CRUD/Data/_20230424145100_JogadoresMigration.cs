using FluentMigrator;

namespace CRUD
{
    [Migration(20230424145100)]
    public class _20230424145100_JogadoresMigration : Migration
    {
        public override void Up()
        {
            Create.Table("TB_Jogadores")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().Unique()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Sobrenome").AsString().NotNullable()
                .WithColumn("E-mail").AsString().NotNullable()
                .WithColumn("Apelido").AsString().Unique().NotNullable()
                .WithColumn("Elo").AsString().NotNullable()
                .WithColumn("Data de Nascimento").AsDateTime().NotNullable()
                .WithColumn("Data de Criação").AsDateTime().NotNullable();
                

        }

        public override void Down()
        {
            Delete.Table("TB_Jogadores");
        }
    }
}