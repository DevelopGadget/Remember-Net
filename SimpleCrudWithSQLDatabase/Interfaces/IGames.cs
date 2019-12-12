using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCrudWithSQLDatabase.Models;

namespace SimpleCrudWithSQLDatabase.Interfaces {
    public interface IGames {
        Task<List<Game>> Get ();
        Task<Game> Get (int Id);
        Task<Game> Post (Game game);
        Task<Game> Put (int Id, Game game);
        Task<Game> Delete (int Id);
    }
}