namespace CRUD
{
    public partial class FormularioCadastro : Form
    {
        private List<JogadorModelo> Jogadores;
        private JogadorModelo JogadorParaAtualizar;
        private static JogadorModelo NovoJogador;

        public FormularioCadastro(List<JogadorModelo> lista, JogadorModelo? jogador = null)
        {
            InitializeComponent();
            if (jogador != null) PreencherFormulario(jogador);
            CarregarEnums();
            Jogadores = lista;
            JogadorParaAtualizar = jogador;
        }
        private void CriarJogador()
        {
            var jogador = ObterDadosDoFormulario();
            try
            {
                Servicos.ValidaCriacaoJogadorModelo(jogador);

                NovoJogador = jogador;
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
            jogadorAtualizado.Id = JogadorParaAtualizar.Id;
            jogadorAtualizado.DataCriacao = JogadorParaAtualizar.DataCriacao;

            Jogadores[Jogadores.IndexOf(JogadorParaAtualizar)] = jogadorAtualizado;
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
        private void AoClicarCadastrar(object sender, EventArgs e)
        {
            try
            {
                if (JogadorParaAtualizar == null)
                {
                    CriarJogador();
                }
                else
                {
                    AtualizaJogador(JogadorParaAtualizar);
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
        public static JogadorModelo PegarJogadorCriado( )
        {
            return NovoJogador;
        }

    }
}
