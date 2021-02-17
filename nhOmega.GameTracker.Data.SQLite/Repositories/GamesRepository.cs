using nhOmega.GameTracker.Core.Models;
using nhOmega.GameTracker.Core.Repositories;
using nhOmega.GameTracker.Data.SQLite.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nhOmega.GameTracker.Data.SQLite.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly SqLiteContext _context;
        private SqLiteContext Context => _context;

        public GamesRepository(SqLiteContext context)
        {
            _context = context;
        }

        public async Task<Game> Get(int id)
        {
            var entity = await Context.Games.FindAsync(id);

            return entity.ToModel();
        }

        public Task<List<Game>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Create(Game game)
        {
            var entity = game.ToDBModel();

            Context.Games.Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(Game game)
        {
            var entity = await Context.Games.FindAsync(game.Id);
            if (entity is null)
            {
                throw new ArgumentOutOfRangeException("id", $"The id {game.Id} is not found in the Database");
            }

            entity.UpdateFrom(game);
            entity.Date = DateTime.UtcNow;
            Context.Games.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Context.Games.FindAsync(id);
            if (entity is null)
            {
                throw new ArgumentOutOfRangeException("id", $"The id {id} is not found in the Database");
            }

            Context.Games.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
