using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Modelos;

namespace CRUD.Repositorios
{
    public interface IRepositorioJogadores
    {
        public void CriarJogador(JogadorModelo jogador);
        public JogadorModelo ObterJogadorPorId(long id);
        public List<JogadorModelo> ObterTodosJogadores();
        public void DeletarJogador(JogadorModelo jogador);
        public void AtualizarJogador(JogadorModelo jogadorAtualizado, JogadorModelo jogadorAtual);

    }
}
