using Microsoft.EntityFrameworkCore;
using ToDoApi2.Models;

namespace ToDoApi2.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; } = null!;
}
