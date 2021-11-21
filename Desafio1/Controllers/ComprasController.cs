using Desafio1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Desafio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly TodoContext _context;

        public ComprasController(TodoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Comprar([FromBody] Compras compra)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = _context.Produtos.FindAsync(compra.IdProduto);
                var p = result.Result;
                p.Quantidade -= compra.QntComprada;
                p.DataUltimaVenda = DateTime.Now;
                p.ValUltimaVenda = p.ValorUnitario * compra.QntComprada;
                await _context.SaveChangesAsync();

                if (!ModelState.IsValid)
                {
                    return BadRequest("Ocorreu um erro desconhecido");
                }

                if (result != null)
                {
                    return Content("Venda realizada com sucesso");
                }
                else
                {
                    return BadRequest("Ocorreu um erro desconhecido");
                }
            }
            catch (FormatException)
            {
                return Content("Os valores informados não são válidos");
            }
        }
    }
}
