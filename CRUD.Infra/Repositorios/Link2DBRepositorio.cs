﻿using CRUD.Modelos;
using CRUD.Repositorios;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using System.Configuration;
namespace CRUD.Infra.Repositorios
{
    public class Link2DBRepositorio : IRepositorioJogadores
    {
        static string connectionString = ConfigurationManager
               .ConnectionStrings["ConexaoMeuPC"]
               .ConnectionString;

        DataConnection _conexao = SqlServerTools.CreateDataConnection(connectionString);
        
        public void AtualizarJogador(JogadorModelo jogador)
        {
            _conexao.Update<JogadorModelo>(jogador);
        }

        public void CriarJogador(JogadorModelo jogador)
        {
            _conexao.Insert<JogadorModelo>(jogador);
        }

        public void DeletarJogador(long id)
        {
            var jogador = ObterJogadorPorId(id);
            _conexao.Delete<JogadorModelo>(jogador);
             
        }

        public JogadorModelo ObterJogadorPorId(long id)
        {
            
            return _conexao.GetTable<JogadorModelo>().FirstOrDefault(jogador => jogador.Id == id) ?? throw new Exception("Joganor não encontrado.");
        }

        public List<JogadorModelo> ObterTodosJogadores()
        {
            var jogadores = _conexao.GetTable<JogadorModelo>().ToList();

            return jogadores;
        }

    }
}