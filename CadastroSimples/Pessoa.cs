using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSimples
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int Id { get; init; }

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
    }
}
