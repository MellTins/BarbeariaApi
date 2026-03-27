using BarbeariaApi.Data;
using BarbeariaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarbeariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        
        
            private readonly AppDbContext _context;
            public ServicosController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public ActionResult<List<ServiceModel>> BuscarServicos()
            {
                var servicos = _context.Servicos.ToList();
                return Ok(servicos);
            }

           [HttpGet("{id}")]
            public ActionResult<ServiceModel> BuscarServicosPorId(int id)
            {
                var servico = _context.Servicos.Find(id);

                if (servico == null)
                {
                    return NotFound("Registro não localizado");
                }

                return Ok(servico);
            }

            [HttpPost]
            public ActionResult<ServiceModel> CriarServicos(ServiceModel novoServico)
            {
                if (novoServico == null)
                {

                    return BadRequest("Ocorreu um erro na solicitação!");
                }

            if (novoServico.Preco <= 0) return BadRequest("O preço deve ser maior que zero");

                _context.Servicos.Add(novoServico);
                _context.SaveChanges();

                return CreatedAtAction(nameof(BuscarServicosPorId), new { id = novoServico.Id }, novoServico);
            }

            [HttpPut]
            [Route("{id}")]
            public ActionResult<ServiceModel> EditarServiços(ServiceModel editarServico, int id)
            {
                var servicoEditar = _context.Servicos.Find(id);

                if (servicoEditar == null)
                {
                    return NotFound("Registro não localizado");
                }

            servicoEditar.NomeCorte = editarServico.NomeCorte;
            servicoEditar.Preco = editarServico.Preco;
            servicoEditar.DuracaoMinutos = editarServico.DuracaoMinutos;

                _context.Servicos.Update(servicoEditar);
                _context.SaveChanges();

                return Ok("serviço editado com sucesso");
        }

            [HttpDelete]
            [Route("{id}")]
            public ActionResult<ServiceModel> ExcluirServico(int id)
            {
                var servico = _context.Servicos.Find(id);

                if (servico == null)
                {
                    return NotFound("Registro não localizado");
                }

                _context.Servicos.Remove(servico);
                _context.SaveChanges();

                return Ok("Cliente removido com sucesso.");
            }

        }


    
}
