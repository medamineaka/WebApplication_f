using System.ComponentModel.DataAnnotations;
using System.Data;
using WebApplication_f.Enums;

namespace WebApplication_f.ViewModels
{
    public class TodoAddVM
    {
        [Required(ErrorMessage = "Le libelle est obligatoire")]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        [Required]
        public State Statut { get; set; }

    }
}
