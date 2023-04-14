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
        public FML_Cadastro()
        {
            InitializeComponent();
            CarregarEnums();
        }

        private void CarregarEnums()
        {
            CBX_Elo.DataSource = Enum.GetValues(typeof(Elo));
        }
   




        private void AoClicarCancelar(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BTN_Cadastrar_Click(object sender, EventArgs e)
        {
            var date = DTM_DataNascimento.Value;
            var jogador = new JogadorModelo(
           
                TXB_Nome.Text,
                TXB_Sobrenome.Text,
                TXB_Apelido.Text,
                TXB_Email.Text,
                Servicos.StringParaElo(CBX_Elo.Text),
                new DateTime(date.Year, date.Month, date.Day));

            try
            {
                Servicos.Validacao(jogador);
                FML_Listagem.Jogadores.Add(jogador);
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
