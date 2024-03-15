namespace abilit_test_api.Models.Entities
{
    public class DependentesTB
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public int GeneroID { get; set; }
        public int FuncionarioID { get; set;}
    }
}