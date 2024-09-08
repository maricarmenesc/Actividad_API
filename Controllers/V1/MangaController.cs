namespace mangas.Controllers.V1;

[ApiController]
[Route("api/[controller]")]

public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;

    public MangaController(MangaService mangaService)
    {
        this._mangaService = mangaService;
    }

[HttpGet]
public IActionResult GetAll()
{
    return Ok(_mangaService.GetAll());
}

[HttpGet("{id:int}")]
public IActionResult GetById([FromRoute]int id)
{
    var manga = _mangaService.GetById()
    if (manga == null)
    {
        return NotFound();
    }
    return Ok(manga);
}

[HttpPost]
public IActionResult Add([FromBody]Manga manga)
{
    _mangaService.Add(manga);
    return CreatedAction(nameof(GetById), new { id = manga.Id }, manga);
}

[HttpPut("{id}")]
public IActionResult Update(int id, MangaController manga)
{
    if (id != manga.Id)
    {
        return BadRequest();
    }
    _mangaService.Update(manga);
    return NoContent();
}

[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    _mangaService.Delete(id);
    return NoContent();
}
}