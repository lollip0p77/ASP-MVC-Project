using System;
using System.Collections.Generic;

namespace ASP_MVC_SitePandas.Models
{
    public class EventListe
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
    }
}
