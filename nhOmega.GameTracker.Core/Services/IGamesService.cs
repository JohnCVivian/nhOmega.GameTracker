using nhOmega.GameTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nhOmega.GameTracker.Core.Services
{
    public interface IGamesService
    {
        Task<List<Game>> GetAll();

        Task<Game> Get(int id);

        Task Create(Game game);

        Task Update(Game game);

        Task Delete(int id);
    }
}
