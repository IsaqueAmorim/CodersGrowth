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

namespace CRUD
{
    public partial class FML_Cadastro : Form
    {
        private List<JogadorModelo> Jogadores;
        private JogadorModelo? Jogador;
       
        public FML_Cadastro(List<JogadorModelo> lista)
        {
            InitializeComponent();
            CarregarEnums();
            Jogadores = lista;

        }
        public FML_Cadastro(JogadorModelo jogador)
        {
            InitializeComponent();
            TXB_Nome.Text =  jogador.Nome;
            TXB_Sobrenome.Text = jogador.Sobrenome;
            TXB_Apelido.Text = jogador.Apelido;
            TXB_Email.Text = jogador.Email;
            CBX_Elo.Text = jogador.Elo.ToString();
            DTM_DataNascimento.Value = jogador.DataNascimento;
            Jogador = jogador;

  
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
            var date = DTM_DataNascimento.Value;
            
           
                var jogador = new JogadorModelo
                {

                    Nome = TXB_Nome.Text,
                    Sobrenome = TXB_Sobrenome.Text,
                    Apelido = TXB_Apelido.Text,
                    Email = TXB_Email.Text,
                    Elo = Servicos.StringParaElo(CBX_Elo.Text),
                    DataNascimento = new DateTime(date.Year, date.Month, date.Day)
                };
            if(Jogador == null) 
            {
                try
                {
                    Servicos.Validacao(jogador);
                    Jogadores.Add(jogador);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                try 
                { 
                    Jogador.Nome = jogador.Nome;
                    Jogador.Sobrenome = jogador.Sobrenome;
                    Jogador.Apelido = jogador.Apelido;
                    Jogador.Email = jogador.Email;
                    Jogador.Elo = jogador.Elo;
                    Jogador.DataNascimento = jogador.DataNascimento;
                    Servicos.Validacao(jogador);
                    Jogador = null;
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
                

        }


    }
}
