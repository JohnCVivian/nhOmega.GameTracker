using System;
using System.Collections.Generic;
using System.Text;
using App = nhOmega.GameTracker.Core.Models;

namespace nhOmega.GameTracker.Data.SQLite.Models.Extensions
{
    internal static class GameImageExtensions
    {
        internal static GameImage ToDBModel(this App.GameImage gameImage)
        {
            return new GameImage
            {
                Id = gameImage.Id,
                Location = gameImage.Location,
                Content = gameImage.Content
            };
        }

        internal static App.GameImage ToModel(this GameImage gameImage)
        {
            return new App.GameImage
            {
                Id = gameImage.Id,
                Location = gameImage.Location,
                Content = gameImage.Content
            };
        }
    }
}
