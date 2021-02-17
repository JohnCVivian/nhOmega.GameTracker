using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace nhOmega.GameTracker.Data.SQLite.Models
{
    public class GameImage
    {
        [Key]
        public int Id { get; set; }

        public string Location { get; set; }

        public byte[] Content { get; set; }
    }
}
