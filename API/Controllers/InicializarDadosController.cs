using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { Id = 1, Nome = "Cosméticos" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { Id = 1, Nome = "Perfume", Preco = 110, Quantidade = 2, CategoriaId = 1 },
                    new Produto { Id = 2, Nome = "Creme", Preco = 45, Quantidade = 12, CategoriaId = 1 },
                    new Produto { Id = 3, Nome = "Sabonete Líquido", Preco = 30, Quantidade = 20, CategoriaId = 1 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}