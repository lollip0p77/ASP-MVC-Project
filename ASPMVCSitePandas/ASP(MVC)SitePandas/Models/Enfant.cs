using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    public partial class Enfant
    {
        public Enfant()
        {
            AllergiesEnfants = new HashSet<AllergiesEnfant>();
            MedicamentTransitions = new HashSet<MedicamentTransition>();
            Presences = new HashSet<Presence>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = null!;
        [StringLength(50)]
        public string Prenom { get; set; } = null!;
        [StringLength(1)]
        [Unicode(false)]
        public string Sexe { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateDeNaissance { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateInscription { get; set; }
        [StringLength(150)]
        public string? ProblemeSante { get; set; }
        [StringLength(450)]
        public string? ProblemeComportement { get; set; }
        [StringLength(2000)]
        [Unicode(false)]
        public string? InformationSupplementaire { get; set; }
        [Column("RepondantID")]
        public int RepondantId { get; set; }

        [ForeignKey("RepondantId")]
        [InverseProperty("Enfants")]
        public virtual Repondant Repondant { get; set; } = null!;
        [InverseProperty("IdNavigation")]
        public virtual PersonnesAutoriser? PersonnesAutoriser { get; set; }
        [InverseProperty("Enfant")]
        public virtual ICollection<AllergiesEnfant> AllergiesEnfants { get; set; }
        [InverseProperty("Enfant")]
        public virtual ICollection<MedicamentTransition> MedicamentTransitions { get; set; }
        [InverseProperty("Enfant")]
        public virtual ICollection<Presence> Presences { get; set; }
    }
}
