using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Desafio1.Models
{
    public class Compras
    {
        public Guid Produto_Id { get; set; }
        public int Qtde_Comprada { get; set; }
        public Cartao Cartao { get; set; }
       
  

       
    }
}
