using EscolaApex.Model;
using EscolaApex.Model.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaApex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolDbContext _dbContext;
        public SchoolController(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("[action]")]
        public void CadastrarPessoa(Pessoa pessoa)
        {
           var pessoaValue =  PessoaValue.SetPessoa(pessoa);
           var idadeValida = PessoaValue.ValidarIdadePessoa(pessoaValue.Idade);
            if (!idadeValida)
                throw new Exception("Eessa idade não está dentro do range de 18 a 70 anos");
            _dbContext.Pessoas.Add(pessoaValue);
            _dbContext.SaveChanges();
        }
        [HttpGet("[action]")]
        public IEnumerable<object> RetornarPessoas()
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSearch = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            IEnumerable<string> files = Directory.GetFiles(pathToSearch).Select(x => x.Split(".")[0].Split("Images\\")[1]);
            return _dbContext.Pessoas.Select(x => new
            {
                Nome = x.Nome,
                CPF = x.CPF,
                File = files.Contains(x.CPF)
            }) ;
        }       
        [HttpGet("[action]")]
        public IEnumerable<string> RetornarCpfs()
        {
            return _dbContext.Pessoas.Select(x => x.CPF);
        }
        [HttpDelete("[action]/{id}")]
        public void RemoverPessoa(int id)
        {
            var pessoa = _dbContext.Pessoas.Find(id);
            _dbContext.Pessoas.Remove(pessoa);
            _dbContext.SaveChanges();
        }
    }
}
