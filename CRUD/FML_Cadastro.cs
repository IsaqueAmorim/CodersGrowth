using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUD
{
    public partial class FML_Cadastro : Form
    {
        private List<JogadorModelo> Jogadores;
        private JogadorModelo? Jogador;

        public FML_Cadastro(List<JogadorModelo> lista, JogadorModelo? jogador = null)
        {
            InitializeComponent();
            if (jogador != null) PreencherFormulario(jogador);
            CarregarEnums();
            Jogadores = lista;
            Jogador = jogador;
        }
        private void CriarJogador()
        {
            var jogador = ObterDadosDoFormulario();
            try
            {
                Servicos.ValidaCriacaoJogadorModelo(jogador);
                Jogadores.Add(jogador);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AtualizaJogador(JogadorModelo jogador)
        {
            var jogadorAtualizado = ObterDadosDoFormulario();
            jogadorAtualizado.Id = Jogador.Id;
            jogadorAtualizado.DataCriacao = Jogador.DataCriacao;

            Jogadores[Jogadores.IndexOf(Jogador)] = jogadorAtualizado;
            DialogResult = DialogResult.OK;


        }
        public void PreencherFormulario(JogadorModelo? jogador = null)
        {

            TXB_Nome.Text = jogador?.Nome;
            TXB_Sobrenome.Text = jogador?.Sobrenome;
            TXB_Apelido.Text = jogador?.Apelido;
            TXB_Email.Text = jogador?.Email;
            CBX_Elo.Text = jogador?.Elo.ToString();
            DTM_DataNascimento.Value = jogador == null ? DateTime.Now : jogador.DataNascimento;


        }
        private void CarregarEnums()
        {
            CBX_Elo.DataSource = Enum.GetValues(typeof(Elo));
        }
        private void AoClicarCancelar(object sender, EventArgs e)
        {

            this.Close();
        }
        private void BTN_Cadastrar_AoClicar(object sender, EventArgs e)
        {
            try
            {
                if (Jogador == null)
                {
                    CriarJogador();
                }
                else
                {
                    AtualizaJogador(Jogador);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private JogadorModelo ObterDadosDoFormulario()
        {
            var date = DTM_DataNascimento.Value;
            var jogador = new JogadorModelo
            {
                Nome = TXB_Nome.Text,
                Sobrenome = TXB_Sobrenome.Text,
                Apelido = TXB_Apelido.Text,
                Email = TXB_Email.Text,
                Elo = Servicos.StringParaElo(CBX_Elo.Text),
                DataNascimento = new DateTime(date.Year, date.Month, date.Day),
                DataCriacao = DateTime.Now
            };
            return jogador;
        }

    }
}
