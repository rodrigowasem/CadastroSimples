using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSimples
{
    public class Menu
    {
        public static void ExibeMenuPrincipal() {
            string[] opcoes = {
                "\n[ 1 ] CADASTRAR UMA PESSOA",
                "[ 2 ] EDITAR DADOS DE UMA PESSOA",
                "[ 3 ] EXIBIR TODOS OS DADOS DE TODAS AS PESSOAS CADASTRADAS",
                "[ 4 ] EXIBIR APENAS O ID E NOME DAS PESSOAS CADASTRADAS",
                "[ 5 ] REMOVER UMA PESSOA",
                "[ 6 ] SAIR\n"
            };

            foreach (string opcao in opcoes)
            {
                Console.WriteLine(opcao);
            }
        }
    }
}
