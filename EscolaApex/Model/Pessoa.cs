using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaApex.Model
{
    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nome { get; set; }
        public int Idade { get; set; }        
        public string Endereco { get; set; }
        [MaxLength(11)]        
        public string CPF { get; set; }
        [MaxLength(400)]
        public string Email { get; set; }
    }
}
