namespace BarbeariaApi.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string NomeCorte { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int DuracaoMinutos { get; set; }
    }
}
