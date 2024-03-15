using Microsoft.AspNetCore.Mvc.Rendering;

namespace abilit_test_api.Models
{
    public class ComposedModel
    {
        public AddDependenteViewModel AddDependenteViewModel { get; set; }
        public ExibeDependentesViewModel ExibeDependentesViewModel { get; set; }
        public List<SelectListItem> FuncionariosDisponiveis { get; set; }
    }
}
