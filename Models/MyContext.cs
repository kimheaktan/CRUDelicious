using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options): base(options) { }

    //Entity Framework will use this property name to name the table
        public DbSet<Dish> Dishes {get;set;}
    }
}