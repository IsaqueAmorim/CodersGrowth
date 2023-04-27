using CRUD.Modelos;
using CRUD.Repositorios;
using LinqToDB;
using LinqToDB.Data;
using System.Net.Http.Headers;

namespace CRUD.Infra.Repositorios
{
    public class Link2DBRepositorio : IRepositorioJogadores
    {

        private DataConnection _conexao;
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
            return _conexao.GetTable<JogadorModelo>().ToList();
        }
    }
}
