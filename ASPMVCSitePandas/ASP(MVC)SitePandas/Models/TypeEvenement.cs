using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Table("TypeEvenement")]
    public partial class TypeEvenement
    {
        public TypeEvenement()
        {
            Evenements = new HashSet<Evenement>();
        }

        [Key]
        public int Id { get; set; }
        [Column("TypeEvenement")]
        [StringLength(20)]
        [Unicode(false)]
        public string? TypeEvenement1 { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<Evenement>? Evenements { get; set; }
    }
}
