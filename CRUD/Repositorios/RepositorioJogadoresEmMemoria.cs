using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Modelos;

namespace CRUD.Repositorios
{
    public class RepositorioJogadoresEmMemoria:IRepositorioJogadores
    {
        private List<JogadorModelo> listaJogadores = ListaSingleton.ObterInstancia();
        public void AtualizarJogador(JogadorModelo jogadorAtualizado)
        {
            var jogador = listaJogadores.Find(x => x.Id == jogadorAtualizado.Id);
            listaJogadores[listaJogadores.IndexOf(jogador)] = jogadorAtualizado;
        }

        public void CriarJogador(JogadorModelo jogador)
        {
            listaJogadores.Add(jogador);
        }

        public void DeletarJogador(long id)
        {
           var jogador = listaJogadores.FirstOrDefault(x => x.Id == id);
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
