using System.ComponentModel.DataAnnotations;
using WebApplication_f.Enums;
using WebApplication_f.ViewModels;

namespace WebApplication_f.Models
{
    public class Todo
    {
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State Statut { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
