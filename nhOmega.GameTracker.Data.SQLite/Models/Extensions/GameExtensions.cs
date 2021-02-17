using System;
using App = nhOmega.GameTracker.Core.Models;
using System.Collections.Generic;
using System.Text;

namespace nhOmega.GameTracker.Data.SQLite.Models.Extensions
{
    internal static class GameExtensions
    {
        internal static Game ToDBModel(this App.Game game)
        {
            return new Game
            {
                Id = game.Id,
                Name = game.Name,
                ImageId = game.Image?.Id ?? 1,
                State = game.State,
                Comment = game.Comment,
                Date = game.Date
            };
        }

        internal static App.Game ToModel(this Game game)
        {
            return new App.Game
            {
                Id = game.Id,
                Name = game.Name,
                Image = game.Image?.ToModel() ?? new App.GameImage { Id = game.ImageId},
                State = game.State,
                Comment = game.Comment,
                Date = game.Date
            };
        }

        internal static void UpdateFrom(this Game dbGame, App.Game game)
        {
            var mapedGame = game.ToDBModel();

            if (dbGame.Name != mapedGame.Name)
            {
                dbGame.Name = mapedGame.Name;
            }

            if (dbGame.ImageId != mapedGame.ImageId)
            {
                dbGame.ImageId = mapedGame.ImageId;
            }

            if (dbGame.State != mapedGame.State)
            {
                dbGame.State = mapedGame.State;
            }

            if (dbGame.Comment != mapedGame.Comment)
            {
                dbGame.Comment = mapedGame.Comment;
            }
        }
    }
}
