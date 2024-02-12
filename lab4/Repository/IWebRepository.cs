using WebApplication1.Model;

namespace WebApplication1.Repository;

public interface IWebRepository
{
    Task Add(BookDto book);
    Task<List<BookDto>> Search(string keyword, int mode);
    Task<List<BookDto>> SearchByKeywords(string keywords);
}
