using Microsoft.EntityFrameworkCore;



public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }


    public DbSet<Deportista> Deportistas { get; set; }
    public DbSet<Resultado> Resultados { get; set; }
}



