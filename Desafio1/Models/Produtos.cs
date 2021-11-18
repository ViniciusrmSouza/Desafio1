using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio1.Models
{
    public class Produtos
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
