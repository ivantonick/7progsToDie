using WebApplication1.Model;

namespace WebApplication1.Services;

public class BookSetter(Validator validator)
{
    public BookDto SetBook(string title, string author, string genres, DateTime publicationDate, string annotation, string isbn)
    {
        var book = new BookDto
        {
            Title = title,
            Author = author,
            Genres = genres,
            PublicationDate = publicationDate,
            Annotation = annotation,
            ISBN = isbn
        };

        validator.ValidateBook(book);
        return book;

    }
}
