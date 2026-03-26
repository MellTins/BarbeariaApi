using System.ComponentModel.DataAnnotations.Schema;

namespace BarbeariaApi.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string NomeCorte { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Preco { get; set; }
        public int DuracaoMinutos { get; set; }
    }
}
