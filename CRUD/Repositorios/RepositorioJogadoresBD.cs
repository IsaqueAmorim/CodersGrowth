using CRUD.Modelos;

namespace CRUD.Repositorios
{
    public class RepositorioJogadoresBD : IRepositorioJogadores
    {
        private string _connection;

        public void AtualizarJogador(JogadorModelo jogadorAtualizado, JogadorModelo jogadorAtual)
        {
            throw new NotImplementedException();
        }

        public void CriarJogador(JogadorModelo jogador)
        {
            throw new NotImplementedException();
        }

        public void DeletarJogador(JogadorModelo jogador)
        {
            throw new NotImplementedException();
        }

        public JogadorModelo ObterJogadorPorId(long id)
        {
            throw new NotImplementedException();
        }

        public List<JogadorModelo> ObterTodosJogadores()
        {
            throw new NotImplementedException();
        }
    }
}
