namespace abilit_test_api.Models.Entities
{
    public class FuncionarioTB
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public double Salario { get; set; }
        public int GeneroID { get; set; }

    }
}