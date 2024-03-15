using Microsoft.AspNetCore.Mvc.Rendering;

namespace abilit_test_api.Models
{
    public class ExibeDependentesViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public int GeneroID { get; set; }
        public int FuncionarioID { get; set; }
        public string NomeGenero { get; set; }
        public string NomeFuncionario { get; set; }
        public List<SelectListItem> FuncionariosDisponiveis { get; set; }
    }
}
