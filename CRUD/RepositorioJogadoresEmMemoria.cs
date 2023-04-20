using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class RepositorioJogadoresEmMemoria : IRepositorioJogadoresEmMemoria
    {
        private List<JogadorModelo> listaJogadores = ListaSingleton.ObterInstancia();
        public void AtualizarJogador(JogadorModelo jogadorAtualizado,JogadorModelo jogadorAtual)
        {
            listaJogadores[listaJogadores.IndexOf(jogadorAtual)] = jogadorAtualizado;
        }

        public void CriarJogador(JogadorModelo jogador)
        {
            listaJogadores.Add(jogador);
        }

        public void DeletarJogador(JogadorModelo jogador)
        {
            listaJogadores.Remove(jogador);
        }

        public JogadorModelo ObterJogadorPorId(long id)
        {
            var jogador = listaJogadores.Find(x => x.Id == id) 
                ?? throw new Exception("Jogador não Encontrado");

            return jogador;
        }

        public List<JogadorModelo> ObterTodosJogadores()
        {
            return listaJogadores;
        }
    }
}
