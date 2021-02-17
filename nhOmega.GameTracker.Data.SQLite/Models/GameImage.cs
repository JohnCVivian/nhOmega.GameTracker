using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace nhOmega.GameTracker.Data.SQLite.Models
{
    internal class GameImage
    {
        [Key]
        public int Id { get; set; }

        public string Location { get; set; }

        [Column(TypeName = "blob")]
        public byte[] Content { get; set; }
    }
}
