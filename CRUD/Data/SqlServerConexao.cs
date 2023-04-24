using CRUD.Modelos;
using CRUD.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Data
{
    public class SqlServerConexao:IRepositorioJogadores
    {
        private static string stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;

        SqlConnection con = new SqlConnection(stringConexao);

        public void AtualizarJogador(JogadorModelo jogadorAtualizado, JogadorModelo jogadorAtual)
        {
            
            
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
