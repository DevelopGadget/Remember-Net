using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCrudWithSQLDatabase.Interfaces;
using SimpleCrudWithSQLDatabase.Models;

namespace SimpleCrudWithSQLDatabase.DB {
    public class GamesDBContext : DbContext, IGames {
        public GamesDBContext (DbContextOptions<GamesDBContext> options) : base (options) { }
        public DbSet<Game> Games { get; set; }

        public async Task<Game> Delete (int Id) {
            var gameFind = await this.Get (Id);
            if (gameFind != null) {
                this.Games.Remove (gameFind);
                await this.SaveChangesAsync ();
                return gameFind;
            }
            return gameFind;
        }

        public async Task<List<Game>> Get() => await this.Games.ToListAsync();

        public async Task<Game> Post (Game game) {
            await this.Games.AddAsync (game);
            await this.SaveChangesAsync ();
            return game;
        }

        public async Task<Game> Put (int Id, Game game) {
            var gameFind = await this.Get (Id);
            if (gameFind != null) {
                gameFind.Gender = game.Gender;
                gameFind.Name = game.Name;
                gameFind.Platoforms = game.Platoforms;
                await this.SaveChangesAsync ();
                return gameFind;
            }
            return gameFind;
        }

        public async Task<Game> Get(int Id) => await this.Games.FirstOrDefaultAsync(game => game.GameId == Id);
    }
}