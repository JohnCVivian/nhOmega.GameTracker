using System;
using System.Collections.Generic;
using System.Text;

namespace nhOmega.GameTracker.Core.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int State { get; set; }

        public GameImage Image { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
