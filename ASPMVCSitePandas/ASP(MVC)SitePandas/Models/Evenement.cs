using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    public partial class Evenement
    {
        public Evenement()
        {
            Presences = new HashSet<Presence>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Titre { get; set; } = null!;
        [StringLength(125)]
        public string Description { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal? Cout { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [StringLength(5)]
        public string HeureDebut { get; set; } = null!;
        [StringLength(5)]
        public string HeureFin { get; set; } = null!;
        [Column("TypeID")]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        [InverseProperty("Evenements")]
        public virtual TypeEvenement Type { get; set; } = null!;
        [InverseProperty("Evenement")]
        public virtual ICollection<Presence> Presences { get; set; }
    }
}
