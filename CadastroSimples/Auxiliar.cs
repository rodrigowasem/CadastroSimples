using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CadastroSimples
{
    class Auxiliar
    {

        // Classe auxiliar para fins de validações e fromataçaões de telefone e cpf

        public static bool ValidaTelefone(string telefone)
        {
            char digito = '9';

            if (telefone.Length == 10)
            {
                return true;
            }
            else if (telefone.Length == 11 && telefone[2] == digito)
            {
                return true;
            }
            else
                return false;
        }

        public static bool ValidaEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match emailMatch = emailRegex.Match(email);
            return emailMatch.Success;
        }
        public static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf, digito;
            int soma, resto;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
        public static string FormataTelefone(string telefone)
        {
            string res = "";

            if (telefone.Length == 11)
            {
                res = long.Parse(telefone).ToString(@"(00) 00000-0000");
            }
            else if (telefone.Length == 10)
            {
                res = long.Parse(telefone).ToString(@"(00) 0000-0000");
            }
            return res;
        }
        public static string FormataCpf(string cpf)
        {
            string response = cpf.Trim();
            if (response.Length == 11)
            {
                response = response.Insert(9, "-");
                response = response.Insert(6, ".");
                response = response.Insert(3, ".");
            }
            return response;
        }
    }
}
