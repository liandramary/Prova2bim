using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Venda venda)
        {
            venda.ItemVenda = _context.ItensVenda.Find(venda.ItemId);
            venda.FormaPagamento = _context.FormasPagamento.Find(venda.PagamentoId);
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }

        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.Vendas
            .Include(p => p.FormaPagamento)
            .ToList());
    }
}