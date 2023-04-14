using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class JogadorModelo
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public Elo Elo { get; set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public JogadorModelo(string Nome,string Sobrenome,string NickName,string Email,Elo Elo,DateTime DataNascimento)
        {
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
            this.Apelido = NickName;
            this.Email = Email;
            this.Elo = Elo;
            this.DataNascimento = DataNascimento;
            this.DataCriacao = DateTime.Now;
            
        }

    }
}
