using Microsoft.EntityFrameworkCore;
using SGT.Models;

namespace SGT.Data;

public class SGTContext : DbContext
{
    public SGTContext(DbContextOptions<SGTContext> options)
          : base(options)
    { }

    public DbSet<Veiculo> Veiculos { get; set; }
}
