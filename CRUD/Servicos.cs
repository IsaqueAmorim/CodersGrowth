using System.Text.RegularExpressions;

namespace CRUD
{
    public class Servicos
    {
        private static List<JogadorModelo> Jogadores;

        public Servicos(List<JogadorModelo> jogadores)
        {
            Jogadores = jogadores;
        }
        public static bool ValidaCriacaoJogadorModelo(JogadorModelo jogador)
        {
            if (ValidaString(jogador.Nome) == false)
            {
                throw new Exception("ERR: O Campo Nome não pode ser vazio ou conter espaços.");
               
            }else if (ValidaDataNascimento(jogador.DataCriacao,jogador.DataNascimento) == false) {

                throw new Exception("ERR: A Data de nascimento não pode ser maior ou igual a data de hoje. ");
            }else if (ValidaEmail(jogador.Email) == false)
            {
                throw new Exception("ERR: Email inválido.");
            }else if (ValidaString(jogador.Apelido) == false)
            {
                throw new Exception("O Campo Apelido não pode ser vazio ou conter espaços.");
            }else if (ValidaId(jogador.Id) == false)
            {
                throw new Exception("Um Id não pode ser repetido.");
            }else if (ValidaApelido(jogador.Apelido) == false)
            {
                throw new Exception("Já exite um jogador com esse apelido.");
            }
            return true;
        }

        private static bool ValidaString(string data)
        {
            if(data.Length == 0) return false;
            if (data.Contains(" ")) return false;

            return true;

        }

        private static bool ValidaDataNascimento(DateTime criacao,DateTime nascimento)
        {
            if (criacao <= nascimento)
            {
                return false;
            }
            return true;
        }

        public static bool ValidaEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (rg.IsMatch(email)){
                if(Jogadores.Exists(X => X.Email == email))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static Elo StringParaElo(string elo)
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

        private static bool ValidaId(long id)
        {
            if(Jogadores.Exists(x => x.Id == id))
            {
                return false;
            }

            JogadorModelo.Count++;
            return true;
        }

        private static bool ValidaApelido(string apelido)
        {
            if (apelido != null && apelido.Length >= 1)
            {
               if(Jogadores.Exists(x => x.Apelido == apelido)) return false;
            }
            return true;
        }

        public static void ValidaQuantidadeDeLinhasSelecionadas(int numeroDeLinhas)
        {
            if (numeroDeLinhas == 0)
            {
                throw new Exception("ERR: Você deve selecionar uma linha para editar!");
            }
            else if (numeroDeLinhas > 1)
            {
                throw new Exception("ERR: Você deve selecionar apenas um linha para editar");
            }
        }

        public static string ValidaUnicidadeEmail(JogadorModelo jogador, string email)
        {
            if(jogador.Email != email)
            {
                if (ValidaEmail(email))
                {
                    return email;
                }
                else
                {
                    MessageBox.Show("ERR: Este endereço de e-mail já existe");
                    return jogador.Email;
                }
            }
            else
            {
                return jogador.Email;
            }
        }
        public static string ValidaUnicidadeApelido(JogadorModelo jogador, string apelido)
        {
            if (jogador.Apelido != apelido)
            {
                if (ValidaApelido(apelido))
                {
                    return apelido;
                }
                else
                {
                    MessageBox.Show("ERR: Este apelido já existe");
                    return jogador.Apelido;
                }
            }
            else
            {
                return jogador.Apelido;
            }
        }
    }
}
