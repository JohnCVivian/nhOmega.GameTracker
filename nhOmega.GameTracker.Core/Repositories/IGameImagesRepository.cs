using nhOmega.GameTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nhOmega.GameTracker.Core.Repositories
{
    public interface IGameImagesRepository
    {
        Task<GameImage> Get(int id);

        Task Create(GameImage gameImage);

        Task Update(GameImage gameImage);

        Task Delete(int id);
    }
}
