namespace BarbeariaApi.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime Datahora { get; set; }
        public int ClienteId { get; set; }
        public int ServiceId { get; set; }
    }
}
