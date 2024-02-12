using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
public class WebController : ControllerBase
{
    private readonly IWebRepository _webRepository;

    public WebController(IWebRepository webRepository)
    {
        _webRepository = webRepository;
    }

    [HttpPost]
    [Route("/add")]
    public Task Add([FromBody] string fake, string title, string author, string genres, DateTime publicationDate,
        string annotation, string isbn)
    {
        var validator = new Validator();
        var storeWord = new BookSetter(validator);
        var book = storeWord.SetBook(title, author, genres, publicationDate, annotation, isbn);

        return _webRepository.Add(book);
    }

    [HttpGet]
    [Route("/search")]
    public Task<List<BookDto>> SearchBook(string keyword, int mode)
    {
        return _webRepository.Search(keyword, mode);
    }

    [HttpGet]
    [Route("/search-by-keyword")]
    public Task<List<BookDto>> SearchBookByKeyword(string keywords)
    {
        return _webRepository.SearchByKeywords(keywords);
    }
}
