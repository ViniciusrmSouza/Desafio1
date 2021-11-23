using System;
using System.ComponentModel.DataAnnotations;
namespace Desafio1.Models
{
    public class Produtos
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Coloque um nome")]
        [StringLength(160)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Defina um valor")]
        public double Valor_Unitario { get; set; }

        [Required(ErrorMessage = "Defina uma quantidade")]
        public int Qtde_Estoque { get; set; }

        public DateTime DataUltimaVenda { get; set; }
        public double ValUltimaVenda { get; set; }
    }
}
