using BarbeariaApi.Data;
using BarbeariaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarbeariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteModelControllers1 : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClienteModelControllers1(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ClienteModel>> BuscarClientes()
        {
            var clientes = _context.Clientes.ToList();
            return Ok(clientes);
        }

        [HttpGet("id")]
        public ActionResult<ClienteModel>BuscarClientesPorId(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if(cliente == null)
            {
                return NotFound("Registro não localizado");
            }

            return Ok(cliente);
        }
    }

}
