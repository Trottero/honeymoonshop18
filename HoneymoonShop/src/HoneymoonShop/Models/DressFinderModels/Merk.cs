﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Merk")]
    public class Merk
    {
        public int MerkID { get; set; }

        [Required]
        public string MerkNaam { get; set; }

        public IList<Jurk> Jurken { get; set; }
    }
}