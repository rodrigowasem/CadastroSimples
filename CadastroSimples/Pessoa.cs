using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSimples
{
    public class Pessoa
    {
        public string Nome;
        public string Cpf;
        public string Email;
        public string Telefone;
        public int Id;

        public Pessoa()
        {
            
        }
        public Pessoa(string nome, string cpf, string email, string telefone, int id)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Telefone = telefone;
            this.Id = id;
        }

        public void CadastraPessoa(int idPessoa) {

            this.Id = idPessoa;

            Console.Write("\nDigite o nome: ");
            this.Nome = Console.ReadLine();

            Console.Write("Digite o cpf: ");
            this.Cpf = Console.ReadLine();

            while (!Auxiliar.ValidaCpf(this.Cpf))
            {
                Console.WriteLine("Cpf inválido!");
                Console.Write("Digite o cpf: ");
                this.Cpf = Console.ReadLine();
            }

            Console.Write("Digite o email: ");
            this.Email = Console.ReadLine();

            while (!Auxiliar.ValidaEmail(this.Email))
            {
                Console.WriteLine("Email inválido!");
                Console.Write("Digite o email: ");
                this.Email = Console.ReadLine();
            }

            Console.Write("Digite o telefone: ");
            this.Telefone = Console.ReadLine();

            while (!Auxiliar.ValidaTelefone(this.Telefone))
            {
                Console.WriteLine("Telefone inválido!");
                Console.Write("Digite o telefone: ");
                this.Email = Console.ReadLine();
            }
        }

        public static void EditarPessoa(Pessoa pessoa)
        {
            string opcaoMenuEdicao;

            if (pessoa == null)
            {
                Console.WriteLine("Pessoa não encontrada!");
                return;
            }

            Console.Write("\nGostaria de editar o nome: S/N ");
            opcaoMenuEdicao = Console.ReadLine();

            if (opcaoMenuEdicao.ToLower() == "s")
            {
                Console.Write("Digite o nome: ");
                string nome = Console.ReadLine();
                pessoa.Nome = nome;
            }

            Console.Write("\nGostaria de editar o cpf: S/N ");
            opcaoMenuEdicao = Console.ReadLine();
            if (opcaoMenuEdicao.ToLower() == "s")
            {
                Console.Write("Digite o cpf: ");
                string cpf = Console.ReadLine();

                while (!Auxiliar.ValidaCpf(cpf))
                {
                    Console.WriteLine("Cpf inválido!");
                    Console.Write("Digite o cpf: ");
                    cpf = Console.ReadLine();
                }
                pessoa.Cpf = cpf;
            }

            Console.Write("\nGostaria de editar o email: S/N ");
            opcaoMenuEdicao = Console.ReadLine();
            if (opcaoMenuEdicao.ToLower() == "s")
            {
                Console.Write("Digite o email: ");
                string email = Console.ReadLine();

                while (!Auxiliar.ValidaEmail(email))
                {
                    Console.WriteLine("Email inválido!");
                    Console.Write("Digite o email: ");
                    email = Console.ReadLine();
                }

                pessoa.Email = email;
            }

            Console.Write("\nGostaria de editar o telefone: S/N ");
            opcaoMenuEdicao = Console.ReadLine();
            if (opcaoMenuEdicao.ToLower() == "s")
            {
                Console.Write("Digite o telefone: ");
                string telefone = Console.ReadLine();

                while (!Auxiliar.ValidaTelefone(telefone))
                {
                    Console.WriteLine("Telefone inválido!");
                    Console.Write("Digite o telefone: ");
                    telefone = Console.ReadLine();
                }
                pessoa.Telefone = telefone;
            }
        }

        public static void PrintPessoa(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                Console.WriteLine("Pessoa não encontrada!");
                return;
            }

            Console.WriteLine(
                $@"
               ID: {pessoa.Id} 
               Nome: {pessoa.Nome} 
               CPF: {Auxiliar.FormataCpf(pessoa.Cpf)}
               Email: {pessoa.Email}
               Telefone: {Auxiliar.FormataTelefone(pessoa.Telefone)}"
                    );
        }

        public static void ExibePessoas(List<Pessoa> pessoas, bool mostrarTodas)
        {
            if (pessoas.Count > 0)
            {
                Console.WriteLine("\n[ - Lista de pessoas cadastradas - ]");
                foreach (Pessoa pessoa in pessoas)
                {
                    if (mostrarTodas)
                    {
                        PrintPessoa(pessoa);
                    }
                    else
                    {
                        Console.WriteLine(
                          $@"
                ID: {pessoa.Id} 
                Nome: {pessoa.Nome}"
                        );
                    }
                }
            }
            else
                Console.WriteLine("\n[ - Não há pessoas cadastradas no momento - ]");
        }
    }
}
