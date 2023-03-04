using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_SitePandas.Models
{
    public class DocumentsViewModel
    {
        public int DocId { get; set; }
        public string DocNom { get; set; }

        [Required(ErrorMessage = "Choisissez un document..")]
        public IFormFile DocFile { get; set; } = null!;
    }
}