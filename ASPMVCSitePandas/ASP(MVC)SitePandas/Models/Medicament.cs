using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_SitePandas.Models
{
    public partial class Medicament
    {
        public Medicament()
        {
            MedicamentTransitions = new HashSet<MedicamentTransition>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string Nom { get; set; } = null!;
        [StringLength(2000)]
        [Unicode(false)]
        public string Description { get; set; } = null!;

        [InverseProperty("MedicamentsEnfants")]
        public virtual ICollection<MedicamentTransition> MedicamentTransitions { get; set; }
    }
}
