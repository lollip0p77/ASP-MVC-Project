using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    public partial class Educatrice
    {
        public Educatrice()
        {
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
        [StringLength(450)]
        public string Adresse { get; set; } = null!;
        [StringLength(255)]
        public string Ville { get; set; } = null!;
        [StringLength(7)]
        public string CodePostal { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateDeNaissance { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateDembauche { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateDeFinDemploi { get; set; }
        [Column(TypeName = "money")]
        public decimal? Salaire { get; set; }
        [StringLength(14)]
        public string Telephone { get; set; } = null!;
        [StringLength(450)]
        public string UserId { get; set; } = null!;

        [ForeignKey("UserId")]
        [InverseProperty("Educatrices")]
        public virtual AspNetUser? User { get; set; } = null!;
        [InverseProperty("Educatrice")]
        public virtual ICollection<Message>? Messages { get; set; }
    }
}
