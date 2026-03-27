namespace BarbeariaApi.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime Datahora { get; set; }
        public ClienteModel? Cliente { get; set; }
        public int ClienteId { get; set; }

        public ServiceModel? Servico { get; set; }
        public int ServiceId { get; set; }
    }
}
