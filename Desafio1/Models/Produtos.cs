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
        public double ValorUnitario { get; set; }

        [Required(ErrorMessage = "Defina uma quantidade")]
        public int Quantidade { get; set; }
    }
}
