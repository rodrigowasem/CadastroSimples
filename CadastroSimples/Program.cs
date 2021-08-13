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
            int idPessoa = 1;
            int apcaoMenuPrincipal = 0;

            do
            {
                Menu.ExibeMenuPrincipal();
                while (!int.TryParse(Console.ReadLine(), out apcaoMenuPrincipal))
                {
                    Console.WriteLine("\nOpção inválida!");
                    Menu.ExibeMenuPrincipal();
                }

                switch (apcaoMenuPrincipal)
                {
                    case 1:
                        Console.Write("\nInforme a quantidade de pessoas: ");
                        int qtdPessoas = int.Parse(Console.ReadLine());                        

                        for (int i = 0; i < qtdPessoas; i++)
                        {
                            Pessoa pessoa = new Pessoa();
                            pessoa.CadastraPessoa(idPessoa++);
                            pessoas.Add(pessoa);
                        }

                        break;
                    case 2:
                        Console.Write("\nInforme o id da pessoa: ");
                        Pessoa pessoaEdit = pessoas.FirstOrDefault(x => x.Id == int.Parse(Console.ReadLine()));
                        // Exibe os dados da pessoa antes da edição, para que o usuário que esteja alterando os dados saiba o valor atual dos atributos
                        Pessoa.PrintPessoa(pessoaEdit);
                        Pessoa.EditarPessoa(pessoaEdit);
                        Pessoa.PrintPessoa(pessoaEdit);
                        break;
                    case 3:
                        Pessoa.ExibePessoas(pessoas, true);
                        break;
                    case 4:
                        Pessoa.ExibePessoas(pessoas, false);
                        break;
                    case 5:
                        Console.Write("\nInforme o id da pessoa: ");
                        int idRemover = int.Parse(Console.ReadLine());
                        var itemParaRemover = pessoas.SingleOrDefault(r => r.Id == idRemover);
                        if (itemParaRemover != null)
                            pessoas.Remove(itemParaRemover);
                        else
                        {
                            Console.WriteLine("\nO ID não existe na lista!");
                            return;
                        }                           
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }

            } while (apcaoMenuPrincipal != 6);
        }
    }
}
