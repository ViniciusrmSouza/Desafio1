using Microsoft.EntityFrameworkCore;
using Desafio1.Models;

namespace Desafio1.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }
        //public DbSet<Compras> Compras { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }   
    }
}
