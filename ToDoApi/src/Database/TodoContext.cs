using Microsoft.EntityFrameworkCore;
using ToDoApi.src.Database.Domain;

namespace ToDoApi.src.Database
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Todo> Tasks { get; set; }
    }
}