using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSimples
{
    public class Menu
    {
        // Opções possíveis 
        public const int CadastrarPessoa = 1;
        public const int EditarCadastroPessoa = 2;
        public const int ExibirTodasAsPessoas = 3;
        public const int ExibirIdNome = 4;
        public const int RemoverPessoa = 5;
        public const int Sair = 6;
        private static Dictionary<int, string> Opcoes { get; set; }

        // Construtor estático do menu
        static Menu()
        {
            Opcoes = new Dictionary<int, string>()
            {
                {CadastrarPessoa, "CADASTRAR UMA PESSOA"},
                {EditarCadastroPessoa, "EDITAR DADOS DE UMA PESSOA"},
                {ExibirTodasAsPessoas, "EXIBIR TODOS OS DADOS DE TODAS AS PESSOAS CADASTRADAS"},
                {ExibirIdNome, "EXIBIR APENAS O ID E NOME DAS PESSOAS CADASTRADAS" },
                {RemoverPessoa, "REMOVER UMA PESSOA" },
                {Sair, "SAIR" }
            };
        }

        public static int ExibeMenuPrincipal() {

            int escolha;
            do
            {
                Console.WriteLine("\nInforme qual operação deseja realizar...");
                foreach (var opcao in Opcoes)
                {
                    System.Console.WriteLine($"{opcao.Key} - {opcao.Value}");
                }

                Int32.TryParse(Console.ReadLine(), out escolha);
            } while (!Opcoes.ContainsKey(escolha));

            return escolha;
        }
    }
}
