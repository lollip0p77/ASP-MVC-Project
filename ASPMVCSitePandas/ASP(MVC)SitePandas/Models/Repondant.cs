using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    [Table("Repondant")]
    public partial class Repondant
    {
        public Repondant()
        {
            DocumentsParents = new HashSet<DocumentsParent>();
            Enfants = new HashSet<Enfant>();
            Messages = new HashSet<Message>();
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
        [StringLength(255)]
        public string Adresse { get; set; } = null!;
        [StringLength(100)]
        public string Ville { get; set; } = null!;
        [StringLength(7)]
        [Unicode(false)]
        public string CodePostal { get; set; } = null!;
        [StringLength(255)]
        public string Courriel { get; set; } = null!;
        [StringLength(14)]
        public string Telephone { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime CreationDeCompte { get; set; }
        [StringLength(50)]
        public string UserName { get; set; } = null!;
        [StringLength(50)]
        public string Password { get; set; } = null!;
        public bool RepondantPrincipal { get; set; }
        [StringLength(50)]
        public string Lien { get; set; } = null!;

        [InverseProperty("Repondant")]
        public virtual ICollection<DocumentsParent> DocumentsParents { get; set; }
        [InverseProperty("Repondant")]
        public virtual ICollection<Enfant> Enfants { get; set; }
        [InverseProperty("Repondant")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
