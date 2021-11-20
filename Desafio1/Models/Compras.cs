using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Desafio1.Models
{
    public class Compras
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public int QntComprada { get; set; }

       // public Cartao Cartao { get; set; }
    }
}
