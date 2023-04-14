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
            LoadEnums();
        }

        private void LoadEnums()
        {
            CBX_Elo.DataSource = Enum.GetValues(typeof(Elo));
        }
        private Elo StringToElo(string elo)
        {
            Elo result;

            switch (elo)
            {
                case "Ferro":
                    result = Elo.Ferro;
                    break;
                case "Bronze":
                    result = Elo.Bronze;
                    break;
                case "Prata":
                    result = Elo.Prata;
                    break;
                case "Ouro":
                    result = Elo.Ouro;
                    break;
                case "Platina":
                    result = Elo.Platina;
                    break;
                case "Diamante":
                    result = Elo.Platina;
                    break;
                case "Mestre":
                    result = Elo.Platina;
                    break;
                case "GM":
                    result = Elo.Platina;
                    break;
                default:
                    result = Elo.Ferro;
                    break;

            }
            return result;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void FML_Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void LB_DataNascimento_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BTN_Cadastrar_Click(object sender, EventArgs e)
        {
            var date = DTM_DataNascimento.Value;
            FML_Listagem.Jogadores.Add(new JogadorModelo(
                TXB_Nome.Text,
                TXB_Sobrenome.Text,
                TXB_Apelido.Text,
                TXB_Email.Text,
                StringToElo(CBX_Elo.Text),
                new DateTime(date.Year, date.Month, date.Day)

                )) ;

            Close();






        }


    }
}
