using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCrudWithContextDatabase.Models;

namespace SimpleCrudWithContextDatabase.DB {
    public class MovieDbContext : DbContext {
        public MovieDbContext (DbContextOptions<MovieDbContext> options) : base (options) { }
        public DbSet<Movie> Movies { get; set; }

        public async Task<List<Movie>> get () => await this.Movies.ToListAsync ();
        public async Task<Movie> get (string Id) => await this.Movies.FirstOrDefaultAsync (movie => movie.Id == Id);

        public async Task<Movie> post (Movie movie) {
            await this.Movies.AddAsync (movie);
            await this.SaveChangesAsync();
            return await this.Movies.LastAsync ();
        }

        public async Task<Movie> put (string Id, Movie movie) {
            Movie getMovie = await this.get (Id);
            if (getMovie != null) {
                this.Movies.Attach (getMovie).CurrentValues.SetValues (movie);
                await this.SaveChangesAsync();
                return movie;
            }
            return getMovie;
        }

        public async Task<Movie> delete (string Id) {
            Movie getMovie = await this.get (Id);
            if (getMovie != null) {
                this.Movies.Remove(getMovie);
                await this.SaveChangesAsync();
                return getMovie;
            }
            return getMovie;
        }
    }
}