using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IBookService _bookService;

    public BookController(ILogger<AuthorController> logger,
        IBookService bookservice)
    {
        _logger = logger;
        _bookService = bookservice;
    }
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Book>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _bookService.GetAll();

        if (result != null && result.Any()) return Ok(result);

        return NotFound();
    }

    [HttpPost("Add")]
    public async Task Add([FromBody] Book book)
    {
        await _bookService.Add(book);
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _bookService.GetById(id);

        if (result != null) return Ok(result);

        return BadRequest();
    }

    [HttpPut("Update")]
    public void Update([FromBody] Book book)
    {
        _bookService.Update(book);
    }

    [HttpDelete("Delete")]
    public void Delete(int id)
    {
        _bookService.Delete(id);
    }
}

