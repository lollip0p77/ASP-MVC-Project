using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    public partial class Allergy
    {
        public Allergy()
        {
            AllergiesEnfants = new HashSet<AllergiesEnfant>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Nom { get; set; } = null!;

        [InverseProperty("Allergie")]
        public virtual ICollection<AllergiesEnfant> AllergiesEnfants { get; set; }
    }
}
