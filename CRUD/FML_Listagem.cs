using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FML_Listagem : Form
    {
        public static List<JogadorModelo> Jogadores = new();



        public FML_Listagem()
        {
            InitializeComponent();
            FML_Listagem_Load();
        }




        private void AoClicarNovo(object sender, EventArgs e)
        {
            var F_Cadastro = new FML_Cadastro();


            if (F_Cadastro.ShowDialog() == DialogResult.OK)
            {
                FML_Listagem_Load();

            }



        }



        private void FML_Listagem_Load()
        {

            GRD_GridList.DataSource = Jogadores.ToList();

        }




    }
}
