using Microsoft.EntityFrameworkCore;

namespace Desafio1.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }
    }
}
