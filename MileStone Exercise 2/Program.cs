using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public List<string> Authors { get; set; } = new List<string>();
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int PublicationYear { get; set; }
}

public class Library
{
    private List<Book> books = new List<Book>();

    public List<Book> ReadBooks(string input)
    {
        var lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
        var bookList = new List<Book>();

        Book currentBook = null;
        foreach (var line in lines)
        {
            if (line.StartsWith("Book"))
            {
                if (currentBook != null) bookList.Add(currentBook);
                currentBook = new Book();
                continue;
            }
            if (line.StartsWith("Author: "))
                currentBook.Authors.Add(line.Replace("Author: ", ""));
            else if (line.StartsWith("Title: "))
                currentBook.Title = line.Replace("Title: ", "");
            else if (line.StartsWith("Publisher: "))
                currentBook.Publisher = line.Replace("Publisher: ", "");
            else if (line.StartsWith("Published: "))
                currentBook.PublicationYear = int.Parse(line.Replace("Published: ", ""));
        }
        if (currentBook != null) bookList.Add(currentBook);

        books.AddRange(bookList);
        return bookList;
    }

    public List<Book> FindBooks(string searchString)
    {
        var searchQueries = searchString.Split(new[] { " & " }, StringSplitOptions.None)
                                        .Select(x => x.Trim('*')).ToList();

        return books.Where(b =>
            searchQueries.All(query =>
                b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Publisher.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Authors.Any(author => author.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                b.PublicationYear.ToString().Contains(query))).ToList();
    }
}
public class Program
{
    public static void Main()
    {
        var library = new Library();
        string input = 
            @"Book:
                Author: Brian Jensen
                Title: Texts from Denmark
                Publisher: Gyldendal
                Published: 2001

             Book:
                Author: Peter Jensen
                Author: Hans Andersen
                Title: Stories from abroad
                Publisher: Borgen
                Published: 2012";

        library.ReadBooks(input);
        var foundBooks = library.FindBooks("*20* & *peter*");
        foreach (var book in foundBooks)
        {
            Console.WriteLine($"Title: {book.Title}, Publisher:{book.Publisher}, Published: {book.PublicationYear}");
        }
    }
}