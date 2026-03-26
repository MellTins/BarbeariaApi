using BarbeariaApi.Data;
using BarbeariaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    } //https://www.youtube.com/watch?v=iqLVQoK4BKE   39:09

}
