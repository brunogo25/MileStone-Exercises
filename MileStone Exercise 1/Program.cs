using System;
using System.Collections.Generic;
using System.Diagnostics;

public abstract class LibraryItem
{
    public string Title { get; set; }
    public string ISBN { get; set; }

    public virtual void Download()
    {
        Console.WriteLine($"Downloading {Title}...");
    }
}

public class Book : LibraryItem
{
    public string Author { get; set; }
    public int Pages { get; set; }
}

public abstract class Media : LibraryItem
{
    public List<Track> Tracks { get; set; }
}


public class CD : Media
{
    //properties and methods can go here
}

public class DVD : Media
{
    //properties and methods can go here
}

public class BluRay : Media
{
    //properties and methods can go here
}
public class Track
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public TimeSpan Duration { get; set; }
}

public class Program
{
    public static void Main()
    {
        // i used this example so that i could execute the code :)
        Book myBook = new Book { Title = "Sample Book", ISBN = "123456789", Author = "John Doe", Pages = 300 };
        CD myCD = new CD { Title = "Sample Album", ISBN = "987654321", Tracks = new List<Track> { new Track { Title = "Track1", Artist = "John", Duration = TimeSpan.FromMinutes(5) } } };

        myBook.Download();
        myCD.Download();

        Console.WriteLine($"Book: {myBook.Title} , ISBN: {myBook.ISBN}, Author: {myBook.Author} , Pages:{myBook.Pages}");
        Console.WriteLine($"CD: {myCD.Title} , ISBN: {myCD.ISBN} , Track Count: {myCD.Tracks.Count}");
    }
}

    /* Diagram:
     *                            | Library item |
     *                            ________________
     *                            
     *                            | - Title      |
     *                            | - ISBN       |
     *                            ________________
     *                                    |
     *                         _______________________
     *                         |                     |
     *                      |Book|                 |Media|
     *                                                |
     *                                             |-Tracks*| 
     *                                                |
     *                                         ________________
     *                                         |      |       |
     *                                       |CD|   |DVD|  |BluRay|  
     *                            
     *                            
     *                          
     *                  * |-Tracks|
     *                    _________
     *                    | - Title    |
     *                    | - Artist   |
     *                    | - Duration |
     */
 
 


