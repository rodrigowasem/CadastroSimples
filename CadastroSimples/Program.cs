using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroSimples
{
    class Program
    {       
        
        static void Main(string[] args)
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            int apcaoMenuPrincipal = 0;
            SistemaCadastro sistemaCadastro = new SistemaCadastro();

            do
            {
                apcaoMenuPrincipal = Menu.ExibeMenuPrincipal();
                
                switch (apcaoMenuPrincipal)
                {
                    case Menu.CadastrarPessoa:
                        Console.Write("\nInforme a quantidade de pessoas: ");
                        int qtdPessoas = int.Parse(Console.ReadLine());                        

                        for (int i = 0; i < qtdPessoas; i++)
                        {
                            sistemaCadastro.CadastraPessoa(sistemaCadastro.Pessoas.OrderByDescending(p => p.Id).First().Id);
                        }

                        break;
                    case 2:
                        Console.Write("\nInforme o id da pessoa: ");
                        sistemaCadastro.EditarPessoa(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        sistemaCadastro.ExibePessoas(true);
                        break;
                    case 4:
                        sistemaCadastro.ExibePessoas(false);
                        break;
                    case 5:
                        Console.Write("\nInforme o id da pessoa: ");
                        sistemaCadastro.RemoverPessoa(int.Parse(Console.ReadLine()));
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }

            } while (apcaoMenuPrincipal != 6);
        }
    }
}
