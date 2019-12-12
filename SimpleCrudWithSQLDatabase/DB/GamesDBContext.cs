using Microsoft.EntityFrameworkCore;
using SimpleCrudWithSQLDatabase.Models;

namespace SimpleCrudWithSQLDatabase.DB {
    public class GamesDBContext : DbContext {
        public GamesDBContext (DbContextOptions<GamesDBContext> options) : base (options) { }
        public DbSet<Game> Games { get; set; }
    }
}