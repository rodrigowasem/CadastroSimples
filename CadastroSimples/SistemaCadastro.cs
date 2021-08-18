using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CadastroSimples
{
    class SistemaCadastro
    {
        // Com o IReadOnlyList estamos garantindo o encapsulamento e integridade da lista de Pessoas
        private List<Pessoa> _pessoas;
        public IReadOnlyList<Pessoa> Pessoas { get => _pessoas; }

        public SistemaCadastro()
        {
            // Quando estanciamos o objeto, já são carregados alguns dados na lista de pessoas
            CarregaDados();
        }

        private void CarregaDados()
        {
            _pessoas = new List<Pessoa>{
                new Pessoa
                {
                    Nome = "Rodrigo Wasem",
                    Cpf = "01547089014",
                    Email = "igowasem@gmail.com",
                    Telefone = "51995465074",
                    Id = 1
                },
                new Pessoa
                {
                    Nome = "João",
                    Cpf = "01557089015",
                    Email = "joao@teste.com",
                    Telefone = "51985465075",
                    Id = 2
                },
                new Pessoa
                {
                    Nome = "Maria",
                    Cpf = "01597089019",
                    Email = "maria@teste.com",
                    Telefone = "51985865030",
                    Id = 3
                },

            };

        }

        public void CadastraPessoa(int idPessoa)
        {            
            Console.Write("\nDigite o nome: ");
            var nome = Console.ReadLine();

            Console.Write("Digite o cpf: ");
            var cpf = Console.ReadLine();

            while (!Auxiliar.ValidaCpf(cpf))
            {
                Console.WriteLine("Cpf inválido!");
                Console.Write("Digite o cpf: ");
                cpf = Console.ReadLine();
            }

            Console.Write("Digite o email: ");
            var email = Console.ReadLine();

            while (!Auxiliar.ValidaEmail(email))
            {
                Console.WriteLine("Email inválido!");
                Console.Write("Digite o email: ");
                email = Console.ReadLine();
            }

            Console.Write("Digite o telefone: ");
            var telefone = Console.ReadLine();

            while (!Auxiliar.ValidaTelefone(telefone))
            {
                Console.WriteLine("Telefone inválido!");
                Console.Write("Digite o telefone: ");
                telefone = Console.ReadLine();
            }

            _pessoas.Add(
                new Pessoa
                {
                    Nome = nome,
                    Cpf = cpf,
                    Email = email,
                    Telefone = telefone,
                    Id = ++idPessoa
                }
             );

            Console.WriteLine("Cadastro realizado com sucesso!");
        }

        private Pessoa ObtemAlunoPeloId(int idPessoa)
        {
            return Pessoas.FirstOrDefault(pessoa => pessoa.Id == idPessoa);
        }

        public void EditarPessoa(int idPessoa)
        {
            string opcaoMenuEdicao;
            Pessoa pessoa = ObtemAlunoPeloId(idPessoa);

            if (pessoa == null)
            {
                Console.WriteLine("\nPessoa não encontrada!");
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

            Console.WriteLine("\nEdição do cadastro, realizada com sucesso!");
        }

        public static void PrintPessoa(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                Console.WriteLine("\nPessoa não encontrada!");
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

        public void ExibePessoas(bool mostrarTodas)
        {
            if (Pessoas.Count > 0)
            {
                Console.WriteLine("\n[ - Lista de pessoas cadastradas - ]");
                foreach (Pessoa pessoa in Pessoas)
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

        public void RemoverPessoa(int idPessoa)
        {
            var pessoa = _pessoas.SingleOrDefault(r => r.Id == idPessoa);

            if (pessoa == null)
            {
                Console.WriteLine("\nPessoa não encontrada!");
                return;
            }
            else
            {
                _pessoas.Remove(pessoa);
                Console.WriteLine("\nCadastro removido com sucesso!");
            }               

        }

    }
}
