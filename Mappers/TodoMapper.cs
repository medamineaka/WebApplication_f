using WebApplication_f.ViewModels;
using WebApplication_f.Models;

namespace WebApplication_f.Mappers
{
    public class TodoMapper
    {
        public static Todo GetTodoFromTodoAddVM(TodoAddVM vm)
        {
            return new Todo
            {
                Libelle = vm.Libelle,
                Description = vm.Description,
                DateLimite = vm.DateLimite,
                Statut = vm.Statut,
            };
        }
    }
}
