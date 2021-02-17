﻿using nhOmega.GameTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nhOmega.GameTracker.Core.Repositories
{
    public interface IGamesRepository
    {
        Task Create(Game gameImage);

        Task<Game> Get(int id);

        Task Delete(int id);
    }
}