namespace abilit_test_api.Models
{
    public class ExibeFuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public double Salario { get; set; }
        public int GeneroID { get; set; }
        public string NomeGenero { get; set; }
        public List<string> NomesDependentes { get; set; }
    }
}
