using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APIAssignment1.EFCore
{
    public class EF_DataContext:DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
