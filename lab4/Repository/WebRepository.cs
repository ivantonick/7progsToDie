using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Model;

namespace WebApplication1.Repository;

public class WebRepository(WebContext context) : IWebRepository
{
    public Task Add(BookDto book)
    {
        if (context.Books!.Any(b => b.Title == book.Title && b.Author == book.Author && b.Genres == book.Genres &&
                                     b.PublicationDate == book.PublicationDate && b.Annotation == book.Annotation &&
                                     b.ISBN == book.ISBN)) throw new Exception("Книга уже существует.");
        context.Books?.Add(book);
        return context.SaveChangesAsync();

    }

    public Task<List<BookDto>> Search(string keyword, int mode)
    {
        return mode switch
        {
            1 => context.Books!.Where(w => w.Title.ToLower() == keyword.ToLower()).ToListAsync(),
            2 => context.Books!.Where(w => w.Author.ToLower() == keyword.ToLower()).ToListAsync(),
            3 => context.Books!.Where(w => w.ISBN.ToLower() == keyword.ToLower()).ToListAsync(),
            _ => throw new Exception("Неизвестный режим / Книга не найдена.")
        };
    }

    public async Task<List<BookDto>> SearchByKeywords(string keywords)
    {
        var keywordArray = keywords.Split(' ');
        // Поиск книг по ключевым словам
        var books = await context.Books.ToListAsync();

        // Создание словаря для отслеживания количества ключевых слов в каждой книге
        Dictionary<BookDto, int> bookKeywordCount = new Dictionary<BookDto, int>();

        // Перебираем найденные книги
        foreach (var book in books)
        {
            int count = 0;

            // Проверяем наличие ключевых слов в свойствах книги
            if (keywordArray.Any(keyword => book.Title.Contains(keyword)))
            {
                count++;
            }
            if (keywordArray.Any(keyword => book.Author.Contains(keyword)))
            {
                count++;
            }
            if (keywordArray.Any(keyword => book.Genres.Contains(keyword)))
            {
                count++;
            }

            // Записываем количество найденных ключевых слов для книги
            bookKeywordCount.Add(book, count);
        }

        // Сортировка книг по количеству найденных ключевых слов
        var sortedBooks = bookKeywordCount.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

        // Возвращаем книги без аннотации (краткие описания) в порядке сортировки
        var result = sortedBooks.Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Genres = b.Genres,
            PublicationDate = b.PublicationDate,
            ISBN = b.ISBN
        }).ToList();
        
        return result;
    }
}