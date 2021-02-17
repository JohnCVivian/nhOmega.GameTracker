using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace nhOmega.GameTracker.Data.SQLite.Models
{
    internal class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int State { get; set; }

        public int ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual GameImage Image { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }
    }
}
