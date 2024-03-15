namespace abilit_test_api.Models
{
    public class AddFuncionarioViewModel
    {
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public double Salario { get; set; }
        public int GeneroID { get; set; }
        public string NomeGenero { get; set; }
    }
}
