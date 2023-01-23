using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Table("Garderie")]
    public partial class Garderie
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [StringLength(255)]
        public string Adresse { get; set; } = null!;
        [StringLength(100)]
        public string Ville { get; set; } = null!;
        [StringLength(7)]
        [Unicode(false)]
        public string CodePostal { get; set; } = null!;
        [StringLength(14)]
        public string Telephone { get; set; } = null!;
        [StringLength(4000)]
        [Unicode(false)]
        public string? Description { get; set; }
    }
}
