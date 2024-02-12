using WebApplication1.Model;

namespace WebApplication1.Services;

public class Validator
{
    public void ValidateBook(BookDto book)
    {
        if (book.Title=="" || book.Author=="" || book.Genres=="" || book.PublicationDate.ToString() == "" ||
            book.Annotation=="" || book.ISBN=="")
            throw new Exception("Empty fields are not allowed");
    }
}