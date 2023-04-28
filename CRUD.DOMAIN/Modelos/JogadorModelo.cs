using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Modelos
{
    [Table("tb_jogadores")]
    public class JogadorModelo
    {
        [PrimaryKey, Identity]
        public long Id { get; set; }

        [NotNull("O Nome não pode ser nulo!")]
        [MaxLength(50, ErrorMessage = "O Nome pode conter no máximo 50 caracteres")]
        [MinLength(2, ErrorMessage = "O Nome deve ter no mínimo 2 caracteres!")]
        [Column("Nome")]
        public string Nome { get; set; }


        [NotNull("O Sobrenome não pode ser nulo!")]
        [MaxLength(50, ErrorMessage = "O Sobrenome pode conter no máximo 50 caracteres")]
        [MinLength(2, ErrorMessage = "O Sobrenome deve ter no mínimo 2 caracteres!")]
        [Column("Sobrenome")]
        public string Sobrenome { get; set; }


        [NotNull("O Apelido não pode ser nulo!")]
        [MaxLength(50, ErrorMessage = "O Apelido pode conter no máximo 50 caracteres")]
        [MinLength(2, ErrorMessage = "O Apelido deve ter no mínimo 2 caracteres!")]
        [Column("Apelido")]
        public string Apelido { get; set; }


        [NotNull("O Email não pode ser nulo!")]
        [MaxLength(70, ErrorMessage = "O Email pode conter no máximo 70 caracteres")]
        [MinLength(2, ErrorMessage = "O Eamil deve ter no mínimo 2 caracteres!")]
        [Column("Email")]
        public string Email { get; set; }


        [Column("Elo")]
        public Elo Elo { get; set; }


        [Column("Data_de_Nascimento")]
        public DateTime DataNascimento { get; set; }


        [Column("Data_de_Criacao")]
        public DateTime DataCriacao { get; set; }


        public JogadorModelo(string nome, string sobrenome, string apelido, string email, Elo elo, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Apelido = apelido;
            Email = email;
            Elo = elo;
            DataNascimento = dataNascimento;
        }
        public JogadorModelo()
        {

        }



    }
}
