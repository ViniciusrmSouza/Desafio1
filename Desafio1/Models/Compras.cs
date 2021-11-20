using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Desafio1.Models
{
    public class Compras
    {
        public Cartao Cartao { get; set; }
        public Guid IdProduto { get; set; }
        public int QntComprada { get; set; }

       
    }
}
