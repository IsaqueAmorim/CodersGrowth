using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class JogadorModelo

    {
        public static long Count = 1;
        public long Id { get;set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public Elo Elo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }

        public JogadorModelo(string nome,string sobrenome,string apelido,string email,Elo elo,DateTime dataNascimento)
        {
            this.Id = Count;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Apelido = apelido;
            this.Email = email;
            this.Elo = elo;
            this.DataNascimento = dataNascimento;
           
           
            
        }
        public JogadorModelo() 
        {
            Id = Count;
        }
       
    

    }
}
