using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaApex.Model
{
    public class PessoaValue
    {
        public static Pessoa SetPessoa(Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Nome.Trim()) || pessoa.Nome.Trim().Length > 255)
                throw new Exception("Nome vazio ou acima de 255 caracteres");
            if (pessoa.Idade.Equals(0))
                throw new Exception("Idade não informada");
            if (!pessoa.Email.Trim().Contains("@") && pessoa.Email.Trim().Length <= 4)
                throw new Exception("Email não está no formato correto");
            if (string.IsNullOrEmpty(pessoa.Endereco.Trim()))
                throw new Exception("Endereço não cadastrado");
            if (string.IsNullOrEmpty(pessoa.CPF.Trim()))
                throw new Exception("CPF não informado");
            return pessoa;
        }
        public static bool ValidarIdadePessoa(int idade) => idade >= 18 && idade < 70;        
    }
}
