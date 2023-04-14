using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUD
{
    public class Servicos
    {
        public static bool Validacao(JogadorModelo jogador)
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
            }else if (ValidaId(jogador.Id))
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
        private static bool ValidaEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (rg.IsMatch(email)){
                return true;
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
            foreach(JogadorModelo jogador in FML_Listagem.Jogadores)
            {
                if(JogadorModelo.Count == id || jogador.Id == id)
                {
                    return false;
                    
                }
                else
                {
                    JogadorModelo.Count++;
                    return true;
                }
            }
                return false;
        }
        private static bool ValidaApelido(string apelido)
        {
            if (apelido != null && apelido.Length >= 1)
            {
                
                if(FML_Listagem.Jogadores.Count == 0)
                {
                    return true;
                }
                else
                {
                    foreach (JogadorModelo jogador in FML_Listagem.Jogadores)
                    {
                        if (jogador.Apelido == apelido) return false;

                    }
                }
            }
            else
            {
                return false;
            }            
            return true;      
        }
    }
}
