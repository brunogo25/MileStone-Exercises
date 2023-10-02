public class Library
{
    public List<Room> Rooms { get; set; } = new List<Room>();

    public Book FindBookByISBN(string isbn)
    {
        foreach (var room in Rooms)
        {
            var book = room.FindBookByISBN(isbn);
            if (book != null)
                return book;
        }
        return null;
    }
}

public class Room
{
    public int RoomNumber { get; set; }
    public List<Row> Rows { get; set; } = new List<Row>();

    public Book FindBookByISBN(string isbn)
    {
        foreach (var row in Rows)
        {
            var book = row.FindBookByISBN(isbn);
            if (book != null)
                return book;
        }
        return null;
    }
}

public class Row
{
    public int RowNumber { get; set; }
    public List<Bookshelf> Bookshelves { get; set; } = new List<Bookshelf>();

    public Book FindBookByISBN(string isbn)
    {
        foreach (var shelf in Bookshelves)
        {
            var book = shelf.FindBookByISBN(isbn);
            if (book != null)
                return book;
        }
        return null;
    }
}

public class Bookshelf
{
    public int ShelfNumber { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();

    public Book FindBookByISBN(string isbn)
    {
        return Books.FirstOrDefault(b => b.ISBN == isbn);
    }
}

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
}

//End of code here

//Test data introduced from here
public static class Program
{
    public static void Main()
    {
      
        Library MyLibrary = new Library
        {
            Rooms = new List<Room>
            {
                new Room
                {
                    RoomNumber = 1,
                    Rows = new List<Row>
                    {
                        new Row
                        {
                            RowNumber = 1,
                            Bookshelves = new List<Bookshelf>
                            {
                                new Bookshelf
                                {
                                    ShelfNumber = 1,
                                    Books = new List<Book>
                                    {
                                        new Book { ISBN = "12345", Title = "Book1" },
                                        new Book { ISBN = "67890", Title = "Book2" }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };


        // Test 1: Find book by ISBN
        var foundBook = MyLibrary.FindBookByISBN("12345");
        Console.WriteLine(foundBook != null ? $"Found Book: {foundBook.Title}" : "Book not found.");

        // Test 2: Verify what happens with a non existing ISBN
        var notFoundBook = MyLibrary.FindBookByISBN("11111");
        Console.WriteLine(notFoundBook != null ? $"Found Book: {notFoundBook.Title}" : "Book not found.");

        // Test 3: Verify inventory list
        foreach (var room in MyLibrary.Rooms)
        {
            Console.WriteLine($"Room {room.RoomNumber}");
            foreach (var row in room.Rows)
            {
                Console.WriteLine($"\tRow {row.RowNumber}");
                foreach (var shelf in row.Bookshelves)
                {
                    Console.WriteLine($"\t\tShelf {shelf.ShelfNumber}");
                    foreach (var book in shelf.Books)
                    {
                        Console.WriteLine($"\t\t\t{book.Title} - {book.ISBN}");
                    }
                }
            }
        }
    }
}