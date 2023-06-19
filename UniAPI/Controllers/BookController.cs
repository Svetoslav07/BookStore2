using Microsoft.AspNetCore.Mvc;
using BookSt_bookService = bookservice;
    }

    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Book>))]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("GetAll")]
public async Task<IEnumerable<Book>> GetAll()
{
    //var result = await _bookService.GetAll();

    //if (result != null && result.Count() < 0) return Ok(result);

    //return NotFound();

    return await _bookService.GetAll();
}

[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<Book>))]