using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public interface IJogadorRepository
    {
        public void CriarJogador(JogadorModelo jogador);
        public JogadorModelo ObterJogadorPorId(long id);
        public List<JogadorModelo> ObterTodosJogadores() ;
        public void DeletarJogador(JogadorModelo jogador) ;
        public void AtualizarJogador(JogadorModelo jogadorAtualizado, JogadorModelo jogadorAtual) ;
       
    }
}
