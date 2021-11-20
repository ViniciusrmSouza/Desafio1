using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Desafio1.Models
{
    public class Compras
    {
        [Key]
        public Guid Id { get; set; }

        private readonly TodoContext _context;
        public int QntComprada { get; set; }
        public Produtos Produto { get; set; }
        //public Cartao Cartao { get; set; }

        public async Task ComprarAsync(Guid id)
        {
            Produto = await _context.Produtos.FindAsync(id);
            Produto.Quantidade -= QntComprada;
        }

    }
}
