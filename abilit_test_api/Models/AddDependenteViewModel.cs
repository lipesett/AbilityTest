using abilit_test_api.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace abilit_test_api.Models
{
    public class AddDependenteViewModel
    {
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public int GeneroID { get; set; }
        public int FuncionarioID { get; set; }
    }
}