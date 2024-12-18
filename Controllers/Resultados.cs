

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[ApiController]
[Route("api/[controller]")]
public class ResultadosController : ControllerBase
{

    private readonly ApplicationDBContext _context;

    public ResultadosController(ApplicationDBContext context)
    {
        _context = context;
    }


    [HttpGet("results")]
    public async Task<IActionResult> Index()
    {
        var result = await _context.Resultados.Include(r => r.Deportista).ToListAsync();
        return Ok(result);
    }

    [HttpPost("addResult")]
    public async Task<IActionResult> AddResult([FromBody] Resultado resultado)
    {
        _context.Resultados.Add(resultado);

        await _context.SaveChangesAsync();
        return Ok(new { message = "Creado", resultado });
    }

}