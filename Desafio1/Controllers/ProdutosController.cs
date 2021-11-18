﻿using System;
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

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> GetProdutos(Guid id)
        {
            var produtos = await _context.Produtos.FindAsync(id);

            if (produtos == null)
            {
                return NotFound();
            }

            return produtos;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutos(Guid id, Produtos produtos)
        {
            if (id != produtos.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return CreatedAtAction(nameof(GetProdutos), new { id = produtos.Id }, produtos);
        }

        // POST: api/Produtos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostProdutos([FromBody]Produtos produtos)
        {         
            //return CreatedAtAction(nameof(GetProdutos), new { id = produtos.Id }, produtos);//Alterar
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produtos>> DeleteProdutos(Guid id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();

            return produtos;
        }

        private bool ProdutosExists(Guid id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
