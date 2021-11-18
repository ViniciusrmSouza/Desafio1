using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio1.Models
{
    public class Cartao
    {
        public string Titular { get; set; }
        public int numero { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string Bandeira { get; set; }
        public int Cvv { get; set; }
    }
}
