﻿namespace CRUD.Modelos
{
    public class JogadorModelo

    {
        public static long Count = 1;
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public Elo Elo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }

        public JogadorModelo(string nome, string sobrenome, string apelido, string email, Elo elo, DateTime dataNascimento)
        {
            Id = Count;
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