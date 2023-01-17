using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class DBContext: DbContext
    {
        public DbSet<BookModel> Books { get; set; }
        public DbSet<CartModel> Carts { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            dbContextOptions.UseSqlServer(cs);
        }
    }
}
