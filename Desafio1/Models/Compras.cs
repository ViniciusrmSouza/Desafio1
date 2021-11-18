using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio1.Models
{
    public class Compras
    {
        private readonly TodoContext _context;
        public Produtos Produto { get; set; }
        public Cartao Cartao { get; set; }

        public async Task ComprarAsync(Guid id, int quantidade)
        {
            Produto = await _context.Produtos.FindAsync(id);
            Produto.Quantidade -= quantidade;
        }

    }
}
