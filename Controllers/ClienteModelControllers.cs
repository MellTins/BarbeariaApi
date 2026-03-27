using BarbeariaApi.Data;
using BarbeariaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BarbeariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteModelControllers : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClienteModelControllers(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ClienteModel>> BuscarClientes()
        {
            var clientes = _context.Clientes.ToList();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteModel>BuscarClientesPorId(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if(cliente == null)
            {
                return NotFound("Registro não localizado");
            }

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<ClienteModel> CriarClientes(ClienteModel novoCliente)
        {
            if (novoCliente == null)
            {

                return BadRequest("Ocorreu um erro na solicitação!");
            }

            _context.Clientes.Add(novoCliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarClientesPorId), new { id = novoCliente.Id }, novoCliente);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<ClienteModel> EditarClientes(ClienteModel novoCliente , int id)
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
