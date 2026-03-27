using BarbeariaApi.Data;
using BarbeariaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AgendamentoController(AppDbContext context)
        {
            _context = context;
        }

       
       

            [HttpGet]
            public ActionResult<List<AgendamentoModel>> BuscarAgendamentos()
            {
                // O ".Include" faz o "JOIN" no banco de dados
                var agendamentos = _context.Agendamentos
                    .Include(a => a.Cliente) // Traz os dados do Cliente junto
                    .Include(a => a.Service) // Traz os dados do Serviço junto
                    .ToList();

                return Ok(agendamentos);
            }
       

        [HttpGet("{id}")]
        public ActionResult<AgendamentoModel> BuscarAgendaPorId(int id)
        {
            var agenda = _context.Agendamentos.Find(id);

            if (agenda == null)
            {
                return NotFound("Registro não localizado");
            }

            return Ok(agenda);
        }

        [HttpPost]
        public ActionResult<AgendamentoModel> CriarAgendamentos(AgendamentoModel novoAgendamento)
        {
            //1 - quero verificar se o cliente ou o agendamento existem no banco

            var clienteExiste = _context.Clientes.Any(c => c.Id == novoAgendamento.ClienteId);
            var servicoExiste = _context.Servicos.Any(s => s.Id == novoAgendamento.ServiceId);

            if (!clienteExiste || !servicoExiste)
            {
                return BadRequest("Cliente ou serviço inválido.");
            }


            //2 - verificar se já existe agendamento nesse horário
            var horarioOcupado = _context.Agendamentos.Any(a => a.Datahora == novoAgendamento.Datahora);
            if(horarioOcupado)
            {
                return BadRequest("Este horário já está reservado por outro cliente");
            }

            _context.Agendamentos.Add(novoAgendamento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarAgendaPorId), new { id = novoAgendamento });
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<ClienteModel> EditarClientes(ClienteModel novoCliente, int id)
        {
            var clienteEditar = _context.Clientes.Find(id);

            if (clienteEditar == null)
            {
                return NotFound("Registro não localizado");
            }

            clienteEditar.Nome = novoCliente.Nome;
            clienteEditar.Telefone = novoCliente.Telefone;
            clienteEditar.Email = novoCliente.Email;

            _context.Clientes.Update(clienteEditar);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ClienteModel> ExcluirCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound("Registro não localizado");
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok("Cliente removido com sucesso.");
        }

    }
}

