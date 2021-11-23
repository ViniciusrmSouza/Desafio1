using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio1.Models;
using System.Net;

namespace Desafio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly TodoContext _context;

        public ProdutosController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }

            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> GetProdutos(Guid id)
        {
            var produtos = await _context.Produtos.FindAsync(id);

            if (produtos == null)
            {
                return NotFound();
            }else if (!ModelState.IsValid)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }

            return produtos;
        }

        [HttpPost]
        public async Task<ActionResult> PostProdutos([FromBody]Produtos produtos)
        {         
            if (!ModelState.IsValid)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
            try
            {
                var result = _context.Produtos.Add(produtos);
                await _context.SaveChangesAsync();

                if (result != null)
                {
                    return Content("Produto Cadastrado");
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
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produtos>> DeleteProdutos(Guid id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }

            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();

            return Content("Produto excluído com sucesso");
        }
    }
}
