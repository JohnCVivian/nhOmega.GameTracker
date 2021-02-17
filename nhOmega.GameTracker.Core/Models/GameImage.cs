using System;
using System.Collections.Generic;
using System.Text;

namespace nhOmega.GameTracker.Core.Models
{
    public class GameImage
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public byte[] Content { get; set; }
    }
}
